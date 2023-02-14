using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private List<Transform> npcList;
    float interactRange = 2f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                    interactable.Interact(transform);
            }
        }
    }

    public NPCInteractable GetInteractableObject()
    {
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>();
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                npcInteractableList.Add(npcInteractable); 
        }
        
        NPCInteractable closestNPCInteractable = null;
        foreach (NPCInteractable npcInteractable in npcInteractableList)
        {
            if (closestNPCInteractable == null)
                closestNPCInteractable = npcInteractable;
            else 
            {
                if (Vector3.Distance(transform.position, npcInteractable.transform.position) <
                    Vector3.Distance(transform.position, closestNPCInteractable.transform.position)) 
                    closestNPCInteractable = npcInteractable;
            }
        }
        return closestNPCInteractable;
    }
}
