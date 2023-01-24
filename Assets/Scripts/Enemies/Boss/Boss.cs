using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public bool randomOrder;
    public BossAttack[] bossAtacks;

    protected int curentAttack;

    protected void Start()
    {
        
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
        if (bossAtacks[curentAttack].IsFinished())
        {
            bossAtacks[curentAttack].enabled = false;
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
