using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;

    public string GetInteractText()
    {
        return interactText;
    }

    public void Interact(Transform interactorTransform)
    {
        Debug.Log("Interact!");
    }

    public Transform GetTransform() 
    {
        return transform;
    }
}
