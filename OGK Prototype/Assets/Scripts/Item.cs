using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Item 
{
    public enum ItemType
    {
        None,
        Key,
        Medicine,
        Ammo,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() 
    { 
        switch (itemType) 
        { 
            default:
            case ItemType.Key: return ItemAssets.Instance.keySprite;
            case ItemType.Medicine: return ItemAssets.Instance.medicineSprite;
            case ItemType.Ammo: return ItemAssets.Instance.ammoSprite;

        }
    }

    public Material GetMaterial() 
    {
        switch (itemType)
        {
            default:
            case ItemType.Key: return ItemAssets.Instance.keyMaterial;
            case ItemType.Medicine: return ItemAssets.Instance.medicineMaterial;
            case ItemType.Ammo: return ItemAssets.Instance.ammoMaterial;

        }
    }
}
