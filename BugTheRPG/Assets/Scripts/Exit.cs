using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public MainMenu script;

    public void ExitAnim()
    {
        script.exit = true;
        script.Quitting();
    }
}
