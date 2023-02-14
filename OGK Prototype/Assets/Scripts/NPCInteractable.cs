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

    public void Interact() {
        Debug.Log("Interact!");
    }

    public void Interact(Transform interactorTransform)
    {
        throw new System.NotImplementedException();
    }
}
