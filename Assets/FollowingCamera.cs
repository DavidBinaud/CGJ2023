using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, speed * Time.deltaTime);

    }
}
