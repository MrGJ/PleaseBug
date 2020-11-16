using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform playerDaddy;
    public Transform rMarketDaddy;
    public Transform bMarketDaddy;
    public GameObject inventoryToggle;
    public GameObject shopRToggle;
    public GameObject shopBToggle;

    InventoryRetry inventory;

    InventorySlot[] playerSlots;
    InventorySlot[] rMarketSlots;
    InventorySlot[] bMarketSlots;

    // Start is called before the first frame update
    void Start()
    {
        
        inventory.onItemChangedRingADing += UpdatePlayerUI;
        inventory.onItemChangedRingADing += UpdateRShopUI;
        inventory.onItemChangedRingADing += UpdateBShopUI;

        playerSlots = playerDaddy.GetComponentsInChildren<InventorySlot>();
        rMarketSlots = rMarketDaddy.GetComponentsInChildren<InventorySlot>();
        bMarketSlots = bMarketDaddy.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inv"))
        {
            inventoryToggle.SetActive(!inventoryToggle.activeSelf);
        }
    }

    //Updates Inventory UI to represent Items the player has
    void UpdatePlayerUI()
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

    //Updates Inventory UI to represent Items the player has
    void UpdateRShopUI()
    {
        Debug.Log("INVFIDDLING");
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

    //Updates Inventory UI to represent Items the player has
    void UpdateBShopUI()
    {
        Debug.Log("INVFIDDLING");
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
