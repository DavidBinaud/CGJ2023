using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxHealth : EnemyHealth
{
    public bool invincible = true;
    public override void TakeDamage(int damage)
    {
        if (!invincible)
        {
            base.TakeDamage(damage);
        }
    }
}
