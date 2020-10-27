using UnityEngine;

public enum ItemType { WEAPON, ARMOUR, QUEST, GENITEM, CURRENCY}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{

    new public string name = "ItemName";
    public Sprite invIcon = null;
    public bool isDefault = false;
    public ItemType type;

    public virtual void Use()
    {
        Debug.Log("I presume something may happen my fren");
    }

}
