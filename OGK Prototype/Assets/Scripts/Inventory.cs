using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler onItemListChanged;

    private List<Item> itemList;

    public Inventory() 
    {
        itemList = new List<Item>();
        Debug.Log("Inventory");
        AddItem(new Item { itemType = Item.ItemType.Key, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Medicine, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Ammo, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item) 
    { 
        itemList.Add(item);
    }

    public List<Item> GetItems() 
    { 
        return itemList;
    }
}
