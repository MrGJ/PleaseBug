using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerPencil : MonoBehaviour
{
    public void EndAnim()
    {
        GetComponent<Animator>().SetBool("isHit", false);
    }
}
