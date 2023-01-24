using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeapons : AWeapons{
    private int dmg;

    public override void SetDamages(int damage)
    {
        dmg = damage;
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            PlayerController.Instance.GetHit(dmg);
        }
    }
}
