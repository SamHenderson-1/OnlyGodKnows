using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private GameObject cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    //private SAInputs saInputs;
    //private SAInputs.PlayerActions playerActions;

    //private void Awake()
    //{
    //    playerActions = saInputs.Player;
    //}

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        playerUI = GetComponent<PlayerUI>();

    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(transform.position + new Vector3(0, 1, 0), cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask)) 
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                //if() 
                //{ 
                //    interactable.BaseInteract();
                //}
            }
        }

    }
}
