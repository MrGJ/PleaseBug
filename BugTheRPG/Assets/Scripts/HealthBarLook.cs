﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLook : MonoBehaviour
{
    public GameObject enemyHPBar;
    public GameObject partyOneHPBar;
    public GameObject partyTwoHPBar;
    public GameObject partyThreeHPBar;
    public GameObject partyFourHPBar;
    public Transform viewCam;

    // Start is called before the first frame update
    void Start()
    {
        enemyHPBar.transform.LookAt(viewCam);
        partyOneHPBar.transform.LookAt(viewCam);
        partyTwoHPBar.transform.LookAt(viewCam);
        partyThreeHPBar.transform.LookAt(viewCam);
        partyFourHPBar.transform.LookAt(viewCam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}