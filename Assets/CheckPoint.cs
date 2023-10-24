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
        player = GameObject.FindGameObjectWithTag("tag på checkpoint object ").GetComponent<CheckPointObject>();  //hämtar checkpoint game object
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
        //här ska scenen reloada till spelarens närmsta checkpoint efter att den dör 
    }


}
