using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Flibbitingleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Flibbity Jibbity you guys");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedRingADing;

    public int space = 2;

    public List<Items> items = new List<Items>();


    //Adds item to item list(needs id functionality)
    public bool Add(Items item)
    {
        if (!item.isDefault)
        {
            if (items.Count >= space)
            {
                Debug.Log("NO SACK ROOM");
                return false;
            }
            items.Add(item);
            onItemChangedRingADing.Invoke();
        }
        return true;
    }

    //Deletes item from item list
    public void Delete(Items item)
    {
        items.Remove(item);
        onItemChangedRingADing.Invoke();
    }
}
