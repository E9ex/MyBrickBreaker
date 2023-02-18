using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Paddle : MonoBehaviour
{
    public  Rigidbody2D rb { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxbounceAngle = 75f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }

         else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else
        {
            direction=Vector2.zero;
            
        }
    }

    private void FixedUpdate()
    {
        if (direction!=Vector2.zero)
        {
            rb.AddForce(direction*speed);
        }
    }

    public void resetpaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
        rb.velocity = Vector2.zero;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)//for reflection its complicated asfck.
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();tim abiye SOR.
        if (ball!=null)
        {
            Vector3 paddleposition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;//topun çarptıgını sayıyor. bunu ındexleyip sakliyoruz.


            float offset = paddleposition.x- contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;//paddle ın genişliğinin yarısı yüzde olarak. othercollider==paddle.
            //-100 ve +100 olarak baktıgımız için 2 ye bölüyoruz.


            float currentangle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity);
            float bounceangle = (offset / width)*maxbounceAngle;//istenilen angle
            float newAngle = Mathf.Clamp(currentangle+bounceangle,-maxbounceAngle,maxbounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;
        }
    }*/
}
