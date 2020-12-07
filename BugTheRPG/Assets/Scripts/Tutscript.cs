using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutscript : MonoBehaviour
{
    public GameObject[] movementPans;
    public GameObject[] battlePans;
    public GameObject[] postBattlePans;

    public GameObject happyTeach;
    public GameObject angryTeach;
    public GameObject battleScene;

    public GameObject overworldCamera;
    public GameObject cutsceneCamera;

    public GameObject evilCaterpillar;
    public GameObject portal;
    public Animator gates;

    public bool movementTutEnd;
    public bool battleTutEnd;

    public bool battlePrompt1;
    public bool battlePrompt2;
    public bool battlePrompt3;
    public bool battlePrompt4;

    public bool cutscene1;
    public bool cutscene2;
    public bool cutscene3;

    public MainMenu menuScript;
    public BattleSystemWLevelling battleScript;

    void Start()
    {
        for (int i = 0; i < movementPans.Length; i++)
        {
            movementPans[i].SetActive(false);
        }

        for (int i = 0; i < battlePans.Length; i++)
        {
            battlePans[i].SetActive(false);
        }

        for (int i = 0; i < postBattlePans.Length; i++)
        {
            postBattlePans[i].SetActive(false);
        }

        happyTeach.SetActive(false);
        cutsceneCamera.SetActive(false);
    }
    public void TutStart()
    {
        StartCoroutine(TutNonsense());
    }
    public void TutEnd()
    {
        StartCoroutine(TutPostBattle());
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
    }
    public IEnumerator TutBattle2()
    {
        yield return new WaitForSeconds(1f);
        battlePans[4].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[4].SetActive(false);
        battlePans[5].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[5].SetActive(false);
        battlePans[6].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[6].SetActive(false);
        battlePrompt2 = true;
        StartCoroutine(battleScript.TutorialBattle2());
    }
    public IEnumerator TutBattle3()
    {
        yield return new WaitForSeconds(1f);
        battlePans[7].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[7].SetActive(false);
        battlePans[8].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[8].SetActive(false);
        battlePans[9].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[9].SetActive(false);
        battlePrompt2 = true;
        StartCoroutine(battleScript.TutorialBattle3());
    }
    public IEnumerator TutBattle4()
    {
        yield return new WaitForSeconds(1f);
        battlePans[10].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[10].SetActive(false);
        battlePans[11].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[11].SetActive(false);
        battlePans[12].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        battlePans[12].SetActive(false);
        battlePrompt3 = true;
        StartCoroutine(battleScript.TutorialBattle4());
    }
    public IEnumerator TutPostBattle()
    {
        yield return new WaitForSeconds(1f);
        cutsceneCamera.SetActive(true);
        overworldCamera.SetActive(false);
        yield return new WaitForSeconds(4f);
        portal.SetActive(true);
        Debug.Log("Step One of Cutscene");
        yield return new WaitForSeconds(5f);
        evilCaterpillar.SetActive(true);
        Debug.Log("Step Two of Cutscene");
        yield return new WaitForSeconds(7f);
        gates.enabled = true;
        Debug.Log("Step Three of Cutscene");
        yield return new WaitForSeconds(3f);
        cutsceneCamera.SetActive(false);
        overworldCamera.SetActive(true);
        Debug.Log("Step Four of Cutscene");
        yield return new WaitForSeconds(2f);
        postBattlePans[0].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        postBattlePans[0].SetActive(false);
        postBattlePans[1].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        postBattlePans[1].SetActive(false);
        postBattlePans[2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Mouse0));
        postBattlePans[2].SetActive(false);
        battleTutEnd = true;
        movementTutEnd = true;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }
}
