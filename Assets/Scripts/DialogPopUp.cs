using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopUp : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.enabled = true;
        }

        Invoke("Disappear", 6.5f);
    }

    void Disappear()
    {
        spriteRenderer.enabled = false;
    }
}
