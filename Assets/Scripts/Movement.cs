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
    public float stop = 0.1f;
    public int dash_power = 10;
    public int dashes = 5;

    public float delay = 3;
    float timer;

    float velocityX;
    float velX;
    bool dash_pause = false;
    bool reverse_gravity = false;
    public bool isDashing = false;


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

        if (isGrounded)
        {
            dashes = 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && dashes > 0 && !isDashing)
        {
            animator.SetBool("isDashingUp", true);


            Dash();
            velX = rb.velocity.x;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(velX, 0).normalized * dash_power;
                rb.velocity = rb.velocity + new Vector2(velX, dash_power).normalized * dash_power;
            }
            else
            {
                velocityX = 0;
                rb.velocity = new Vector2(0, 0);
                rb.velocity = rb.velocity + new Vector2(0, dash_power);
            }
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && dashes > 0 && !isGrounded && !isDashing)
        {
            Dash();
            rb.velocity = rb.velocity + new Vector2(0, -dash_power);
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && dashes > 0 && !isGrounded && !isDashing)
        {
            animator.SetBool("isDashingRightUp", true);


            Dash();
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(dash_power, 0) * 1.1f;
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && dashes > 0 && !isGrounded && !isDashing)
        {

            animator.SetBool("isDashingLeftUp", true);

            Dash();
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(-dash_power, 0) * 1.1f;
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
    }

    private void Dash()
    {
        isDashing = true;
        dash_pause = true;
        CancelInvoke();
        rb.gravityScale = 0.0f;
        //reverse_gravity = !reverse_gravity;
        //animator.SetBool("isDashingUp", true);
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
        animator.SetBool("isDashingLeftUp", false);
        animator.SetBool("isDashingRightUp", false);
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

        if(velocityX > 0) 
        {
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            //animator.Play("walking-right");
            Debug.Log("Den rör sig");
        }
        if (velocityX < 0)
        {
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", true);
            
        }
    }

    private void GravityAdjust()
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Jump()
    {
        if (isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && isDashing)
        {
            dashes = 1;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Enemy")
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
