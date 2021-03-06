﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassSelect { TANK, DPSMELEE, DPSRANGED, DPSMAGIC, HEALER, ENEMYBASE, ENEMYTANK, ENEMYMELEE, ENEMYRANGED, ENEMYMAGIC, ENEMYHEALER, BOSS, TEACHER}

public class UnitWLevelling : MonoBehaviour
{
    //Basic Unit attributes
    public string unitName;
    public Sprite unitImg;
    public ClassSelect unitClass;
    public bool unitIsMagic;
    public bool unitIsDead;
    //Unit Stats
    [Range(0, 1000)] public int unitLevel = 1;
    public int unitExp;
    public int unitReqExp = 100;
    [Range(0, 10000)] public int unitAttack;
    [Range(0, 10000)] public int unitRes;
    [Range(0, 10000)] public int unitDef;
    public int unitMaxHP = 100;
    [Range(0, 10000)] public int unitCurrentHP;
    public int unitMaxMP = 100;
    [Range(0, 10000)] public int unitCurrentMP;
    public int unitExpGainedOnDeath;

    
    //Is called to level the unit.
    public void UnitLevelling(UnitWLevelling unitParty, UnitWLevelling unit)
    {
        unitParty.unitExp += unit.unitExpGainedOnDeath;

        if(unitParty.unitExp >= unitParty.unitReqExp)
        {
            unitParty.unitLevel += 1;

            unitParty.unitReqExp += (unitParty.unitReqExp / 4) + unitParty.unitReqExp;
            StatDistribution(unitParty);
        }

    }

    public void StatDistribution(UnitWLevelling unit)
    {
        if(unit.unitClass == ClassSelect.TANK)
        {

            unit.unitAttack += (unit.unitAttack / 10);
            unit.unitRes = Mathf.RoundToInt(unit.unitRes * 1.18f);
            unit.unitDef = Mathf.RoundToInt(unit.unitDef * 1.2f);
            unit.unitMaxHP += ((unit.unitMaxHP / 10) + 5);
        }
        else if (unit.unitClass == ClassSelect.DPSMELEE)
        {

            unit.unitAttack += (unit.unitAttack / 7);
            unit.unitRes = Mathf.RoundToInt(unit.unitRes * 1.18f);
            unit.unitDef = Mathf.RoundToInt(unit.unitDef * 1.2f);
            unit.unitMaxHP += ((unit.unitMaxHP / 15) + 5);
        }
        else if (unit.unitClass == ClassSelect.DPSRANGED)
        {
            unit.unitAttack += (unit.unitAttack / 7);
            unit.unitRes = Mathf.RoundToInt(unit.unitRes * 1.2f);
            unit.unitDef = Mathf.RoundToInt(unit.unitDef * 1.18f);
            unit.unitMaxHP += ((unit.unitMaxHP / 15) + 5);
        }
        else if (unitClass == ClassSelect.DPSMAGIC)
        {
            unit.unitAttack += (unit.unitAttack / 7);
            unit.unitRes = Mathf.RoundToInt(unit.unitRes * 1.2f);
            unit.unitDef = Mathf.RoundToInt(unit.unitDef * 1.18f);
            unit.unitMaxHP += ((unit.unitMaxHP / 15) + 5);
        }
        else if (unit.unitClass == ClassSelect.HEALER)
        {
            unit.unitAttack += (unit.unitAttack / 8);
            unit.unitRes = Mathf.RoundToInt(unit.unitRes * 1.18f);
            unit.unitDef = Mathf.RoundToInt(unit.unitDef * 1.2f);
            unit.unitMaxHP += ((unit.unitMaxHP / 17) + 3);
        }
    }

    //RegDamage take functionality and checks if dead
    public bool TakeRegDamage(UnitWLevelling attacker, bool isSpec)
    {
        if (isSpec)
        {
            unitCurrentHP -= (Mathf.RoundToInt(attacker.unitAttack * 2f));
            attacker.unitCurrentMP -= 33;
        }
        else
        {
            if ((attacker.unitAttack - unitDef) <= 0)
            {
                unitCurrentHP -= 0;
            }
            else
            {
                unitCurrentHP -= (attacker.unitAttack - unitDef);
            }
        }

        if (unitCurrentHP <= 0)
        {
            unitIsDead = true;
            return true;
        }
        else
        {
            unitIsDead = false;
            return false;
        }
            
    }
    //MagDamage take functionality and checks if dead
    public bool TakeMagDamage(UnitWLevelling attacker, bool isSpec)
    {
        if (isSpec)
        {
            unitCurrentHP -= (Mathf.RoundToInt(attacker.unitAttack * 2f));
            attacker.unitCurrentMP -= 33;
        }
        else
        {
            if ((attacker.unitAttack - unitRes) <= 0)
            {
                unitCurrentHP -= 0;
            }
            else
            {
                unitCurrentHP -= (attacker.unitAttack - unitRes);
            }
            
        }

        if (unitCurrentHP <= 0)
        {
            unitIsDead = true;
            return true;
        }
        else
        {
            unitIsDead = false;
            return false;
        }

    }

    public bool HealDamage(UnitWLevelling p1, UnitWLevelling p2, UnitWLevelling p3)
    {
        unitCurrentHP += unitAttack;
        if (unitCurrentHP > unitMaxHP)
            unitCurrentHP = unitMaxHP;
        p1.unitCurrentHP += unitAttack;
        if (p1.unitCurrentHP > p1.unitMaxHP)
            p1.unitCurrentHP = p1.unitMaxHP;
        p2.unitCurrentHP += unitAttack;
        if (p2.unitCurrentHP > p2.unitMaxHP)
            p2.unitCurrentHP = p2.unitMaxHP;
        p3.unitCurrentHP += unitAttack;
        if (p3.unitCurrentHP > p3.unitMaxHP)
            p3.unitCurrentHP = p3.unitMaxHP;

        unitCurrentMP -= 33;

        if (unitCurrentHP <= 0)
        {
            unitIsDead = true;
            return true;
        }
        else
        {
            unitIsDead = false;
            return false;
        }

    }

    //Does Special Action
    public void SpecialAction(UnitWLevelling unit)
    {
        unit.unitCurrentHP += 25;
        if (unit.unitCurrentHP > unit.unitMaxHP)
            unit.unitCurrentHP = unit.unitMaxHP;
        unit.unitCurrentMP -= 50;

    }

    //Called to set enemy stats appropriately
    public void EnemyInit(UnitWLevelling unit)
    {
        if (unit.unitClass == ClassSelect.TEACHER)
        {
            unit.unitMaxHP = 1000;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 0;
            unit.unitAttack = 10;
            unit.unitDef = 100;
            unit.unitRes = 100;
        }
        else if (unit.unitLevel == 1)
        {
            unit.unitMaxHP = 100;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 100;
            unit.unitAttack = 20;
            unit.unitDef = 3;
            unit.unitRes = 2;
        }
        else if (unit.unitLevel == 2)
        {
            unit.unitMaxHP = 111;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 120;
            unit.unitAttack = 22;
            unit.unitDef = 4;
            unit.unitRes = 2;
        }
        else if (unit.unitLevel == 3)
        {
            unit.unitMaxHP = 123;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 144;
            unit.unitAttack = 24;
            unit.unitDef = 4;
            unit.unitRes = 3;
        }
        else if (unit.unitLevel == 4)
        {
            unit.unitMaxHP = 137;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 173;
            unit.unitAttack = 27;
            unit.unitDef = 5;
            unit.unitRes = 3;
        }
        else if (unit.unitLevel == 5)
        {
            unit.unitMaxHP = 152;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 207;
            unit.unitAttack = 29;
            unit.unitDef = 6;
            unit.unitRes = 4;
        }
        else if (unit.unitLevel == 6)
        {
            unit.unitMaxHP = 169;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 249;
            unit.unitAttack = 32;
            unit.unitDef = 7;
            unit.unitRes = 5;
        }
        else if (unit.unitLevel == 7)
        {
            unit.unitMaxHP = 188;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 299;
            unit.unitAttack = 35;
            unit.unitDef = 9;
            unit.unitRes = 6;
        }
        else if (unit.unitLevel == 8)
        {
            unit.unitMaxHP = 209;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 358;
            unit.unitAttack = 39;
            unit.unitDef = 10;
            unit.unitRes = 7;
        }
        else if (unit.unitLevel == 9)
        {
            unit.unitMaxHP = 232;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 430;
            unit.unitAttack = 43;
            unit.unitDef = 12;
            unit.unitRes = 9;
        }
        else if (unit.unitLevel == 10)
        {
            unit.unitMaxHP = 258;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 516;
            unit.unitAttack = 43;
            unit.unitDef = 14;
            unit.unitRes = 10;
        }
        else if (unit.unitLevel == 11)
        {
            unit.unitMaxHP = 287;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 619;
            unit.unitAttack = 52;
            unit.unitDef = 17;
            unit.unitRes = 12;
        }
        else if (unit.unitLevel == 12)
        {
            unit.unitMaxHP = 319;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 743;
            unit.unitAttack = 57;
            unit.unitDef = 20;
            unit.unitRes = 15;
        }
        else if (unit.unitLevel == 13)
        {
            unit.unitMaxHP = 354;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 891;
            unit.unitAttack = 63;
            unit.unitDef = 24;
            unit.unitRes = 18;
        }
        else if (unit.unitLevel == 14)
        {
            unit.unitMaxHP = 393;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 1070;
            unit.unitAttack = 69;
            unit.unitDef = 29;
            unit.unitRes = 21;
        }
        else if (unit.unitLevel == 15)
        {
            unit.unitMaxHP = 437;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 1283;
            unit.unitAttack = 76;
            unit.unitDef = 34;
            unit.unitRes = 26;
        }
        else if (unit.unitLevel == 16)
        {
            unit.unitMaxHP = 100;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 1541;
            unit.unitAttack = 84;
            unit.unitDef = 41;
            unit.unitRes = 31;
        }
        else if (unit.unitLevel == 17)
        {
            unit.unitMaxHP = 540;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 1849;
            unit.unitAttack = 92;
            unit.unitDef = 49;
            unit.unitRes = 37;
        }
        else if (unit.unitLevel == 18)
        {
            unit.unitMaxHP = 600;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 2219;
            unit.unitAttack = 101;
            unit.unitDef = 58;
            unit.unitRes = 44;
        }
        else if (unit.unitLevel == 19)
        {
            unit.unitMaxHP = 666;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 2662;
            unit.unitAttack = 110;
            unit.unitDef = 69;
            unit.unitRes = 53;
        }
        else if (unit.unitLevel == 20)
        {
            unit.unitMaxHP = 740;
            unit.unitCurrentHP = unitMaxHP;
            unit.unitExpGainedOnDeath = 13195;
            unit.unitAttack = 122;
            unit.unitDef = 81;
            unit.unitRes = 64;
        }
    }

}
