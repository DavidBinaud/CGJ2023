using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private int number;
    [SerializeField] private AEnemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 posOnCircle = UnityEngine.Random.insideUnitCircle * radius * 0.5f;
            Vector3 pos = transform.position + (new Vector3(posOnCircle.x, 0.0f, posOnCircle.y));

            AEnemy instance = Instantiate<AEnemy>(enemy);
            instance.SetStartPosition(pos);
        }

    }
}
