using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMob : MonoBehaviour
{
    private Vector3 _startPosition;
    float sinkingspeed = 1;

    
    float NewYPos;
    bool sinking = false;

    void Start()
    {
        _startPosition = transform.position;
        
    }

    void Update()
    {

        _startPosition.y = NewYPos;
        if (!sinking)
            transform.position = _startPosition + new Vector3(0f, MathF.Sin(Time.time), 0.0f);
        else if (sinking)
            transform.position = transform.position + new Vector3(0, -1f, 0) * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player") && Movement.overworld == false)
        {
            sinking = true;
            Invoke("stop_sinking", 5);
            //NewYPos = _startPosition.y - 0.09f * sinkingspeed;
            //transform.position = new Vector3(_startPosition.x, NewYPos, _startPosition.z);

        }


    }

    void stop_sinking()
    {
        sinking = false;
    }
}
