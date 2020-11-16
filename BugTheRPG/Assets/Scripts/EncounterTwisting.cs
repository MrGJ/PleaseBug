using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTwisting : MonoBehaviour
{

    public GameObject battleCamera;
    public GameObject overworldCamera;
    public GameObject battleSysObject;
    public GameObject overworldSysObject;

    public OverworldSystem overworldSystem;
    public BattleSystemWLevelling battleSystem;

    void Start()
    {
        battleCamera.SetActive(false);
        overworldSystem = overworldSysObject.GetComponent<OverworldSystem>();
        battleSystem = battleSysObject.GetComponent<BattleSystemWLevelling>();
    }

    public void EncounterStart()
    {
        battleSystem.state = BattleStateWL.START;
        StartCoroutine(battleSystem.BattleInit());
        battleCamera.SetActive(true);
        overworldCamera.SetActive(false);
        SetStatOverToBattle(battleSystem.partyOneUnit, overworldSystem.partyOneUnit);
        SetStatOverToBattle(battleSystem.partyTwoUnit, overworldSystem.partyTwoUnit);
        SetStatOverToBattle(battleSystem.partyThreeUnit, overworldSystem.partyThreeUnit);
        SetStatOverToBattle(battleSystem.partyFourUnit, overworldSystem.partyFourUnit);
        SetStatOverToBattle(battleSystem.enemyUnit, overworldSystem.enemyUnit);
        Destroy(overworldSystem.enemyObj);
    }

    public void EncounterEnd()
    {
        overworldCamera.SetActive(true);
        battleCamera.SetActive(false);
        SetStatOverToBattle(battleSystem.partyOneUnit, overworldSystem.partyOneUnit);
        SetStatOverToBattle(battleSystem.partyTwoUnit, overworldSystem.partyTwoUnit);
        SetStatOverToBattle(battleSystem.partyThreeUnit, overworldSystem.partyThreeUnit);
        SetStatOverToBattle(battleSystem.partyFourUnit, overworldSystem.partyFourUnit);
        Debug.Log("Please");

    }

    public void SetStatOverToBattle(UnitWLevelling unitBattle, UnitWLevelling unitOverworld)
    {
        unitBattle.unitName = unitOverworld.unitName;
        if (unitOverworld.unitImg != null)
        { 
            unitBattle.unitImg = unitOverworld.unitImg; 
        }
        unitBattle.unitClass = unitOverworld.unitClass;
        unitBattle.unitIsMagic = unitOverworld.unitIsMagic;
        unitBattle.unitIsDead = unitOverworld.unitIsDead;
        unitBattle.unitLevel = unitOverworld.unitLevel;
        unitBattle.unitExp = unitOverworld.unitExp;
        unitBattle.unitReqExp = unitOverworld.unitReqExp;
        unitBattle.unitAttack = unitOverworld.unitAttack;
        unitBattle.unitRes = unitOverworld.unitRes;
        unitBattle.unitDef = unitOverworld.unitDef;
        unitBattle.unitMaxHP = unitOverworld.unitMaxHP;
        unitBattle.unitCurrentHP = unitOverworld.unitCurrentHP;
        unitBattle.unitExpGainedOnDeath = unitOverworld.unitExpGainedOnDeath;
    }

    public void SetStatBattleToOver(UnitWLevelling unitBattle, UnitWLevelling unitOverworld)
    {
        unitOverworld.unitName = unitBattle.unitName;
        unitOverworld.unitImg = unitBattle.unitImg;
        unitOverworld.unitClass = unitBattle.unitClass;
        unitOverworld.unitIsMagic = unitBattle.unitIsMagic;
        unitOverworld.unitIsDead = unitBattle.unitIsDead;
        unitOverworld.unitLevel = unitBattle.unitLevel;
        unitOverworld.unitExp = unitBattle.unitExp;
        unitOverworld.unitReqExp = unitBattle.unitReqExp;
        unitOverworld.unitAttack = unitBattle.unitAttack;
        unitOverworld.unitRes = unitBattle.unitRes;
        unitOverworld.unitDef = unitBattle.unitDef;
        unitOverworld.unitMaxHP = unitBattle.unitMaxHP;
        unitOverworld.unitCurrentHP = unitBattle.unitCurrentHP;
    }

}
