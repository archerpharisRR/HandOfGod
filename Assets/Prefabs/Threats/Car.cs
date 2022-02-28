using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Threats
{
    public override void Init()
    {
        OrbitMovementComponent orbitMovementComp = GetComponent<OrbitMovementComponent>();
        Transform walkmanTrans = GameplayStatic.GetWalkmanTransform();
        Vector3 SpawnRotUp = -walkmanTrans.up;
        Vector3 SpawnRotForward = walkmanTrans.forward;
        Quaternion SpawnRot = Quaternion.LookRotation(SpawnRotForward, SpawnRotUp);

        orbitMovementComp.SetRotation(SpawnRot);
    }


}
