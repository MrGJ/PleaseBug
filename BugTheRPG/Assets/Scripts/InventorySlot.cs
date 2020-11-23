
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button tossButton;
    Items item;
    InventoryRetry retry;
    public GameObject inventoryHolder;
    public GameObject itemMenu;


    private void Start()
    {
        retry = inventoryHolder.GetComponent<InventoryRetry>();
    }

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
        retry.PDelete(item);
    }

    //Decides What happens on slot click based on context
    public void SlotClick()
    {
        if (retry.isROpen)
        {
            if (gameObject.CompareTag("rSlot"))
            {
                retry.BuyFrom(item);
            }
            else if (gameObject.CompareTag("pSlot"))
            {
                retry.SellTo(item);
            }
        }
        else if (retry.isBOpen)
        {
            if (gameObject.CompareTag("rSlot"))
            {
                retry.BuyFrom(item);
            }
            else if (gameObject.CompareTag("pSlot"))
            {
                retry.SellTo(item);
            }
        }
        else
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        itemMenu.SetActive(true);
    }

    public void ItemSet(Unit unit)
    {
        item.unit = unit;
    }

    //Uses Item based on what type of item it is
    public void UseItem(Unit unitSet)
    {
        if (item != null)
        {
            ItemSet(unitSet);
            item.Use();
        }
    }
}
