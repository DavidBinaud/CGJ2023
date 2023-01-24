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
        //Face the player
        transform.rotation = Quaternion.LookRotation(Vector3.Normalize(PlayerController.Instance.transform.position - transform.position));
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
}
