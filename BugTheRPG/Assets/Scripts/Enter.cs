using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public MainMenu script;

    public void StartAnim()
    {
        script.enter = true;
    }
}
