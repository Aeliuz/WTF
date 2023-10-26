using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spriteRenderer.enabled = true;
            spriteRenderer.GetComponentInChildren<SpriteRenderer>().enabled = true;
            audioSource.Play();
        }

        Invoke("Disappear", 2f);
    }


    void Disappear()
    {
        spriteRenderer.enabled = false;
    }

}
