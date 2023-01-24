using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxEffectManager : MonoBehaviour
{
    public ParticleSystem HurtParticles;
    public ParticleSystem DieParticles;


    public void OnHit()
    {
        Instantiate(HurtParticles, transform);
    }

    public void OnDie()
    {
        Instantiate(DieParticles, transform);
    }
}
