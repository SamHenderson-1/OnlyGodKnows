using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : Interactable
{ 
    private Item item;
    private MeshRenderer meshRenderer;
    FirstPersonController playerController;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").transform.GetComponent<FirstPersonController>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        meshRenderer.material = item.GetMaterial();
    }

    protected override void Interact()
    {
            playerController.inventory.AddItem(this.GetItem());
            this.DestroySelf();
    }

    public Item GetItem() { 
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
