using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float jumpForce = 6f;
    bool isGrounded;
    Vector2 checkpoint = new Vector2(5, 5);

    public float maxSpeed = 7;
    public float acceleration = 40;
    public float deacceleration = 3;
    public float coyote = 0.4f;
    public float short_coyote = 0.2f;
    public float stop = 0.1f;
    public int dash_power = 10;
    public int dashes = 5;

    public float delay = 3;
    float timer;

    public float velocityX;
    float velX;
    float velY;
    float dashX;
    float dashY;
    public bool dash_pause = false;
    bool reverse_gravity = false;
    public bool isDashing = false;
    bool jumping = false;
    public bool overworld = true;
    bool ran_right = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!dash_pause)
        {
            MoveLeftAndRight();
            Jump();
            GravityAdjust();
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            transform.position = checkpoint;
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.W))
            dashY = dash_power;
        else if (Input.GetKey(KeyCode.S))
            dashY = -dash_power;
        else
            dashY = 0;

        if (Input.GetKey(KeyCode.D))
            dashX = dash_power;
        else if (Input.GetKey(KeyCode.A))
            dashX = -dash_power;
        else
            dashX = 0;

        if (!isGrounded && !jumping && Input.GetKeyDown(KeyCode.Space) && dashes > 0)
        {
            Dash();
        }

        //if (isDashing)
        //{
        //    if (rb.velocity.x > 0 && rb.velocity.y > 0)
        //        animator.SetBool("isDashingRightUp", true);
        //    else if (rb.velocity.x > 0 && rb.velocity.y < 0)
        //        animator.SetBool("isDashingRightDown", true);
        //    else if (rb.velocity.x > 0 && rb.velocity.y == 0)
        //        animator.SetBool("isDashingRight", true);
        //    else if (rb.velocity.x == 0 && rb.velocity.y > 0)
        //        animator.SetBool("isDashingUp", true);
        //    else if (rb.velocity.x == 0 && rb.velocity.y < 0)
        //        animator.SetBool("isDashingDown", true);
        //    else if (rb.velocity.x < 0 && rb.velocity.y == 0)
        //        animator.SetBool("isDashingLeft", true);
        //    else if (rb.velocity.x < 0 && rb.velocity.y > 0)
        //        animator.SetBool("isDashingLeftUp", true);
        //    else if (rb.velocity.x < 0 && rb.velocity.y < 0)
        //        animator.SetBool("isDashingLeftDown", true);
        //}
        //else if (rb.velocity.x < 0)
        //    animator.SetBool("isJumping", true);
        //else if (rb.velocity.x < 0)
        //    animator.SetBool("isFalling", true);

        if (isGrounded)
        {
            dashes = 1;
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow) && dashes > 0 && !isDashing)
        //{
        //    animator.SetBool("isDashingUp", true);


        //    Dash();
        //    velX = rb.velocity.x;
        //    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        //    {
        //        rb.velocity = new Vector2(velX, 0).normalized * dash_power;
        //        rb.velocity = rb.velocity + new Vector2(velX, dash_power).normalized * dash_power;
        //    }
        //    else
        //    {
        //        velocityX = 0;
        //        rb.velocity = new Vector2(0, 0);
        //        rb.velocity = rb.velocity + new Vector2(0, dash_power);
        //    }
        //    isGrounded = false;
        //    dashes--;
        //    Invoke("Stop_dash", stop);
        //    Invoke("Enable_gravity", coyote);
        //    Invoke("Disable_pause", coyote);
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow) && dashes > 0 && !isGrounded && !isDashing)
        //{
        //    Dash();
        //    rb.velocity = rb.velocity + new Vector2(0, -dash_power);
        //    isGrounded = false;
        //    dashes--;
        //    Invoke("Stop_dash", stop);
        //    Invoke("Enable_gravity", coyote);
        //    Invoke("Disable_pause", coyote);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow) && dashes > 0 && !isGrounded && !isDashing)
        //{
        //    animator.SetBool("isDashingRightUp", true);


        //    Dash();
        //    rb.velocity = new Vector2(0, 0);
        //    rb.velocity = rb.velocity + new Vector2(dash_power, 0) * 1.1f;
        //    isGrounded = false;
        //    dashes--;
        //    Invoke("Stop_dash", stop);
        //    Invoke("Enable_gravity", coyote);
        //    Invoke("Disable_pause", coyote);
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) && dashes > 0 && !isGrounded && !isDashing)
        //{

        //    animator.SetBool("isDashingLeftUp", true);

        //    Dash();
        //    rb.velocity = new Vector2(0, 0);
        //    rb.velocity = rb.velocity + new Vector2(-dash_power, 0) * 1.1f;
        //    isGrounded = false;
        //    dashes--;
        //    Invoke("Stop_dash", stop);
        //    Invoke("Enable_gravity", coyote);
        //    Invoke("Disable_pause", coyote);
        //}
    }

    private void Dash()
    {
        Vector2 dir = Vector2.zero;
        if(Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }



      //  if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
      //  {
      //    
      //  }
        if(dir != Vector2.zero)
        {
            DoDash();
            DashAnim(dir);
        }
    }

    private void DashAnim(Vector2 v)
    {
        animator.SetBool("isDashingUp", false);
        animator.SetBool("isDashingLeft", false);
        animator.SetBool("isDashingRight", false);
        animator.SetBool("isDashingDown", false);
        if (v.y == 1)
        {
             animator.SetBool("isDashingUp", true);
        }
        if(v.y == -1)
        {
            animator.SetBool("isDashingDown", true);
        }
        if (v.x == -1)
        {
            animator.SetBool("isDashingLeft", true);
        }
        if (v.x == 1)
        {
            animator.SetBool("isDashingRight", true);
        }

    }

    private void DoDash()
    {
        isDashing = true;
        dash_pause = true;
        CancelInvoke();
        rb.gravityScale = 0.0f;
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX, 0).normalized * dash_power;
        rb.velocity = new Vector2(dashX, dashY).normalized * dash_power;
        isGrounded = false;
        dashes--;
        Invoke("Stop_dash", stop);

        if (rb.velocity.x == 0)
        {
            Invoke("Enable_gravity", short_coyote);
            Invoke("Disable_pause", short_coyote);
            Debug.Log("short coyote");
        }
        else
        {
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
            Debug.Log("Long coyote");
        }
    }

    void Enable_gravity()
    {
        rb.gravityScale *= -1; ;
    }

    void Disable_pause()
    {
        dash_pause = false;
    }

    void Stop_dash()
    {
        isDashing = false;
        rb.velocity = new Vector2(velocityX, 0);
        animator.SetBool("isDashingUp", false);
        animator.SetBool("isDashingLeft", false);
        animator.SetBool("isDashingRight", false);
        animator.SetBool("isDashingDown", false);
    }

    private void MoveLeftAndRight()
    {
        float x = Input.GetAxisRaw("Horizontal");
        velocityX += x * acceleration * Time.deltaTime;
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (x == 0 || (x < 0 && velocityX > 0))
        {
            //velocityX *= 1 - deacceleration * Time.deltaTime;
            velocityX = 0;
        }

        rb.velocity = new Vector2(velocityX, rb.velocity.y);

        if (velocityX > 0 && isGrounded)
        {
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("Idle", false);
            animator.SetBool("isJumpingRight", false);
            animator.SetBool("isJumpingLeft", false);
        }
        if (velocityX < 0 && isGrounded)
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("IdleLeft", false);
            animator.SetBool("IdleRight", false);
            animator.SetBool("Idle", false);
            animator.SetBool("isJumpingRight", false);
            animator.SetBool("isJumpingLeft", false);

        }
        if (isGrounded && velocityX == 0)
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("IdleRight", true);
            animator.SetBool("isJumpingRight", false);
            animator.SetBool("isJumpingLeft", false);
        }
        if(velocityX > 0 && jumping)
        {
            animator.SetBool("isJumpingRight", true);
        }
        if (velocityX < 0 && jumping)
        {
            animator.SetBool("isJumpingLeft", true);
        }


    }

    private void GravityAdjust()
    {
        if (!overworld)
        {
            if (!reverse_gravity)
            {
                if (rb.velocity.y < 0)
                    rb.gravityScale = 2;
                else
                    rb.gravityScale = 1;
            }
            else
            {
                if (rb.velocity.y > 0)
                    rb.gravityScale = -2;
                else
                    rb.gravityScale = -1;
            }
        }
        else
        {
            if (rb.velocity.y < 0)
                rb.gravityScale = 2;
            else
                rb.gravityScale = 1;
        }
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
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if (!reverse_gravity)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            else
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            isGrounded = false;
            jumping = true;
            Invoke("Jump_stop", 0.2f);
        }
    }

    void Jump_stop()
    {
        jumping = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isDashing)
        {
            dashes = 1;
            other.gameObject.SetActive(false);
            if (!overworld)
            {
                reverse_gravity = !reverse_gravity;
            }
        }
        else if (other.tag == "Enemy" && !overworld)
        {
            transform.position = checkpoint;
            rb.velocity = new Vector2(0, 0);
        }
        if (other.tag == "Checkpoint")
        {
            checkpoint = transform.position;
        }

    }

}
