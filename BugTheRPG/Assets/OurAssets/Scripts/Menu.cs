using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool toggle = false;
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
        }

        if (toggle == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            canvas.SetActive(true);
        }
        else if (toggle == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            canvas.SetActive(false);
        }
    }

    public void ResumeButton()
    {
        toggle = false;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }
}
