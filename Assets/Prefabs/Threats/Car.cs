using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Threats, IDragable
{
    [SerializeField] Transform[] Lanes;
    [SerializeField] Transform carPivot;
    [SerializeField] float laneChangingSpeed = 10f;
    [SerializeField] LayerMask LaneDetectionMask;
    GameObject dragRef;

    Transform destinationLane;
    Transform originalLane;

    private void Start()
    {
        if (!HasAvailableLane())
        {
            Destroy(gameObject);
            return;
        }

        dragRef = new GameObject($"{gameObject.name} drag ref");
        PickRandomLane();
    }

    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        dragRef.transform.position = grabPoint;
        dragRef.transform.parent = grabber.transform;
    }





    private void PickRandomLane()
    {
        if(Lanes.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, Lanes.Length);
        if (CanMoveToLane(Lanes[randomIndex]))
        {
            destinationLane = Lanes[randomIndex];
            return;
        }
        PickRandomLane();
        

    }

    bool HasAvailableLane()
    {

        foreach (var lane in Lanes) 
        {
            if (CanMoveToLane(lane))
            {
                return true;
            }
        }
        return false;
    }

    public override void Init()
    {
        OrbitMovementComponent orbitMovementComp = GetComponent<OrbitMovementComponent>();
        Transform walkmanTrans = GameplayStatic.GetWalkmanTransform();
        Vector3 SpawnRotUp = -walkmanTrans.up;
        Vector3 SpawnRotForward = walkmanTrans.forward;
        Quaternion SpawnRot = Quaternion.LookRotation(SpawnRotForward, SpawnRotUp);

        orbitMovementComp.SetRotation(SpawnRot);
    }

    private void Update()
    {
        if(dragRef.transform.parent != null && Lanes.Length != 0)
        {
            Transform closestLane = Lanes[0];
            float cloestDistance = Vector3.Distance(dragRef.transform.position, closestLane.position);

            foreach(var lane in Lanes)
            {
                float distace = Vector3.Distance(dragRef.transform.position, lane.position);
                if(distace < cloestDistance)
                {
                    cloestDistance = distace;
                    closestLane = lane;
                }
            }
            if (CanMoveToLane(closestLane))
            {
                destinationLane = closestLane;
            }


        }

        float lerpAlpha = Mathf.Clamp(Time.deltaTime * laneChangingSpeed, 0f, 1f);
        carPivot.rotation = Quaternion.Slerp(carPivot.rotation, destinationLane.parent.rotation, lerpAlpha);
    }

    public void Released(Vector3 ThrowVelocity)
    {
        dragRef.transform.parent = null;
    }

    bool CanMoveToLane(Transform lane)
    {
        BoxCollider CarCollider = GetComponentInChildren<BoxCollider>();

        Collider[] colliders = Physics.OverlapBox(lane.position, CarCollider.size/2, lane.rotation, LaneDetectionMask);
        foreach(Collider collider in colliders)
        {
            if(collider.gameObject != CarCollider.gameObject)
            {
                return false;
            }
            
        }
        return true;
    }

    private void OnDrawGizmos()
    {
        return;
        foreach(var lan in Lanes)
        {
            BoxCollider Carcollider = GetComponentInChildren<BoxCollider>();
 

            if(!CanMoveToLane(lan))
            {
                Gizmos.DrawCube(lan.position, Carcollider.size);
            }
        }
    }
}
