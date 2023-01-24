using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetShards : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.IncreaseShards(Random.Range(10, 100));
        }
    }
}
