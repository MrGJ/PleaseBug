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
    //Unit Stats
    public int unitLevel = 1;
    public int unitExp;
    public int unitReqExp = 100;
    public int unitAttack;
    public int unitRes;
    public int unitDef;
    public int unitMaxHP = 100;
    public int unitCurrentHP;
    public bool dead;

    public void UnitLevelling()
    {
        if(unitExp >= unitReqExp)
        {
            unitLevel += 1;
        }

    }

    public void StatDistribution()
    {
        if(unitClass == ClassSelect.TANK)
        {
            //unitReqExp = ;
            //unitAttack = ;
            //unitRes = ;
            //unitDef = ;
            //unitMaxHP = ;
        }
        else if (unitClass == ClassSelect.DPSMELEE)
        {
            //unitReqExp = ;
            //unitAttack = ;
            //unitRes = ;
            //unitDef = ;
            //unitMaxHP = ;
        }
        else if (unitClass == ClassSelect.DPSRANGED)
        {
            //unitReqExp = ;
            //unitAttack = ;
            //unitRes = ;
            //unitDef = ;
            //unitMaxHP = ;
        }
        else if (unitClass == ClassSelect.DPSMAGIC)
        {
            //unitReqExp = ;
            //unitAttack = ;
            //unitRes = ;
            //unitDef = ;
            //unitMaxHP = ;
        }
        else if (unitClass == ClassSelect.HEALER)
        {
            //unitReqExp = ;
            //unitAttack = ;
            //unitRes = ;
            //unitDef = ;
            //unitMaxHP = ;
        }
        

        
    }

    //MagDamage take functionality and checks if dead
    public bool TakeRegDamage(int dmg)
    {
        unitCurrentHP -= dmg;

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
    //RegDamage take functionality and checks if dead
    public bool TakeMagDamage(int dmg)
    {
        unitCurrentHP -= dmg;

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

}
