using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]
public class ItemInitializer : MonoBehaviour
{
    [Tooltip("Place 'Items' Object in here. Magic will do the rest.")] public Items item;
    [HideInInspector] public MeshFilter itemFilter;
    [HideInInspector] public MeshCollider itemCollider;
    [HideInInspector] public MeshRenderer itemRenderer;

    // Start is called before the first frame update
    void Start()
    {
        itemCollider = GetComponent<MeshCollider>();
        itemFilter = GetComponent<MeshFilter>();
        itemRenderer = GetComponent<MeshRenderer>();

        itemFilter.mesh = item.itemMesh;
        itemCollider.sharedMesh = item.itemMesh;
        itemRenderer.sharedMaterial = item.itemMaterial;

        //Adds Appropriate 'Items' extention to gameObject
        if (item.type == ItemType.WEAPON)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypeWeapon"));
        }
        else if (item.type == ItemType.ARMOUR)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypeArmour"));
        }
        else if (item.type == ItemType.QUEST)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypeQuest"));
        }
        else if (item.type == ItemType.GENITEM)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypeGenItem"));
        }
        else if (item.type == ItemType.POTIONONE)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypePotionOne"));
        }
        else if (item.type == ItemType.POTIONTWO)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypePotionTwo"));
        }
        else if (item.type == ItemType.CURRENCY)
        {
            gameObject.AddComponent(System.Type.GetType("ItemTypeCurrency"));
        }
    }

    
}
