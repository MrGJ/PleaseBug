using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilAnim : MonoBehaviour
{
    public Tutscript tutorial;

    public void EvilAnimEnd()
    {
        tutorial.cutscene2 = true;
    }
}
