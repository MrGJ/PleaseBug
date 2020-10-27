using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS A TEST SCRIPT WILL BE CHANGED SOON

public class ItemPickupByGod : MonoBehaviour
{

    public Items item;

    //
    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            PickUp();
        }

    }

    //Adds pickup functionality
    void PickUp()
    {
        Debug.Log("God went and nicked my " + item.name + "!");
        bool didGood = Inventory.instance.Add(item);
        if (didGood)
        {
            Destroy(gameObject);
        }
    }
}
