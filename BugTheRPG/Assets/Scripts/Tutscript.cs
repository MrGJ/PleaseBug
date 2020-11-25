using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutscript : MonoBehaviour
{
    public GameObject[] movementPans;
    public GameObject[] battlePans;

    public bool movementTutEnd;
    public bool battleTutEnd;
    public bool battleSelection;

    public bool battlePrompt1;
    public bool battlePrompt2;
    public bool battlePrompt3;
    public bool battlePrompt4;
    

    public MainMenu menuScript;
    public BattleSystemWLevelling battleScript;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            movementPans[i].SetActive(false);
        }

        for (int i = 0; i < 5; i++)
        {
            battlePans[i].SetActive(false);
        }
    }
    public void TutStart()
    {
        StartCoroutine(TutNonsense());
    }

    IEnumerator TutNonsense()
    {
        yield return new WaitForSeconds(1f);
        movementPans[0].SetActive(true);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[0].SetActive(false);
        movementPans[1].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[1].SetActive(false);
        movementPans[2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[2].SetActive(false);
        movementPans[3].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[3].SetActive(false);
        movementPans[4].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[4].SetActive(false);
        movementTutEnd = true;
    }

    public IEnumerator TutBattle()
    {
        yield return new WaitForSeconds(1f);
        battlePans[0].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[0].SetActive(false);
        battlePans[1].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[1].SetActive(false);
        battlePans[2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[2].SetActive(false);
        battlePans[3].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[3].SetActive(false);
        battlePans[4].SetActive(true);
        battlePrompt1 = true;
        yield return StartCoroutine(WaitForBattleInput(battleSelection));
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }

    IEnumerator WaitForBattleInput(bool select)
    {
        while (select == false)
            yield return null;
    }
}
