using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypePotionOne : Items
{
    Unit unit1;

    public int potionPotency;

    public override void Use()
    {
        unit1.currentHP += potionPotency;
    }
}
