using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject overworldCamera;
    public GameObject mainCamera;
    public GameObject canvas;

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

    public void ExitButtonStart()
    {
        canvas.SetActive(false);
        exitAnim.enabled = true;
    }

    public void CamSwitch()
    {
        overworldCamera.SetActive(true);
        mainCamera.SetActive(false);
    }

    public void Quitting()
    {
        Application.Quit();
    }

}
