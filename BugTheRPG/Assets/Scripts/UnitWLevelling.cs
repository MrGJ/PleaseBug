using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassSelect { TANK, DPSMELEE, DPSRANGED, DPSMAGIC, HEALER, ENEMY}

public class UnitWLevelling : MonoBehaviour
{
    //Basic Unit attributes
    public string unitName;
    public Sprite unitImg;
    public ClassSelect unitClass;
    public bool unitIsMagic;
    public bool dead;
    //Unit Stats
    public int unitLevel = 1;
    public int unitExp;
    public int unitReqExp = 100;
    public int unitAttack;
    public int unitRes;
    public int unitDef;
    public int unitMaxHP = 100;
    public int unitCurrentHP;

    
    //Is called to level the unit.
    public void UnitLevelling()
    {
        if(unitExp >= unitReqExp)
        {
            unitLevel += 1;
            
            unitReqExp += (unitReqExp / 4) + unitReqExp;
        }

    }

    public void StatDistribution()
    {
        if(unitClass == ClassSelect.TANK)
        {

            unitAttack += (unitAttack / 10);
            unitRes = Mathf.RoundToInt(unitRes * 1.18f);
            unitDef = Mathf.RoundToInt(unitDef * 1.2f);
            unitMaxHP += ((unitMaxHP / 10) + 5);
        }
        else if (unitClass == ClassSelect.DPSMELEE)
        {

            unitAttack += (unitAttack / 7);
            unitRes = Mathf.RoundToInt(unitRes * 1.18f);
            unitDef = Mathf.RoundToInt(unitDef * 1.2f);
            unitMaxHP += ((unitMaxHP / 15) + 5);
        }
        else if (unitClass == ClassSelect.DPSRANGED)
        {
            unitAttack += (unitAttack / 7);
            unitRes = Mathf.RoundToInt(unitRes * 1.2f);
            unitDef = Mathf.RoundToInt(unitDef * 1.18f);
            unitMaxHP += ((unitMaxHP / 15) + 5);
        }
        else if (unitClass == ClassSelect.DPSMAGIC)
        {
            unitAttack += (unitAttack / 7);
            unitRes = Mathf.RoundToInt(unitRes * 1.2f);
            unitDef = Mathf.RoundToInt(unitDef * 1.18f);
            unitMaxHP += ((unitMaxHP / 15) + 5);
        }
        else if (unitClass == ClassSelect.HEALER)
        {

            unitAttack += (unitAttack / 8);
            unitRes = Mathf.RoundToInt(unitRes * 1.18f);
            unitDef = Mathf.RoundToInt(unitDef * 1.2f);
            unitMaxHP += ((unitMaxHP / 17) + 3);
        }
    }

    //RegDamage take functionality and checks if dead
    public bool TakeRegDamage(UnitWLevelling attacker, bool isSpec)
    {
        if (isSpec)
        {
            unitCurrentHP -= (Mathf.RoundToInt(attacker.unitAttack * 1.3f) - unitDef);
        }
        else
        {
            unitCurrentHP -= (attacker.unitAttack - unitDef);
        }

        if (unitCurrentHP <= 0)
        {
            dead = true;
            return true;
        }
        else
        {
            dead = false;
            return false;
        }
            
    }
    //MagDamage take functionality and checks if dead
    public bool TakeMagDamage(UnitWLevelling attacker, bool isSpec)
    {
        if (isSpec)
        {
            unitCurrentHP -= (Mathf.RoundToInt(attacker.unitAttack * 1.3f) - unitRes);
        }
        else
        {
            unitCurrentHP -= (attacker.unitAttack - unitRes);
        }

        if (unitCurrentHP <= 0)
        {
            dead = true;
            return true;
        }
        else
        {
            dead = false;
            return false;
        }

    }

    //Does Special Action
    public void SpecialAction()
    {

    }

}
