using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        Debug.Log("Inventory Refresh");
        int x = 0;
        int y = 0;
        float itemSlotCollSize = 75f;
        foreach (Item item in inventory.GetItems()) //make more efficient in future
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);


            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCollSize, y * itemSlotCollSize);
            Image image = itemSlotRectTransform.Find("itemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
