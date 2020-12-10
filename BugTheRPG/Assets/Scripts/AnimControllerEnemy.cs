using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerEnemy : MonoBehaviour
{
    public void EndAnimEnemy()
    {
        GetComponent<Animator>().SetBool("isHitEnemy", false);
    }
}
