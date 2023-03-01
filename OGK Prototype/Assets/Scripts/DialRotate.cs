using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;
    Transform wheel;

    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        numberShown = 5;
        wheel = transform;
    }

    private void OnMouseDown()//Interact
    {
        if (coroutineAllowed) 
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel() 
    { 
        coroutineAllowed = false;

        for (int i = 0; i <= 10; i++) 
        {
            wheel.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9) 
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }
}
