using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public Tutscript tutorial;

    public void GatesAnimEnd()
    {
        tutorial.cutscene3 = true;
    }
}
