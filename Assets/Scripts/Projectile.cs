using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 speed = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;

    public float maxDuration = 5.0f;

    private float duration;

    private void Start()
    {
        duration = maxDuration;
    }

    void Update()
    {
        speed += acceleration;
        transform.Translate(speed * Time.deltaTime);

        duration -= Time.deltaTime;

        if (duration <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
