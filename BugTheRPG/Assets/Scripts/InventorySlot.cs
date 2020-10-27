
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button tossButton;
    Items item;

    //Takes information from picked up items to represent the item in inventory
    public void AddItem(Items newItem)
    {
        item = newItem;

        icon.sprite = item.invIcon;
        icon.enabled = true;
        tossButton.interactable = true;
    }

    //Deletes Item icon from inventory
    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        tossButton.interactable = false;
    }

    //Calls Inventory Delete Method
    public void Spitooey()
    {
        Inventory.instance.Delete(item);
    }

    //Uses Item based on what type of item it is
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
