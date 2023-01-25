using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform armPivot;
    [SerializeField] private GameObject deathScreen;

    public static PlayerController Instance;
    public event Action<int> onSelectCard;
    public event Action onChangeHand;
    public event Action<int> onSandAmountChange;
    public event Action<int> onShardAmountChange;

    public Spell[] hand;
    public List<Spell> deck;

    public IInteraction currentInteraction;

    public PlayerData playerData;


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
            onSandAmountChange(playerData.sandAmount);
        }
    }
    public void ChangeShardAmount()
    {
        if (onShardAmountChange != null)
        {
            onShardAmountChange(playerData.shards);
        }
    }

    

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
            if(Physics.Raycast(transform.position + Vector3.up, transform.forward * playerData.dashForce, out hit, 2* playerData.dashForce)){
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            else{
                transform.position = transform.position + transform.forward * playerData.dashForce; ;
            }

            
            
            //rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        }
        
    }
    public void StartAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(currentAttackCD <= 0f){
                currentAttackCD = playerData.attackDelay;
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
            armPivot.localRotation = Quaternion.Slerp(armPivot.localRotation, finalRotation, playerData.attackSpeed * Time.deltaTime);
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
        rb.MovePosition(transform.position + (input.ToIso()) * playerData.speed * Time.deltaTime);
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
            
            if(playerData.sandAmount > 0){
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
        if(playerData.sandAmount >= playerData.maxSandAmount){
            Debug.Log("already Max sand, drop to the floor.");
        }
        else{
            playerData.sandAmount++;
            ChangeSandAmount();
        }
        
    }
    public void RemoveSand(){
        playerData.sandAmount--;
        ChangeSandAmount();
    }

    public void GetHit(){
        if(playerData.sandAmount > 0){
            playerData.sandAmount--;
            ChangeSandAmount();
        }
        else{
            Die();
        }
    }

    private void Die(){
        Debug.Log("Die");
        FindObjectOfType<DataPersistenceManager>().SaveGame();
        StartCoroutine(BackToMainMenu());
    }
    IEnumerator BackToMainMenu(){
        Instantiate(deathScreen);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

    }
    
    public void SetToLevelStart(){
        transform.parent.position = GameObject.Find("LevelStart").transform.position;
        transform.localPosition = new Vector3(0f, 1f, 0f);
        transform.parent.Find("CameraPivot").transform.position = Vector3.zero;
    }

    public void UpgradeSand(float value, int cost){
        if(playerData.shards >= cost){
            playerData.shards -= cost;
            ChangeShardAmount();
            playerData.maxSandAmount = (int)value;
            playerData.sandAmount = playerData.maxSandAmount;
            ChangeSandAmount();
            playerData.upgradeLevels[(int)Helpers.ShopItems.Sand]++;
        }
    }
    public void UpgradeSpeed(float value, int cost)
    {
        if (playerData.shards >= cost)
        {
            playerData.shards -= cost;
            ChangeShardAmount();
            playerData.speed = (int)value;
            playerData.upgradeLevels[(int)Helpers.ShopItems.Speed]++;
        }
    }

    public void Interact(InputAction.CallbackContext ctx){
        if(ctx.performed){
            if (currentInteraction != null)
            {
                currentInteraction.Use();
                return;
            }
        }
    }

    public void IncreaseShards(int amount){
        playerData.shards += amount;
        ChangeShardAmount();
    }

    
}
