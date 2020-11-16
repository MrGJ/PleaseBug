using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Zoning { POOLZONE, SANDPITZONE, PONDZONE, LINEZONE, TREEZONE}

public class ZoneSystem : MonoBehaviour
{
    public BattleHUDWLevelling huddler;
    public BattleSystemWLevelling battler;
    public GameObject hudHolder;
    public GameObject battleHolder;

    public GameObject camPool, camSand, camPond, camLine, camTree;
    public GameObject platOnePool, platTwoPool, platThreePool, platFourPool, platEnemPool;
    public GameObject platOneSand, platTwoSand, platThreeSand, platFourSand, platEnemSand;
    public GameObject platOnePond, platTwoPond, platThreePond, platFourPond, platEnemPond;
    public GameObject platOneLine, platTwoLine, platThreeLine, platFourLine, platEnemLine;
    public GameObject platOneTree, platTwoTree, platThreeTree, platFourTree, platEnemTree;

    public GameObject sliderOnePool, sliderTwoPool, sliderThreePool, sliderFourPool, sliderFivePool;
    public GameObject sliderOneSand, sliderTwoSand, sliderThreeSand, sliderFourSand, sliderFiveSand;
    public GameObject sliderOnePond, sliderTwoPond, sliderThreePond, sliderFourPond, sliderFivePond;
    public GameObject sliderOneLine, sliderTwoLine, sliderThreeLine, sliderFourLine, sliderFiveLine;
    public GameObject sliderOneTree, sliderTwoTree, sliderThreeTree, sliderFourTree, sliderFiveTree;

    public GameObject levelOnePool, levelTwoPool, levelThreePool, levelFourPool, levelFivePool;
    public GameObject levelOneSand, levelTwoSand, levelThreeSand, levelFourSand, levelFiveSand;
    public GameObject levelOnePond, levelTwoPond, levelThreePond, levelFourPond, levelFivePond;
    public GameObject levelOneLine, levelTwoLine, levelThreeLine, levelFourLine, levelFiveLine;
    public GameObject levelOneTree, levelTwoTree, levelThreeTree, levelFourTree, levelFiveTree;

    public GameObject nameOnePool, nameTwoPool, nameThreePool, nameFourPool, nameFivePool;
    public GameObject nameOneSand, nameTwoSand, nameThreeSand, nameFourSand, nameFiveSand;
    public GameObject nameOnePond, nameTwoPond, nameThreePond, nameFourPond, nameFivePond;
    public GameObject nameOneLine, nameTwoLine, nameThreeLine, nameFourLine, nameFiveLine;
    public GameObject nameOneTree, nameTwoTree, nameThreeTree, nameFourTree, nameFiveTree;

    // Start is called before the first frame update
    void Start()
    {
        battler = GetComponent<BattleSystemWLevelling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
