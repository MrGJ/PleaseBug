using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRetry : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedRingADing;

    public int baseSpace = 2;

    public List<Items> playerInv = new List<Items>();
    public List<Items> rMarketInv = new List<Items>();
    public List<Items> bMarketInv = new List<Items>();


    //Adds item to item list(needs id functionality)
    public bool PAdd(Items item)
    {
        if (!item.isDefault)
        {
            if (playerInv.Count >= baseSpace)
            {
                Debug.Log("NO SACK ROOM");
                return false;
            }
            playerInv.Add(item);
            onItemChangedRingADing.Invoke();
        }
        return true;
    }

    //Deletes item from Player's item list
    public void PDelete(Items item)
    {
        playerInv.Remove(item);
        onItemChangedRingADing.Invoke();
    }

    //Adds item to item list(needs id functionality)
    public bool RAdd(Items item)
    {
        if (!item.isDefault)
        {
            if (rMarketInv.Count >= baseSpace)
            {
                Debug.Log("NO SACK ROOM");
                return false;
            }
            rMarketInv.Add(item);
            onItemChangedRingADing.Invoke();
        }
        return true;
    }

    //Deletes item from Player's item list
    public void RDelete(Items item)
    {
        rMarketInv.Remove(item);
        onItemChangedRingADing.Invoke();
    }

    //Adds item to item list(needs id functionality)
    public bool BAdd(Items item)
    {
        if (!item.isDefault)
        {
            if (bMarketInv.Count >= baseSpace)
            {
                Debug.Log("NO SACK ROOM");
                return false;
            }
            bMarketInv.Add(item);
            onItemChangedRingADing.Invoke();
        }
        return true;
    }

    //Deletes item from Player's item list
    public void BDelete(Items item)
    {
        bMarketInv.Remove(item);
        onItemChangedRingADing.Invoke();
    }
}
