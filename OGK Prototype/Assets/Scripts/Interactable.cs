
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    private GameObject interactedObject;
    public Text PopupText;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactionDistance))
        {
            interactedObject = hit.collider.gameObject;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacting");
                if (PopupText != null)
                {
                    PopupText.text = "Interacting with " + interactedObject.name;
                }
            }
        }
        else
        {
            interactedObject = null;
            if (PopupText != null)
            {
                PopupText.text = "";
            }
        }
    }
}
