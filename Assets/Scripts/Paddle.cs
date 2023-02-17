using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Paddle : MonoBehaviour
{
    public  Rigidbody2D rb { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }

        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (direction!=Vector2.zero)
        {
            rb.AddForce(direction*speed);
        }
    }
}
