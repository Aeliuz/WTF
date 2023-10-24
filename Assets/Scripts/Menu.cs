using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
