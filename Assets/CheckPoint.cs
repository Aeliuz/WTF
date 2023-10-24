using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
  //detta ska va referensen till gameobjektet som sparar spelaren last checkpoint
    private CheckPointObject player; 
   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("tag p� checkpoint object ").GetComponent<CheckPointObject>();  //h�mtar checkpoint game object
        transform.position = player.lastCheckPointPos;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            player.lastCheckPointPos = transform.position;
        }


    }

    public void Update()
    {
        //h�r ska scenen reloada till spelarens n�rmsta checkpoint efter att den d�r 
    }


}
