using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform armPivot;

    public static PlayerController Instance;
    public event Action<int> onSelectCard;
    public event Action onChangeHand;
    public event Action<int> onSandAmountChange;

    public Spell[] hand;
    public List<Spell> deck;

    /* TODO : Sortir toutes les data améliorables dans une autre classe 
    et faire de la composition
    */
    int sandAmount = 3;
    int maxSandAmount = 3;


    private int selectedSpell = 5;

    public void OnKill(){
        Draw();
    }

    private void Draw(){
        int index = UnityEngine.Random.Range(0, deck.Count);
        Spell drawed = deck[index];
        
        for (int i = 0; i < 4; i++){
            
            if (hand[i] is null)
            {
                hand[i] = drawed;
                deck.RemoveAt(index);
                NotifyChangeHand();
                return;
            }
            Debug.Log("No space for " + drawed.name);
        }

    }

    public void NotifyChangeHand(){
        if (onChangeHand != null)
        {
            onChangeHand();
        }
    }

    public void SelectCard(){
        if (onSelectCard != null)
        {
            onSelectCard(selectedSpell);
        }
    }
    public void ChangeSandAmount()
    {
        if (onSandAmountChange != null)
        {
            onSandAmountChange(sandAmount);
        }
    }

    [SerializeField] private float speed = 5f;
    [SerializeField] private float dashForce = 5f;

    [SerializeField] private float attackSpeed = 180f;
    [SerializeField] private float attackDelay = 0.5f;

    private bool attackTimerOn = false;
    private float currentAttackCD = 0f;



    private Vector3 input;

    private float joyStickDeadZone = 0.1f;

    void Awake(){
        if(Instance is null){
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ReduceCooldowns();
    }

    void ReduceCooldowns(){
        if(attackTimerOn){
            currentAttackCD -= Time.deltaTime;
            if(currentAttackCD <= 0f){
                attackTimerOn = false;
            }
        }
    }

    void FixedUpdate(){
        Move();
    }

    public void Move(InputAction.CallbackContext ctx){
        Vector2 rawInput = ctx.ReadValue<Vector2>();
        if(rawInput.x < joyStickDeadZone && rawInput.x > -joyStickDeadZone){
            rawInput.x = 0f;
        }
        if (rawInput.y < joyStickDeadZone && rawInput.y > -joyStickDeadZone)
        {
            rawInput.y = 0f;
        }
        input = new Vector3(rawInput.x, 0f, rawInput.y);
    }

    public void Dash(InputAction.CallbackContext ctx){
        if(ctx.performed){
            RaycastHit hit;
            if(Physics.Raycast(transform.position + Vector3.up, transform.forward * dashForce, out hit, 2* dashForce)){
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            else{
                transform.position = transform.position + transform.forward * dashForce; ;
            }

            
            
            //rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        }
        
    }
    public void StartAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(currentAttackCD <= 0f){
                currentAttackCD = attackDelay;
                StartCoroutine(Attack());
            }
            
        }

    }
    void StartAttackTimer(){
        attackTimerOn = true;
        armPivot.localRotation = Quaternion.identity;
    }

    IEnumerator Attack(){
        Quaternion finalRotation = armPivot.localRotation * Quaternion.Euler(0f, -120f, 0f);

        while(armPivot.localRotation != finalRotation){
            armPivot.localRotation = Quaternion.Slerp(armPivot.localRotation, finalRotation, attackSpeed * Time.deltaTime);
            yield return null;
        }

        StartAttackTimer();
    }
    public void Look(InputAction.CallbackContext ctx)
    {
        Vector2 rawInput = ctx.ReadValue<Vector2>();
        if (rawInput.x < joyStickDeadZone && rawInput.x > -joyStickDeadZone)
        {
            rawInput.x = 0f;
        }
        if (rawInput.y < joyStickDeadZone && rawInput.y > -joyStickDeadZone)
        {
            rawInput.y = 0f;
        }
        Vector3 lookInput = new Vector3(rawInput.x, 0f, rawInput.y);
        if (lookInput != Vector3.zero)
        {
            Vector3 relative = (transform.position + lookInput.ToIso()) - transform.position;
            Quaternion rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = rot;
        }
    }

    void Move(){
        rb.MovePosition(transform.position + (input.ToIso()) * speed * Time.deltaTime);
    }

    public void SelectFirst(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedSpell = 0;
            SelectCard();
        }
    }
    public void SelectSecond(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedSpell = 1;
            SelectCard();
        }
    }
    public void SelectThird(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedSpell = 2;
            SelectCard();
        }
    }
    public void SelectFourth(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            selectedSpell = 3;
            SelectCard();
        }
    }
    public void Cast(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
            if(sandAmount > 0){
                if(selectedSpell >= hand.Length){
                    Debug.Log("No spell selected");
                    return;
                }
                if(hand[selectedSpell] is not null){
                    RemoveSand();
                    
                    Debug.Log("Cast " + hand[selectedSpell].name);
                    hand[selectedSpell].spellCard.GetComponent<ISpell>().Cast();
                    deck.Add(hand[selectedSpell]);
                    hand[selectedSpell] = null;
                    
                    NotifyChangeHand();
                }
            }
            else{
                Debug.Log("Cant Cast");
            }
        }
    }
    public void Sacrifice(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (hand[selectedSpell] is not null)
            {
                AddSand();
                Debug.Log("Sacrifice " + hand[selectedSpell].name);
                deck.Add(hand[selectedSpell]);
                hand[selectedSpell] = null;
                NotifyChangeHand();
            }
            else
            {
                Debug.Log("No spell to sacrifice");
            }
        }
        
    }

    public void AddSand(){
        if(sandAmount >= maxSandAmount){
            Debug.Log("already Max sand, drop to the floor.");
        }
        else{
            sandAmount++;
            ChangeSandAmount();
        }
        
    }
    public void RemoveSand(){
        sandAmount--;
        ChangeSandAmount();
    }

    public void GetHit(){
        if(sandAmount > 0){
            sandAmount--;
            ChangeSandAmount();
        }
        else{
            Debug.Log("Die");
        }
    }

    
}
