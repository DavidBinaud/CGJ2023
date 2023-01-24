using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : DurationBossAtack
{
    public Projectile projectilePrefab;
    public float nbProjPerWave = 10.0f;
    public float projectileSpeed = 5.0f;
    public float waveTime = 0.5f;

    private float currentWaveTime;
    private int currentWave;


    private new void OnEnable()
    {
        base.OnEnable();
        currentWaveTime = 0.0f;
        currentWave = 0;

    }

    private new void Update()
    {
        base.Update();

        currentWaveTime -= Time.deltaTime;

        if (currentWaveTime <= 0.0f)
        {
            currentWave++;
            currentWaveTime = waveTime;

            float increment = (Mathf.PI * 2.0f) / nbProjPerWave;
            float phase = currentWave;
            float angle;
            Projectile instancedProjectile;
            for (int i = 0; i < nbProjPerWave; i++)
            {
                angle = increment * i + phase;

                instancedProjectile = Instantiate<Projectile>(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                Vector3 positionInCircle = new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));

                instancedProjectile.speed = positionInCircle * projectileSpeed;
            }
        }
    }
}
