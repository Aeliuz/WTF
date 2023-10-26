using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float lowestPosY = 0f;
    public float lowestPosX = 0f;

    void Update()
    {
        if (player.position.x <= lowestPosX && player.position.y <= lowestPosY)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        else if (player.position.y <= lowestPosY)
            transform.position = new Vector3(player.position.x, transform.position.y, -10);
        else if (player.position.x <= lowestPosX)
            transform.position = new Vector3(transform.position.x, player.position.y, -10);
        else
            transform.position = new Vector3(player.position.x, player.position.y, -10);
            
    }

}
