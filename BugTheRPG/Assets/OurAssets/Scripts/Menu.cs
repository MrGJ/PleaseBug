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
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
        }

        if (toggle == true)
        {
            
            canvas.SetActive(true);
        }
        else if (toggle == false)
        {
            
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
