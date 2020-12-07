using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject overworldCamera;
    public GameObject mainCamera;
    public GameObject canvas;

    public Tutscript tutorialScript;

    public Animator startAnim;
    public Animator exitAnim;

    public bool enter;
    public bool exit;

    void Start()
    {
        overworldCamera.SetActive(false);

        startAnim.enabled = false;
        exitAnim.enabled = false;
    }

    public void StartButtonStart()
    {
        canvas.SetActive(false);
        startAnim.enabled = true;
    }

    public void SkipButton()
    {
        canvas.SetActive(false);
        CamSwitch();
        enter = true;
        tutorialScript.battlePrompt1 = true;
        tutorialScript.battlePrompt2 = true;
        tutorialScript.battlePrompt3 = true;
        tutorialScript.battlePrompt4 = true;

        tutorialScript.angryTeach.SetActive(false);
        tutorialScript.battleScene.SetActive(false);

        StartCoroutine(tutorialScript.TutPostBattle());
    }

    public void ExitButtonStart()
    {
        canvas.SetActive(false);
        exitAnim.enabled = true;
    }

    public void CamSwitch()
    {
        overworldCamera.SetActive(true);
        mainCamera.SetActive(false);

        enter = true;
    }

    public void Quitting()
    {
        Application.Quit();
    }

}
