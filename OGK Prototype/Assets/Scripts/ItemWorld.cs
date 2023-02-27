using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : Interactable
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) 
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

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

    //protected override void Interact()
    //{
    //    if (itemWorld != null)
    //    {
    //        playerController.inventory.AddItem(itemWorld.GetItem());
    //        itemWorld.DestroySelf();
    //    }
    //}

    public Item GetItem() { 
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
