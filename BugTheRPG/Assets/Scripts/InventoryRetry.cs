using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRetry : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedRingADing;
    public List<Items> playerInv = new List<Items>();
    public List<Items> rMarketInv = new List<Items>();
    public List<Items> bMarketInv = new List<Items>();
    public int baseSpace = 27;

    public int playerCash;
    public int rMarketCash;
    public int bMarketCash;

    public bool AddPInv(Items item)
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

    public bool AddRInv(Items item)
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

    public bool AddBInv(Items item)
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

    public void DeletePInv(Items item)
    {
        bMarketInv.Remove(item);
        onItemChangedRingADing.Invoke();
    }

    public void Buy()
    {

    }

}
