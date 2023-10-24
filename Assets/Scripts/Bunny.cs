using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    GameObject bunny;

    // Start is called before the first frame update
    void Start()
    {
        bunny = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(true);
            Debug.Log("trigger");
        }
    }

}
