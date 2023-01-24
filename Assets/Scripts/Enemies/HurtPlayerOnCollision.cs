using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnCollision : MonoBehaviour
{
    public bool deleteObject = false;
    public bool onlyOnce = false;

    public bool active = true;

    public int damage = 1;


    private void OnCollisionEnter(Collision collision)
    {
        if (active && collision.collider.CompareTag("Player"))
        {
            PlayerController.Instance.GetHit(damage);

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
