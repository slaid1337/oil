using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{


    public Transform target;
    public Vector3 cameraOffset;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cameraOffset = transform.position - target.transform.position;
    }

    
    private void LateUpdate()
    {
        Vector3 newPositoin = target.transform.position + cameraOffset;
        transform.position = newPositoin;
    }
}
