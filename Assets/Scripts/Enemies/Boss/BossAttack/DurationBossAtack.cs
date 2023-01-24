using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DurationBossAtack : BossAttack
{
    public float duration;

    private float currentDuration;

    protected void OnEnable()
    {
        currentDuration = duration;
    }

    protected void Update()
    {
        currentDuration -= Time.deltaTime;
    }

    public override bool IsFinished()
    {
        return currentDuration <= 0.0f;
    }
}
