using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject OverworldCamera;
    public GameObject canvas;

    public Animator StartButtonAnim;
    public Animator QuitButtonAnim;

    public bool exit;
    public bool enter;

    // Start is called before the first frame update 
    void Start()
    {
        OverworldCamera.SetActive(false);

        StartButtonAnim.enabled = false;
        QuitButtonAnim.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (exit == true)
        {
            Application.Quit();
        }
        else if (enter == true)
        {
            MainCamera.SetActive(false);
            OverworldCamera.SetActive(true);
        }
    }

    public void StartButtonStart()
    {
        StartButtonAnim.enabled = true;
        canvas.SetActive(false);
    }

    public void ExitButtonStart()
    {
        canvas.SetActive(false);
        QuitButtonAnim.enabled = true;
    }
}
