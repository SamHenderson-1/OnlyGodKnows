using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public FirstPersonController movement;

    private void OnTriggerEnter(Collider collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider) 
    {
        if (collider.CompareTag("Enemy"))
        {
            movement.disabled = true;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
