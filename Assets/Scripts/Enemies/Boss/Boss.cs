using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour, IEnemy
{
    public bool randomOrder;
    public float timeBetweenAttacks;
    public BossAttack[] bossAtacks;

    protected int curentAttack;
    protected float curentTimeBetweenAttacks;

    protected bool inCooldown = false;

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    protected void Start()
    {
        curentTimeBetweenAttacks = timeBetweenAttacks;
        if (randomOrder)
        {
            curentAttack = Random.Range(0, bossAtacks.Length);
        }
        else
        {
            curentAttack = 0;
        }
    }

    protected void Update()
    {
        if (!inCooldown && bossAtacks[curentAttack].IsFinished())
        {
            bossAtacks[curentAttack].enabled = false;
            inCooldown = true;
            curentTimeBetweenAttacks = timeBetweenAttacks;
        }

        if (inCooldown) { 

            curentTimeBetweenAttacks -= Time.deltaTime;

            if (curentTimeBetweenAttacks <= 0.0f)
            {
                inCooldown = false;
                
                if (randomOrder)
                {
                    curentAttack = Random.Range(0, bossAtacks.Length);
                }
                else
                {
                    curentAttack = (curentAttack + 1) % bossAtacks.Length;
                }
                bossAtacks[curentAttack].enabled = true;
            }
        }
    }
}
