using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float jumpForce = 6f;
    bool isGrounded;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        Jump();
        GravityAdjust();
        
    }
    private void GravityAdjust()
    {
        //If we are falling down increase gravity x4
        //This creates a much better feeling, less floaty
        if (rb2D.velocity.y < 0)
            rb2D.gravityScale = 2;
        else
            rb2D.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            isGrounded = false;
        }
        
    }
}
