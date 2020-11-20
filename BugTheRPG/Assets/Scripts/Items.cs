using UnityEngine;

public enum ItemType { WEAPON, ARMOUR, QUEST, GENITEM, POTIONONE, POTIONTWO, CURRENCY}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{

    new public string name = "ItemName";
    public Sprite invIcon = null;
    public bool isDefault = false;
    public ItemType type;
    public int itemBuyVal;
    public int itemSellVal;
    public GameObject self;

    void Start()
    {
        
        if (type == ItemType.WEAPON)
        {
            self.AddComponent(System.Type.GetType("ItemTypeWeapon"));
        }
        else if (type == ItemType.ARMOUR)
        {
            self.AddComponent(System.Type.GetType("ItemTypeArmour"));
        }
        else if (type == ItemType.QUEST)
        {
            self.AddComponent(System.Type.GetType("ItemTypeQuest"));
        }
        else if (type == ItemType.GENITEM)
        {
            self.AddComponent(System.Type.GetType("ItemTypeGenItem"));
        }
        else if (type == ItemType.POTIONONE)
        {
            self.AddComponent(System.Type.GetType("ItemTypePotionOne"));
        }
        else if (type == ItemType.POTIONTWO)
        {
            self.AddComponent(System.Type.GetType("ItemTypePotionTwo"));
        }
        else if (type == ItemType.CURRENCY)
        {
            self.AddComponent(System.Type.GetType("ItemTypeCurrency"));
        }
    }

    //Uses item
    public virtual void Use()
    {
        Debug.Log("I presume something may happen my fren");
    }

}
