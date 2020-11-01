using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void StartButton()
    {
        SceneManager.LoadScene("Garden", LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
