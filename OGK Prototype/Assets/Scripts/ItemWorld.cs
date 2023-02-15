using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour, IInteractable
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

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetItem(Item item) 
    { 
        this.item = item;
        meshRenderer.material = item.GetMaterial();

    }

    public void Interact(Transform interactorTransform)
    {
        DestroySelf();
    }

    public string GetInteractText()
    {
        throw new System.NotImplementedException();
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public Item GetItem() { 
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
