using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inspectable : Interactable
{
    [SerializeField]
    private TextMeshProUGUI inspectionText;
    [SerializeField]
    private Vector3 cameraPosition;
    [SerializeField]
    private Quaternion cameraRotation;

    protected override void Interact()
    {
        Collider objectCollider = GetComponent<Collider>();
        Item3DViewer inspectedObject = FindObjectOfType<Item3DViewer>();
        inspectedObject.OnItemSelected(cameraPosition, cameraRotation, objectCollider);
    }
}
