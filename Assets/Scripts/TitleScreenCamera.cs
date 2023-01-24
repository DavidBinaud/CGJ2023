using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenCamera : MonoBehaviour
{
    Vector3 startPos;
    void Start(){
        startPos = transform.position;
    }
    float time = 0f;
    void Update()
    {
        time += Time.deltaTime;
        transform.position = startPos + Mathf.Cos(time) * Vector3.right + Mathf.Sin(time) * Vector3.up;
    }
}
