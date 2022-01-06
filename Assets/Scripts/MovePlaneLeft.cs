using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaneLeft : MonoBehaviour
{
    Vector3 initialPlanePos;
    Rigidbody rb;
    bool resetPos = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPlanePos = transform.position;
    }

    private void Update()
    {
        rb.velocity = Vector3.left * 5f;

        if(transform.position.x <= -56)
        {
            transform.position = initialPlanePos;
        }
    }
}

