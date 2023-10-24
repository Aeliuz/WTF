using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dash : MonoBehaviour
{
    CircleCollider2D circleCollider;
    Rigidbody2D rb;

    Movement player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("triggered");
    //    if (other.tag == "Player" && player.isDashing)
    //    {
    //        Debug.Log("triggered by player, killing self");
    //        player.dashes = 1;
    //    }
    //}

}
