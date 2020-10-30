using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSystem : MonoBehaviour
{
    public GameObject partyMemOne;
    public GameObject partyMemTwo;
    public GameObject partyMemThree;
    public GameObject partyMemFour;
    public GameObject enemyObj;

    public UnitWLevelling partyOneUnit;
    public UnitWLevelling partyTwoUnit;
    public UnitWLevelling partyThreeUnit;
    public UnitWLevelling partyFourUnit;

    public Transform partyOnePlatform;
    public Transform partyTwoPlatform;
    public Transform partyThreePlatform;
    public Transform partyFourPlatform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject partyOneGO = Instantiate(partyMemOne, partyOnePlatform);
        partyOneUnit = partyOneGO.GetComponent<UnitWLevelling>();
        GameObject partyTwoGO = Instantiate(partyMemTwo, partyTwoPlatform);
        partyTwoUnit = partyTwoGO.GetComponent<UnitWLevelling>();
        GameObject partyThreeGO = Instantiate(partyMemThree, partyThreePlatform);
        partyThreeUnit = partyThreeGO.GetComponent<UnitWLevelling>();
        GameObject partyFourGO = Instantiate(partyMemFour, partyFourPlatform);
        partyFourUnit = partyFourGO.GetComponent<UnitWLevelling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
