using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public MainMenu Menu;

    public void EnterAnimationEnd()
    {
        Menu.enter = true;
    }
}
