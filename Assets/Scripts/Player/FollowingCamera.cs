using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float cameraDistance = 5f;

    private Rigidbody targetRB;

    void Start(){
        targetRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.position + target.forward *  cameraDistance, speed * Time.deltaTime);
        //transform.position = target.position + target.forward * 5f;

    }
}
