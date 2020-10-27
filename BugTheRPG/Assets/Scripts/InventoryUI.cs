using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsDaddy;
    public GameObject inventoryToggle;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedRingADing += UpdateUI;

        slots = itemsDaddy.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            inventoryToggle.SetActive(!inventoryToggle.activeSelf);
        }
    }

    void UpdateUI()
    {
        Debug.Log("INVFIDDLING");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else 
            {
                slots[i].RemoveItem();
            }
        }
    }

    
}
