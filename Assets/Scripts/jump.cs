using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class jump : MonoBehaviour
{

    Rigidbody2D rb2D;
    public float jumpForce = 6f;
    bool isGrounded;

    public float maxSpeed = 7; 
    public float acceleration = 30; 
    public float deacceleration = 4; 

    float velocityX;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveLeftAndRight();
        Jump();
        GravityAdjust();
    }

    private void MoveLeftAndRight()
    {
       

        float x = Input.GetAxisRaw("Horizontal");
        velocityX += x * acceleration * Time.deltaTime;
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (x == 0 || (x < 0 == velocityX > 0))
        {
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }

    private void GravityAdjust()
    {
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
