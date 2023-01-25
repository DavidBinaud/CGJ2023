using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : BasicMob
{
    public float health;

    public UnityEvent onDamageEvent;
    public UnityEvent onDeathEvent;

    protected new void Start()
    {
        
    }

    protected new void Update()
    {

    }

    public override void TakeDamage(int damage)
    {
        if (health > 0.0f)
        {
            health -= damage;

            if (health <= 0.0f)
            {
                onDeathEvent.Invoke();
            }
            else
            {
                onDamageEvent.Invoke();
            }
        }
    }
}
