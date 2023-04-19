using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSwapper : MonoBehaviour
{
    private TerrainChecker checker;
    private FirstPersonController controller;
    private string currentLayer;
    // Start is called before the first frame update
    void Start()
    {
        checker = new TerrainChecker();
        controller = GetComponent<FirstPersonController>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
