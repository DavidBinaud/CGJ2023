using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAttackAgain : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void OnDisable()
    {
        GetComponent<Collider>().enabled = false;
    }
}
