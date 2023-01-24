using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapons : MonoBehaviour, IWeapons
{
    public Projectile[] projectiles;
    public bool randomOrder;
    protected int curentAttack;


    public float projectileSpeed = 1.0f;

    public void SetDamages(int damages)
    {
        foreach (Projectile p in projectiles)
        {
            p.gameObject.GetComponent<HurtPlayerOnCollision>().damage = damages;
        }
    }

    public void CastAProjectile()
    {        
        if (randomOrder)
        {
            curentAttack = Random.Range(0, projectiles.Length);
        }
        else
        {
            curentAttack = (curentAttack + 1) % projectiles.Length;
        }

        Projectile intance = Instantiate<Projectile>(projectiles[curentAttack]);
        intance.speed = transform.forward * projectileSpeed;
    }
}
