using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sphynx : Boss
{
    public float animationVulnerableShakeIntensity = 0.2f;
    public float animationDyingTime = 5.0f;
    public SphynxHealth healthSystem;

    private bool previousWasInCooldown;
    private Vector3 basePos;

    private bool dying = false;
    private float curentAnimationDyingTime;

    new void Start()
    {
        base.Start();
        previousWasInCooldown = inCooldown;
    }

    new void Update()
    {
        if (!dying)
        {
            base.Update();
        }


        healthSystem.invincible = !inCooldown;

        // Animation : 
        // If vulnerable, shake
        if (inCooldown || dying)
        {
            if (!previousWasInCooldown)
            {
                basePos = transform.position;
            }

            transform.position = basePos + animationVulnerableShakeIntensity * new Vector3(Random.value, Random.value, Random.value);

            if (dying)
            {
                curentAnimationDyingTime -= Time.deltaTime;
                basePos -= Vector3.up * (5.0f / animationDyingTime) * Time.deltaTime;
            }
        }
        else
        {
            if (previousWasInCooldown)
            {
                transform.position = basePos;
            }
        }
        previousWasInCooldown = inCooldown;
    }

    public override void Die()
    {
        base.Die();
        this.enabled = true;
        dying = true;
        curentAnimationDyingTime = animationDyingTime;
    }
}
