using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 1, 0), cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }

    }
}
