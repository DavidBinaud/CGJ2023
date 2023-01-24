using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BasicMob : MonoBehaviour{
    [SerializeField] private ScriptableObjectMob datas;
    
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent nm_agent;
    [SerializeField] private Transform transform;

    [SerializeField] private IWeapons weapon;

    private bool isMooving = false;
    protected bool CanAttack()
    {
        return (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack")) && (Vector3.Magnitude(PlayerController.Instance.transform.position - transform.position) <= datas.rangeAttack);
    }

    protected bool CanMoove()
    {
        return Vector3.Magnitude(PlayerController.Instance.transform.position - transform.position) <= datas.rangeAgro ;
    }

    protected void Attack()
    {
        isMooving = false;
        animator.Play("attack");
    }

    protected void Moove()
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
        weapon.SetDamages(datas.damage);
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
