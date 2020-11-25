using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFiddling : MonoBehaviour
{
    public EncounterTwisting twisties;
    public BattleSystemWLevelling battleBits;
    public Tutscript tuttyfruity;

    public GameObject zoneSandCam, zonePoolCam, zoneTutCam, zoneLineCam, zoneTreeCam, zonePondCam, zoneBossCam;
    public Transform[] partyOnePlatform, partyTwoPlatform, partyThreePlatform, partyFourPlatform, enemyPlatform;
    public GameObject leader;


    // Start is called before the first frame update
    void Start()
    {
        if (!tuttyfruity.battleTutEnd)
        {
            Debug.Log("Fiddled to be TuttyFruity");
            ZoneTut();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other == leader)
        {
            if (gameObject.name == "ZoneSand")
            {
                Debug.Log("Fiddled to be Sand");
                ZoneSand();
            }
            else if (gameObject.name == "ZonePool")
            {
                Debug.Log("Fiddled to be Pool");
                ZonePool();
            }
            else if (gameObject.name == "ZoneLine")
            {
                Debug.Log("Fiddled to be Line");
                ZoneLine();
            }
            else if (gameObject.name == "ZoneTree")
            {
                Debug.Log("Fiddled to be Tree");
                ZoneTree();
            }
            else if (gameObject.name == "ZonePond")
            {
                Debug.Log("Fiddled to be Pond");
                ZonePond();
            }
        }
    }

    

    void ZoneSand()
    {
        twisties.battleCamera = zoneSandCam;
        battleBits.partyOnePlatform = partyOnePlatform[0];
        battleBits.partyTwoPlatform = partyTwoPlatform[0];
        battleBits.partyThreePlatform = partyThreePlatform[0];
        battleBits.partyFourPlatform = partyFourPlatform[0];
        battleBits.enemyPlatform = enemyPlatform[0];
    }

    void ZonePool()
    {
        twisties.battleCamera = zonePoolCam;
        battleBits.partyOnePlatform = partyOnePlatform[1];
        battleBits.partyTwoPlatform = partyTwoPlatform[1];
        battleBits.partyThreePlatform = partyThreePlatform[1];
        battleBits.partyFourPlatform = partyFourPlatform[1];
        battleBits.enemyPlatform = enemyPlatform[1];
    }

    void ZoneTut()
    {
        twisties.battleCamera = zoneTutCam;
        battleBits.partyOnePlatform = partyOnePlatform[2];
        battleBits.partyTwoPlatform = partyTwoPlatform[2];
        battleBits.partyThreePlatform = partyThreePlatform[2];
        battleBits.partyFourPlatform = partyFourPlatform[2];
        battleBits.enemyPlatform = enemyPlatform[2];
    }

    void ZoneLine()
    {
        twisties.battleCamera = zoneLineCam;
        battleBits.partyOnePlatform = partyOnePlatform[3];
        battleBits.partyTwoPlatform = partyTwoPlatform[3];
        battleBits.partyThreePlatform = partyThreePlatform[3];
        battleBits.partyFourPlatform = partyFourPlatform[3];
        battleBits.enemyPlatform = enemyPlatform[3];
    }

    void ZoneTree()
    {
        twisties.battleCamera = zoneTreeCam;
        battleBits.partyOnePlatform = partyOnePlatform[4];
        battleBits.partyTwoPlatform = partyTwoPlatform[4];
        battleBits.partyThreePlatform = partyThreePlatform[4];
        battleBits.partyFourPlatform = partyFourPlatform[4];
        battleBits.enemyPlatform = enemyPlatform[4];
    }

    void ZonePond()
    {
        twisties.battleCamera = zoneTutCam;
        battleBits.partyOnePlatform = partyOnePlatform[5];
        battleBits.partyTwoPlatform = partyTwoPlatform[5];
        battleBits.partyThreePlatform = partyThreePlatform[5];
        battleBits.partyFourPlatform = partyFourPlatform[5];
        battleBits.enemyPlatform = enemyPlatform[5];
    }

    void ZoneBoss()
    {
        twisties.battleCamera = zoneTutCam;
        battleBits.partyOnePlatform = partyOnePlatform[6];
        battleBits.partyTwoPlatform = partyTwoPlatform[6];
        battleBits.partyThreePlatform = partyThreePlatform[6];
        battleBits.partyFourPlatform = partyFourPlatform[6];
        battleBits.enemyPlatform = enemyPlatform[6];
    }
}
