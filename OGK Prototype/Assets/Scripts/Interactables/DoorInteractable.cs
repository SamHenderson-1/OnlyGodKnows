using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteractable : Interactable, IDoor
{
    [SerializeField]
    private TextMeshProUGUI doorText;
    [SerializeField]
    private Vector3 teleportLocation;
    [SerializeField]
    private Vector3 exitLocation;
    private bool doorOpen;
    private bool entered = false;
    [SerializeField]
    private bool locked;
    [SerializeField]
    private DialRotate doorLock;

    FirstPersonController playerController;

    void Start() 
    { 
        playerController = GameObject.FindWithTag("Player").transform.GetComponent<FirstPersonController>();
    }

    protected override void Interact()
    {
        //if (locked)
        //    doorText = TMPro.TextMeshProUGUI.Equals("The door is locked.");
        //else
            ToggleDoor();
    }

    public void ToggleDoor()
    {
        doorOpen = !doorOpen;
        StartCoroutine("Teleport");
    }

    public IEnumerator Teleport()
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(0.5f); 
        if(!entered)
            playerController.gameObject.transform.position = teleportLocation;
        else
            playerController.gameObject.transform.position = exitLocation;
        yield return new WaitForSeconds(0.5f);
        playerController.disabled = false;
        entered = !entered;
    }
}
