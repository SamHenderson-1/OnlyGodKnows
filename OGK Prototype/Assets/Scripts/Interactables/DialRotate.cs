using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    public bool upOrDown;
    private int numberShown;
    Transform wheel;

    // Start is called before the first frame update
    void Start()
    {
        numberShown = 5;
        wheel = transform;
    }

    private IEnumerator RotateWheel() 
    { 
        for (int i = 0; i <= 10; i++) 
        {
            if(upOrDown)
                wheel.Rotate(0f, 0f, 3f);
            else
                wheel.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.01f);
        }

        if(upOrDown)
            numberShown += 1;
        else
            numberShown -= 1;

        if (numberShown >= 9)
            numberShown = 0;

        if (numberShown <= 0)
            numberShown = 9;

        Rotated(name, numberShown);
    }

    public void RotateHelper()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
            upOrDown = true;
        if (Mouse.current.rightButton.wasPressedThisFrame)
            upOrDown = false;
        StartCoroutine("RotateWheel");
    }
}
