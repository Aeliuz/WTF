using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D rb;
    int dashes = 500;
    public int dash_power = 10;
    public float coyote = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && dashes > 0)
        {
            CancelInvoke();
            rb.gravityScale = 0.0f;
            rb.velocity = rb.velocity + new Vector2(0, dash_power);
            dashes--;
            Invoke("Stop_dash", 0.1f);
            Invoke("Enable_gravity", coyote);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && dashes > 0)
        {
            CancelInvoke();
            rb.gravityScale = 0.0f;
            rb.velocity = rb.velocity + new Vector2(0, -dash_power);
            dashes--;
            Invoke("Stop_dash", 0.1f);
            Invoke("Enable_gravity", coyote);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && dashes > 0)
        {
            CancelInvoke();
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(dash_power, 0);
            dashes--;
            Invoke("Stop_dash", 0.1f);
            Invoke("Enable_gravity", coyote);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && dashes > 0)
        {
            CancelInvoke();
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(0, 0);
            rb.velocity = rb.velocity + new Vector2(-dash_power, 0);
            dashes--;
            Invoke("Stop_dash", 0.1f);
            Invoke("Enable_gravity", coyote);
        }


    }
    void Enable_gravity()
    {
        rb.gravityScale = 1.0f;
    }

    void Stop_dash()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
