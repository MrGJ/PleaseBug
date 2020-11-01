using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public OverworldSystem overworldSystem;
    public EncounterTwisting encounter;
    public PartyMovementControllerMerged movementControl;

    public Transform self;
    public NavMeshAgent selfNav;

    public GameObject overworldController;
    public GameObject gameSystems; 

    public float lookRad;
    public float stoppingDistance;
    float tweenEnemyProtag;

    // Start is called before the first frame update
    void Start()
    {
        gameSystems = GameObject.Find("GameSystems");
        overworldController = GameObject.Find("OverworldSystems");
        overworldSystem = overworldController.GetComponent<OverworldSystem>();
        encounter = overworldController.GetComponent<EncounterTwisting>();
        movementControl = overworldController.GetComponent<PartyMovementControllerMerged>();
    }

    // Update is called once per frame
    void Update()
    {
        tweenEnemyProtag = Vector3.Distance(movementControl.partyOneLoc.position, self.position);

        if (tweenEnemyProtag <= lookRad)
        {
            movementControl.FaceTarget(movementControl.partyOneLoc, self);
            selfNav.SetDestination(movementControl.partyOneLoc.position);
            if (tweenEnemyProtag < stoppingDistance)
            {
                selfNav.SetDestination(self.position);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        overworldSystem.enemyUnit = GetComponent<UnitWLevelling>();
        encounter.EncounterStart();
    }
}
