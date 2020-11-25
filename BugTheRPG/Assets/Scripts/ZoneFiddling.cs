using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFiddling : MonoBehaviour
{
    public EncounterTwisting twisties;
    public BattleSystemWLevelling battleBits;

    public GameObject[] cameras;
    public Transform[] partyOnePlatform, partyTwoPlatform, partyThreePlatform, partyFourPlatform, enemyPlatform;
    public BattleHUDWLevelling[] partyOneHUD, partyTwoHUD, partyThreeHUD, partyFourHUD, enemyHUD;

    public string area;

    // Start is called before the first frame update
    void Start()
    {
        area = "Tutorial";
    }

    // Update is called once per frame
    void Update()
    {
        if (area == "Sand")
        {
            SandpitBattleSettings();
        }
        else if (area == "Pool")
        {
            PoolBattleSettings();
        }
        else if (area == "Tutorial")
        {
            TutorialBattleSettings();
        }
        else if (area == "Line")
        {
            ClotheslineBattleSettings();
        }
        else if (area == "Tree")
        {
            TreeBattleSettings();
        }
        else if (area == "Pond")
        {
            PondBattleSettings();
        }
    }

    void SandpitBattleSettings()
    {
        twisties.battleCamera = cameras[0];

        battleBits.partyOnePlatform = partyOnePlatform[0];
        battleBits.partyTwoPlatform = partyTwoPlatform[0];
        battleBits.partyThreePlatform = partyThreePlatform[0];
        battleBits.partyFourPlatform = partyFourPlatform[0];
        battleBits.enemyPlatform = enemyPlatform[0];

        battleBits.pOneHUD = partyOneHUD[0];
        battleBits.pTwoHUD = partyTwoHUD[0];
        battleBits.pThreeHUD = partyThreeHUD[0];
        battleBits.pFourHUD = partyFourHUD[0];
        battleBits.enemyHUD = enemyHUD[0];
    }
    void PoolBattleSettings()
    {
        twisties.battleCamera = cameras[1];

        battleBits.partyOnePlatform = partyOnePlatform[1];
        battleBits.partyTwoPlatform = partyTwoPlatform[1];
        battleBits.partyThreePlatform = partyThreePlatform[1];
        battleBits.partyFourPlatform = partyFourPlatform[1];
        battleBits.enemyPlatform = enemyPlatform[1];

        battleBits.pOneHUD = partyOneHUD[1];
        battleBits.pTwoHUD = partyTwoHUD[1];
        battleBits.pThreeHUD = partyThreeHUD[1];
        battleBits.pFourHUD = partyFourHUD[1];
        battleBits.enemyHUD = enemyHUD[1];
    }
    void TutorialBattleSettings()
    {
        twisties.battleCamera = cameras[2];

        battleBits.partyOnePlatform = partyOnePlatform[2];
        battleBits.partyTwoPlatform = partyTwoPlatform[2];
        battleBits.partyThreePlatform = partyThreePlatform[2];
        battleBits.partyFourPlatform = partyFourPlatform[2];
        battleBits.enemyPlatform = enemyPlatform[2];

        battleBits.pOneHUD = partyOneHUD[2];
        battleBits.pTwoHUD = partyTwoHUD[2];
        battleBits.pThreeHUD = partyThreeHUD[2];
        battleBits.pFourHUD = partyFourHUD[2];
        battleBits.enemyHUD = enemyHUD[2];
    }
    void ClotheslineBattleSettings()
    {
        twisties.battleCamera = cameras[3];

        battleBits.partyOnePlatform = partyOnePlatform[3];
        battleBits.partyTwoPlatform = partyTwoPlatform[3];
        battleBits.partyThreePlatform = partyThreePlatform[3];
        battleBits.partyFourPlatform = partyFourPlatform[3];
        battleBits.enemyPlatform = enemyPlatform[3];

        battleBits.pOneHUD = partyOneHUD[3];
        battleBits.pTwoHUD = partyTwoHUD[3];
        battleBits.pThreeHUD = partyThreeHUD[3];
        battleBits.pFourHUD = partyFourHUD[3];
        battleBits.enemyHUD = enemyHUD[3];
    }
    void TreeBattleSettings()
    {
        twisties.battleCamera = cameras[4];

        battleBits.partyOnePlatform = partyOnePlatform[4];
        battleBits.partyTwoPlatform = partyTwoPlatform[4];
        battleBits.partyThreePlatform = partyThreePlatform[4];
        battleBits.partyFourPlatform = partyFourPlatform[4];
        battleBits.enemyPlatform = enemyPlatform[4];

        battleBits.pOneHUD = partyOneHUD[4];
        battleBits.pTwoHUD = partyTwoHUD[4];
        battleBits.pThreeHUD = partyThreeHUD[4];
        battleBits.pFourHUD = partyFourHUD[4];
        battleBits.enemyHUD = enemyHUD[4];
    }
    void PondBattleSettings()
    {
        twisties.battleCamera = cameras[5];

        battleBits.partyOnePlatform = partyOnePlatform[5];
        battleBits.partyTwoPlatform = partyTwoPlatform[5];
        battleBits.partyThreePlatform = partyThreePlatform[5];
        battleBits.partyFourPlatform = partyFourPlatform[5];
        battleBits.enemyPlatform = enemyPlatform[5];

        battleBits.pOneHUD = partyOneHUD[5];
        battleBits.pTwoHUD = partyTwoHUD[5];
        battleBits.pThreeHUD = partyThreeHUD[5];
        battleBits.pFourHUD = partyFourHUD[5];
        battleBits.enemyHUD = enemyHUD[5];
    }
    void BossBattleSettings()
    {
        twisties.battleCamera = cameras[6];

        battleBits.partyOnePlatform = partyOnePlatform[6];
        battleBits.partyTwoPlatform = partyTwoPlatform[6];
        battleBits.partyThreePlatform = partyThreePlatform[6];
        battleBits.partyFourPlatform = partyFourPlatform[6];
        battleBits.enemyPlatform = enemyPlatform[6];

        battleBits.pOneHUD = partyOneHUD[6];
        battleBits.pTwoHUD = partyTwoHUD[6];
        battleBits.pThreeHUD = partyThreeHUD[6];
        battleBits.pFourHUD = partyFourHUD[6];
        battleBits.enemyHUD = enemyHUD[6];
    }
}
