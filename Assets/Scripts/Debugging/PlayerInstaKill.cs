using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstaKill : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.GetHit();
        }
    }
}
