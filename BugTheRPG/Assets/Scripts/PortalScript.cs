using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Tutscript tutorial;

    public void PortalAnimEnd()
    {
        tutorial.cutscene1 = true;
    }
}
