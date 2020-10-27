
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button tossButton;
    Items item;

    //Is Called in a different script. Add functionality for inventory slots
    public void AddItem(Items newItem)
    {
        item = newItem;

        icon.sprite = item.invIcon;
        icon.enabled = true;
        tossButton.interactable = true;
    }

    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        tossButton.interactable = false;
    }

    public void Spitooey()
    {
        Inventory.instance.Delete(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
