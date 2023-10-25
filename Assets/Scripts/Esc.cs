using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{

    void Update()
    {
        EscBackToMenue();
    }


    public void EscBackToMenue()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }   
    }
}
