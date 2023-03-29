using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using StarterAssets;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private FirstPersonController player;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetPlayer(FirstPersonController player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;

        inventory.onItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue; 
            Destroy(child.gameObject);
        }
        Debug.Log("Inventory Refresh");
        int x = 0;
        int y = 0;
        float itemSlotCollSize = 75f;
        foreach (Item item in inventory.GetItems()) //make more efficient in future
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //Use Item
            };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                //Drop Item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount};
                inventory.RemoveItem(item);
                ItemWorldSpawner.DropItem(player.GetPosition(), item);
            };
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCollSize, y * itemSlotCollSize);
            Image image = itemSlotRectTransform.Find("itemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) 
                uiText.SetText(item.amount.ToString());
            else
                uiText.SetText("");

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
