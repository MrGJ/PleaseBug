using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypePotionOne : Items
{
    Unit unit;

    public int potionPotency;

    public override void Use()
    {
        unit.currentHP += potionPotency;
    }
}
