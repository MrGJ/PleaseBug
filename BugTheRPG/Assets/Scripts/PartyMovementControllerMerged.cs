using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartyMovementControllerMerged : MonoBehaviour
{
    public Camera cam;
    public GameObject partyOneFellow;
    public NavMeshAgent partyOneAgent;
    public NavMeshAgent partyTwoAgent;
    public NavMeshAgent partyThreeAgent;
    public NavMeshAgent partyFourAgent;

    public Transform partyOneLoc;
    public Transform partyTwoLoc;
    public Transform partyThreeLoc;
    public Transform partyFourLoc;

    public float lookRad;
    public float stoppingDistance;

    float tweenOneTwo;
    float tweenTwoThree;
    float tweenThreeFour;


    public OverworldSystem overworldSystem;
    public GameObject camHolder;
    public MainMenu gameStart;
    public int rotateSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") < 0)
                camHolder.transform.Rotate((Vector3.up) * rotateSpeed);
            if (Input.GetAxis("Mouse X") > 0)
                camHolder.transform.Rotate((Vector3.up) * -rotateSpeed);
        }

        //PartyOne Movement
        if (gameStart.enter == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //Moves Agent
                    partyOneAgent.SetDestination(hit.point);
                }
            }
        }

        //PartyOthers Followowollowing
        tweenOneTwo = Vector3.Distance(partyOneLoc.position, partyTwoLoc.position);
        tweenTwoThree = Vector3.Distance(partyTwoLoc.position, partyThreeLoc.position);
        tweenThreeFour = Vector3.Distance(partyThreeLoc.position, partyFourLoc.position);

        if (tweenOneTwo <= lookRad)
        {
            FaceTarget(partyOneLoc, partyTwoLoc);
            partyTwoAgent.SetDestination(partyOneLoc.position);
            if (tweenOneTwo < stoppingDistance)
            {
                partyTwoAgent.SetDestination(partyTwoLoc.position);
            }
        }
        if (tweenTwoThree <= lookRad)
        {
            FaceTarget(partyTwoLoc, partyThreeLoc);
            partyThreeAgent.SetDestination(partyTwoLoc.position);
            if (tweenTwoThree < stoppingDistance)
            {
                partyThreeAgent.SetDestination(partyThreeLoc.position);
            }
        }
        if (tweenThreeFour <= lookRad)
        {
            FaceTarget(partyThreeLoc, partyFourLoc);
            partyFourAgent.SetDestination(partyThreeLoc.position);
            if (tweenThreeFour < stoppingDistance)
            {
                partyFourAgent.SetDestination(partyFourLoc.position);
            }
        }

    }

    public void FaceTarget(Transform target, Transform self)
    {
        Vector3 direction = (target.position - self.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        self.rotation = Quaternion.Slerp(self.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
