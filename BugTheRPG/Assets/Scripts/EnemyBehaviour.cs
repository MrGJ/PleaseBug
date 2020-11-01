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
    public GameObject playerMain;

    public float lookRad;
    public float stoppingDistance;
    float tweenEnemyProtag;

    // Start is called before the first frame update
    void Start()
    {
        gameSystems = GameObject.Find("GameSystems");
        overworldController = GameObject.Find("OverworldSystems");
        playerMain = GameObject.FindGameObjectWithTag("OneOver");
        overworldSystem = overworldController.GetComponent<OverworldSystem>();
        encounter = gameSystems.GetComponent<EncounterTwisting>();
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
        if (collision.collider == playerMain.GetComponent<Collider>())
        {
            overworldSystem.enemyUnit = GetComponent<UnitWLevelling>();
            encounter.EncounterStart();
            Debug.Log("EncounterStarts");
        }
        
    }
}
