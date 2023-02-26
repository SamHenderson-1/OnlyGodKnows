using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable, IDoor
{
    private bool closed = true;


    public string GetInteractText()
    {
        return "Open/Close Door";
    }

    public void Interact(Transform interactorTransform)
    {
        ToggleDoor();
    }

    public void ToggleDoor()
    {
        Debug.Log("Door Open");
        closed = !closed;
        gameObject.SetActive(closed);

        
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
