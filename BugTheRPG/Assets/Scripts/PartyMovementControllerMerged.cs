using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartyMovementControllerMerged : MonoBehaviour
{
    public Camera cam;
    public GameObject partyOneFellow;
    public GameObject lookPointObj;
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
    public Tutscript tutScript;
    public GameObject camHolder;

    public float minX = -360.0f;
    public float maxX = 360.0f;
    public float minY = -45.0f;
    public float maxY = 45.0f;
    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotX = 0.0f;
    float rotY = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        if (Input.GetMouseButton(1))
        {
            rotX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotY = Mathf.Clamp(rotY, minY, maxY);
            camHolder.transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
        }

        //PartyOne Movement
        if (tutScript.movementTutEnd == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //Moves Agent
                    lookPointObj.transform.position = (hit.point + new Vector3 (0, 1, 0));
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
