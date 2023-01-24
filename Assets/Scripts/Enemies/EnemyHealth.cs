using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    public UnityEvent onDamageEvent;
    public UnityEvent onDeathEvent;

    public virtual void TakeDamage(float damage)
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
