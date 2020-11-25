using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutscript : MonoBehaviour
{
    public GameObject[] movementPans;
    public GameObject[] battlePans;

    public bool movementTutEnd;
    public bool battleTutEnd;

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
        Debug.Log("Movement Tutorial Ended");
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        movementPans[4].SetActive(false);
        movementTutEnd = true;
        StopCoroutine(TutNonsense());
    }
    public IEnumerator TutBattle1()
    {
        movementTutEnd = false;
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
        battleScript.PartyPhaseBegin();
        battlePrompt1 = true;
    }
    public IEnumerator TutBattle2()
    {
        yield return new WaitForSeconds(1f);
        battlePans[4].SetActive(true);
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }
}
