using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMob : MonoBehaviour
{
    private Vector3 _startPosition;
   
    float playerSinking;
    float NewYPos;

    void Start()
    {
        _startPosition = transform.position;
        
    }

    void Update()
    {

        _startPosition.y = NewYPos;
       //transform.position = new Vector3(_startPosition.x, sinkPosition, _startPosition.y);
      
       // sinkPosition -= _startPosition.y * sinkDepth * Time.deltaTime; 
           

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            NewYPos = _startPosition.y - 0.5f;
            transform.position = new Vector3(_startPosition.x, NewYPos, _startPosition.z);

        }
        else
        {
            transform.position = _startPosition + new Vector3(0f, MathF.Sin(Time.time), 0.0f);
        }


    }


}
