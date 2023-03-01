using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Item3DViewer : MonoBehaviour {

    private FirstPersonController player;
    private Transform itemPrefab;
    private Vector3 savedPosition;
    private Vector3 worldPos;
    //private GameObject camera;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.GetComponent<FirstPersonController>();
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        //camera = GameObject.FindWithTag("MainCamera");
    }

    public void OnItemSelected(Vector3 position, Quaternion rotation, Collider collider) {
        savedPosition = player.transform.position;
        player.disabled = true;
        player.transform.SetPositionAndRotation(position, rotation);
        collider.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        while (!Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenToWorldPoint(player.transform.position + new Vector3(0, 1, 0), worldPos);
            Debug.DrawRay(ray.origin, ray.direction * 100);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100, player.mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    player.playerUI.UpdateText(interactable.promptMessage);
                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        Debug.Log("Interacted");
                        interactable.BaseInteract();
                        player.playerUI.UpdateText("");
                    }
                }
            }
        }
        player.transform.SetPositionAndRotation(savedPosition, rotation);
        player.disabled = false;
        collider.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //camera.transform.position = position;
        //if (itemPrefab != null) {
        //    Destroy(itemPrefab.gameObject);
        //}
        //itemPrefab = Instantiate(itemSO.prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
    }
}