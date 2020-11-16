using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public MainMenu Menu;

    public void ExitAnimationEnd()
    {
        Menu.exit = true;
    }
}
