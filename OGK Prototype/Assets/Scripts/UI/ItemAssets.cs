using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite keySprite;
    public Sprite medicineSprite;
    public Sprite ammoSprite;
    public Material keyMaterial;
    public Material medicineMaterial;
    public Material ammoMaterial;
}
