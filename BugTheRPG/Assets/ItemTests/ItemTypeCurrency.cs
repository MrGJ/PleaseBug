using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypeCurrency : Items
{
    GameObject inventoryHolder;
    InventoryRetry retry;

    public override void Use()
    {
        inventoryHolder = GameObject.Find("GameSystem");
        retry = inventoryHolder.GetComponent<InventoryRetry>();
        retry.pCash += itemBuyVal;
    }
}
