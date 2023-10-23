using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust this value to control the movement speed.
    Rigidbody2D rb2d;
    Transform target;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb2d.velocity = direction * moveSpeed;
        transform.up = direction;
    }
}
