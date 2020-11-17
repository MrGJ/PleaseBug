using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsPDaddy;
    public Transform itemsRDaddy;
    public Transform itemsBDaddy;
    public GameObject inventoryPToggle;
    public GameObject inventoryRToggle;
    public GameObject inventoryBToggle;

    public InventoryRetry inventory;

    InventorySlot[] playerSlots;
    InventorySlot[] rMarketSlots;
    InventorySlot[] bMarketSlots;

    // Start is called before the first frame update
    void Start()
    {
        
        inventory.onItemChangedRingADing += UpdatePUI;
        inventory.onItemChangedRingADing += UpdateRUI;
        inventory.onItemChangedRingADing += UpdateBUI;

        playerSlots = itemsPDaddy.GetComponentsInChildren<InventorySlot>();
        rMarketSlots = itemsRDaddy.GetComponentsInChildren<InventorySlot>();
        bMarketSlots = itemsBDaddy.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            inventoryPToggle.SetActive(!inventoryPToggle.activeSelf);
        }
    }

    //Updates Inventory UI to represent Items the player has
    void UpdatePUI()
    {
        Debug.Log("INVFIDDLING");
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (i < inventory.playerInv.Count)
            {
                playerSlots[i].AddItem(inventory.playerInv[i]);
            }
            else 
            {
                playerSlots[i].RemoveItem();
            }
        }
    }

    void UpdateRUI()
    {
        Debug.Log("RINVFIDDLING");
        for (int i = 0; i < rMarketSlots.Length; i++)
        {
            if (i < inventory.rMarketInv.Count)
            {
                rMarketSlots[i].AddItem(inventory.rMarketInv[i]);
            }
            else
            {
                rMarketSlots[i].RemoveItem();
            }
        }
    }

    void UpdateBUI()
    {
        Debug.Log("BINVFIDDLING");
        for (int i = 0; i < bMarketSlots.Length; i++)
        {
            if (i < inventory.bMarketInv.Count)
            {
                bMarketSlots[i].AddItem(inventory.bMarketInv[i]);
            }
            else
            {
                bMarketSlots[i].RemoveItem();
            }
        }
    }

}
