using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sphynx : Boss
{
    public float animationVulnerableShakeIntensity = 0.2f;
    private bool previousWasInCooldown;
    private Vector3 basePos;

    new void Start()
    {
        base.Start();
        previousWasInCooldown = inCooldown;
    }

    new void Update()
    {
        base.Update();


        // Animation : 
        // If vulnerable, shake
        if (inCooldown)
        {
            if (!previousWasInCooldown)
            {
                basePos = transform.position;
            }

            transform.position = basePos + animationVulnerableShakeIntensity * new Vector3(Random.value, Random.value, Random.value);
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
}
