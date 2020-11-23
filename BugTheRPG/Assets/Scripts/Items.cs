using UnityEngine;

public enum ItemType { WEAPON, ARMOUR, QUEST, GENITEM, POTIONONE, POTIONTWO, CURRENCY}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{

    [Tooltip("Assign display name")] new public string name = "ItemName";
    [Tooltip("Assign object's Mesh")] public Mesh itemMesh;
    [Tooltip("Assign object's Material")] public Material itemMaterial;
    [Tooltip("Assign object's UI sprite")] public Sprite invIcon = null;
    public bool isDefault = false;
    public ItemType type;
    [Tooltip("Use common sense to decide this")] public int itemBuyVal;
    [Tooltip("This too")] public int itemSellVal;
    [HideInInspector] public Unit unit;

    //Uses item
    public virtual void Use()
    {
        Debug.Log("I presume something may happen my fren");
    }

}
