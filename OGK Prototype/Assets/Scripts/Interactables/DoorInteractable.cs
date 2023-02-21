using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteractable : Interactable, IDoor
{
    [SerializeField]
    private TextMeshProUGUI doorText;
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    protected override void Interact()
    {
        ToggleDoor();
    }

    public void ToggleDoor()
    {
        Debug.Log("Door Open");

        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);


    }
}
