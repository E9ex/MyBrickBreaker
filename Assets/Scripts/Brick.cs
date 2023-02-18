using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer  spriteRenderer { get; private set; }
    public int health { get; private set; }
    public Sprite[] states;
    public bool unbreakable;
    public int points = 100;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        resetbrick();
    }

    private void hit()
    {
        if (unbreakable)
        {
            return;
            
        }
        health--;
        if (health<=0) {
            gameObject.SetActive(false);
        }
        else {
            spriteRenderer.sprite = states[health - 1];

        }
        FindObjectOfType<GameManager>().hit(this);
      
    }

    public void resetbrick()
    {
        gameObject.SetActive(true);
        if (!unbreakable)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health-1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="ball")
        {
            hit();
        }
    }
}
