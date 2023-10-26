using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuBunny : MonoBehaviour
{
  

    public SpriteRenderer bunny;



    private void Start()
    {
        bunny = GetComponent<SpriteRenderer>();
        int whenShow = Random.Range(1, 17);
        ShowBunny();

    }

    private void Update()
    {
    //   Invoke("ShowBunny", 4);
    //   Invoke("HideBunny", 5);
    }

    void ShowBunny()
    {
        bunny.enabled = true;
        Invoke("HideBunny", 1);
    }

    void HideBunny()
    {
        bunny.enabled = false;
        Invoke("ShowBunny", 1);
    }

}


