using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUDWLevelling : MonoBehaviour
{
    public GameObject nameObj;
    public GameObject lvlObj;
    public GameObject hNum;
    public GameObject mNum;
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public Slider hpSlider;
    public Slider mpSlider;
    public int tempHP;
    public int tempMP;
    
    //When called, Initialises HUD based on the unit given
    public void HUDFiddling(UnitWLevelling unit)
    {
        nameText = nameObj.GetComponent<TextMeshProUGUI>();
        lvlText = lvlObj.GetComponent<TextMeshProUGUI>();
        tempHP = unit.unitMaxHP;
        tempMP = unit.unitMaxMP;

        nameText.text = unit.unitName;
        lvlText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.unitMaxHP;
        hpSlider.value = unit.unitCurrentHP;
        mpSlider.maxValue = unit.unitMaxMP;
        mpSlider.value = unit.unitCurrentMP;
        healthText.text = unit.unitCurrentHP + "/" + unit.unitMaxHP;
        manaText.text = unit.unitCurrentMP + "/" + unit.unitMaxMP;
    }

    //Updates HP slider when called
    public void HPFiddling(int hp)
    {
        healthText.text = hp + "/" + tempHP;
        hpSlider.value = hp;
    }

    //Updates MP slider when called
    public void MPFiddling(int mp)
    {
        manaText.text = mp + "/" + tempMP;
        mpSlider.value = mp;
    }
}
