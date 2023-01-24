using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickACardDebugging : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            PlayerController.Instance.OnKill();
        }
    }
}
