using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField] 
    private string dialogue;

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        Debug.Log(dialogue);
    }
}
