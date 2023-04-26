using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteractable : Interactable, IDoor
{
    private string doorText;
    [SerializeField]
    private string lockText;
    [SerializeField]
    private Vector3 teleportLocation;
    [SerializeField]
    private Vector3 exitLocation;
    [SerializeField]
    private Quaternion teleportRotation;
    [SerializeField]
    private Quaternion exitRotation;
    private bool doorOpen;
    private bool entered = false;
    [SerializeField]
    public LockControl lockControl;

    FirstPersonController playerController;

    void Start() 
    { 
        playerController = GameObject.FindWithTag("Player").transform.GetComponent<FirstPersonController>();
        if (lockControl != null)
        {
            lockControl.lockState = true;
            Debug.Log(lockControl.lockState);
            doorText = promptMessage;
        }
    }

    protected override void Interact()
    {
        if (lockControl != null && lockControl.lockState == true)
            promptMessage = lockText;
        else
        {
            promptMessage = doorText;
            ToggleDoor();
        }
        TakeNote();
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
        if (!entered)
        {
            playerController.gameObject.transform.position = teleportLocation;
            playerController.gameObject.transform.rotation = teleportRotation;

        }
        else
        {
            playerController.gameObject.transform.position = exitLocation;
            playerController.gameObject.transform.rotation = exitRotation;
        }
        yield return new WaitForSeconds(0.5f);
        playerController.disabled = false;
        entered = !entered;
    }
}
