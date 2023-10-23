using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce = 6f;
    bool isGrounded;

    public float maxSpeed = 7;
    public float acceleration = 30;
    public float deacceleration = 4;
    public float coyote = 0.4f;
    public float stop = 0.1f;
    public int dash_power = 10;
    public int dashes = 5;

    float velocityX;
    bool dash_pause = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Debug.Log("grounded");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && dashes > 0 && !isGrounded)
        {
            dash_pause = true;
            CancelInvoke();
            rb.gravityScale = 0.0f;
            rb.velocity = rb.velocity + new Vector2(0, dash_power);
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && dashes > 0 && !isGrounded)
        {
            CancelInvoke();
            dash_pause = true;
            rb.gravityScale = 0.0f;
            rb.velocity = rb.velocity + new Vector2(0, -dash_power);
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && dashes > 0 && !isGrounded)
        {
            CancelInvoke();
            dash_pause = true;
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(dash_power, 0);
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && dashes > 0 && !isGrounded)
        {
            CancelInvoke(); 
            dash_pause = true;
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(-dash_power, 0);
            isGrounded = false;
            dashes--;
            Invoke("Stop_dash", stop);
            Invoke("Enable_gravity", coyote);
            Invoke("Disable_pause", coyote);
        }
    }

    void Enable_gravity()
    {
        rb.gravityScale = 1.0f;
    }

    void Disable_pause()
    {
        dash_pause = false;
    }

    void Stop_dash()
    {
        rb.velocity = new Vector2(velocityX, 0);
    }

    private void MoveLeftAndRight()
    {
        float x = Input.GetAxisRaw("Horizontal");
        velocityX += x * acceleration * Time.deltaTime;
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (x == 0 || (x < 0 && velocityX > 0))
        {
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void GravityAdjust()
    {
        if (rb.velocity.y < 0)
            rb.gravityScale = 2;
        else
            rb.gravityScale = 1;
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
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

    }

}
