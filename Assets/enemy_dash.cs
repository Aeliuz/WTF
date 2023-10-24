using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_dash : MonoBehaviour
{
    CircleCollider2D circleCollider;
    Rigidbody2D rb;

    Movement player;
    public GameObject enemyToRespawm;
    public Transform enemySpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Respawn();
        }
       
    }
    public void Respawn() //instantiera fienden
    {
        if (enemyToRespawm != null) 
        {
            Instantiate(enemyToRespawm, enemySpawnPoint.position, Quaternion.identity);

        }
       
       
    }


}
