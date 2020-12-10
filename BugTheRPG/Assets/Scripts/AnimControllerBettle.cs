using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerBettle : MonoBehaviour
{
    public void EndAnim()
    {
        GetComponent<Animator>().SetBool("isHit", false);
    }
}
