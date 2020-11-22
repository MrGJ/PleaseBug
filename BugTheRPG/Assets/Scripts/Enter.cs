using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public MainMenu script;
    public Tutscript tutStart;

    public void StartAnim()
    {
        tutStart.TutStart();
        script.CamSwitch();
    }
}
