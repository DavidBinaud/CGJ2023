using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnCollision : MonoBehaviour
{
    public float damage = 1.0f;

    public bool deleteObject = false;
    public bool onlyOnce = false;

    public bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if(active && other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);

            if (deleteObject)
            {
                Destroy(gameObject);
            }
            if (onlyOnce)
            {
                active = false;
            }
        }
    }
}
