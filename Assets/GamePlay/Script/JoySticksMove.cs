using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class JoySticksMove : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        float inputH = JoyStickController.Horizontal;
        float inputV = JoyStickController.Vertical;

        rb.velocity = new Vector3(inputH * speed, rb.velocity.y, inputV * speed);

    }

}
