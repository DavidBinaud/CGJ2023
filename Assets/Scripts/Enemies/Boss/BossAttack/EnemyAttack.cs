using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : BossAttack
{
    protected new void OnEnable()
    {
        Debug.Log("Enemy attack !");
        //TODO instantiate enemies
    }

    private new void Update()
    {

    }

    private void OnDisable()
    {

    }

    public override bool IsFinished()
    {
        return true;
        //TODO nbEnemiesLeft = 0;
    }
}
