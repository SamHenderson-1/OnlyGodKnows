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
        //AddItem(new Item { itemType = Item.ItemType.Key, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Medicine, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Ammo, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item) 
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
                Debug.Log(inventoryItem.itemType + ": " + inventoryItem.amount);
            }
            if(!itemAlreadyInInventory)
                itemList.Add(item);
        }
        else
            itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemInInventory = inventoryItem;
                }
                Debug.Log(inventoryItem.itemType + ": " + inventoryItem.amount);
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
                itemList.Remove(itemInInventory);
        }
        else
            itemList.Add(item);
        onItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItems() 
    { 
        return itemList;
    }
}
