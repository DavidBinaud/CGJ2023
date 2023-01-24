using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnCollision : MonoBehaviour
{
    public bool deleteObject = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController.Instance.GetHit();

            if (deleteObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
