using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class LockControl : MonoBehaviour
{
    private int[] result;
    [SerializeField]
    private int[] correctCombination;
    public bool lockState;

    // Start is called before the first frame update
    void Start()
    {
        result = new int[] { 5, 5, 5 };
        DialRotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number) 
    {
        switch (wheelName) 
        {
            case "wheel1":
                result[0] = number; break;

            case "wheel2":
                result[1] = number; break;

            case "wheel3":
                result[2] = number; break;
        }
        for(int i = 0; i < result.Length; i++)
            Debug.Log(result[i]);
        if (Enumerable.SequenceEqual(result, correctCombination)) 
        {
            Debug.Log("Opened!");
            lockState = false;
        }
    }

    private void OnDestroy()
    {
        DialRotate.Rotated -= CheckResults;
    }
}
