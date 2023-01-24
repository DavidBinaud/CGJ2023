using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : BossAttack
{
    public float elevation = 10.0f;
    public float timeInterval = 1.0f;
    public float lerpSpeed = 0.3f;
    public HurtPlayerOnCollision[] stompObjects;

    private int curentStompObject;
    private List<Vector3> stompTargets = new List<Vector3>();
    private float curentTimeInterval;

    private bool isFinished;

    protected void OnEnable()
    {
        stompTargets.Clear();
        for (int i = 0; i < stompObjects.Length; i++)
        {
            stompTargets.Add(stompObjects[i].transform.position);
        }
        curentTimeInterval = timeInterval;
        curentStompObject = 0;
        isFinished = false;
    }

    private void Update()
    {
        curentTimeInterval -= Time.deltaTime;

        stompTargets[curentStompObject] = PlayerController.Instance.transform.position + Vector3.up * elevation;

        if (curentTimeInterval <= 0.0f)
        {
            curentTimeInterval = timeInterval;

            stompTargets[curentStompObject] = stompObjects[curentStompObject].transform.position - Vector3.up * (elevation + PlayerController.Instance.transform.position.y);
            stompObjects[curentStompObject].active = true;

            curentStompObject = curentStompObject + 1;

            if (curentStompObject == stompObjects.Length)
            {
                isFinished = true;
            }
        }

        for (int i = 0; i < stompObjects.Length; i++)
        {
            float dist = Vector3.SqrMagnitude(stompObjects[i].transform.position - stompTargets[i]);
            stompObjects[i].transform.position = Vector3.Lerp(stompObjects[i].transform.position, stompTargets[i], lerpSpeed);

            if (dist < 0.1f)
            {
                stompObjects[i].active = false;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < stompObjects.Length; i++)
        {
            stompObjects[i].active = false;
        }
    }

    public override bool IsFinished()
    {
        return isFinished;
    }
}
