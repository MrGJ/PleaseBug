using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public GameObject nameObj;
    public GameObject lvlObj;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;
    public Slider hpSlider;
    

    public void HUDFiddling(Unit unit)
    {
        nameText = nameObj.GetComponent<TextMeshProUGUI>();
        lvlText = lvlObj.GetComponent<TextMeshProUGUI>();

        nameText.text = unit.unitName;
        lvlText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void HPFiddling(int hp)
    {
        hpSlider.value = hp;
    }
}
