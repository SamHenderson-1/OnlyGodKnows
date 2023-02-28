using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        itemWorld.promptMessage = "Pick Up " + item.itemType.ToString();

        return itemWorld;
    }

    void Start()
    {
        SpawnItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
