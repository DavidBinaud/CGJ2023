using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BasicMob : AEnemy{
    [SerializeField] private Enemy datas;
    
    private Animator animator;
    private NavMeshAgent nm_agent;

    [SerializeField] private AWeapons weapon;

    private bool isMooving = false;
    private int hp;

    public override void SetStartPosition(Vector3 _position)
    {
        transform.position = _position;
    }
    protected bool CanAttack()
    {
        return /*!(animator.GetCurrentAnimatorStateInfo(0).IsName("attack")) && */(Vector3.Magnitude(PlayerController.Instance.transform.position - transform.position) <= datas.rangeAttack);
    }

    protected bool CanMoove()
    {
        return Vector3.Magnitude(PlayerController.Instance.transform.position - transform.position) <= datas.rangeAgro ;
    }

    public override void Attack()
    {
        isMooving = false;
        Vector3 dir = PlayerController.Instance.transform.position - transform.position;
        //Face the player
        transform.forward = new Vector3(dir.x, 0.0f, dir.z);
        //Attack
        animator.Play("attack");
    }

    public override void Moove()
    {
        nm_agent.SetDestination(PlayerController.Instance.transform.position);
        if( ! isMooving)
        {
            isMooving = true;
            animator.Play("run");
        }
    }

    void Start()
    {
        weapon.SetDamages(datas.Damage);
        animator = GetComponent<Animator>();
        nm_agent = GetComponent<NavMeshAgent>();
        nm_agent.speed = datas.moveSpeed;
        hp = datas.Health;
    }
    void Update()
    {
        if (CanMoove())
        {
            if(CanAttack())
            {
                Attack();
            }
            else
            {
                Moove();
            }
        }    
    }

    public void TakeDamage(int amount){
        hp -= amount;
        if(hp <= 0){
            Die();
        }
    }
    public void Die(){
        PlayerController.Instance.OnKill();
        Destroy(transform.gameObject);
    }

    public void Unfreeze(){
        GetComponent<Animator>().speed = 1f;
        GetComponent<NavMeshAgent>().speed = datas.moveSpeed;
    }
}
