using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float enemySpeed = 2f; // Adjust this value to control the movement speed.
    private Rigidbody2D rb2d;
    private bool movingRight = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (movingRight)
        {
            rb2d.velocity = new Vector2(enemySpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-enemySpeed, rb2d.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject) 
        {
            movingRight = !movingRight;
        }
    }
}
