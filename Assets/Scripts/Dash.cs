using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down");
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
        }
    }
}
