using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public  Rigidbody2D rb { get; private set; }
    public float speed = 500f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    

    private void Start()
    {
       resetball();
    }

    public void resetball()
    {

        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        Invoke("setRandomTrajectory",0.75f);//fordelay.
    }

    

    private void setRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f,1f);//?
        force.y = -1f;//  to down.
        rb.AddForce(force.normalized*speed);
    }
}
