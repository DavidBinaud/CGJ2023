using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeapons : MonoBehaviour, IWeapons{
    private int dmg;
    public void SetDamages(int damage)
    {
        dmg = damage;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            PlayerController.Instance.GetHit(dmg);
        }
    }
}
