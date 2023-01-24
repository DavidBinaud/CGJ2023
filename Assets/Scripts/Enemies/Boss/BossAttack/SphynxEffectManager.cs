using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxEffectManager : MonoBehaviour
{
    public ParticleSystem HurtParticles;


    public void OnHit()
    {
        Instantiate(HurtParticles, transform);
    }
}
