using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovementComponent : MonoBehaviour
{
    [SerializeField] Vector3 orbitAxis;
    [SerializeField] float OrbitAngularSpeed = 2;
    [SerializeField] Transform orbitAround;


    // Start is called before the first frame update
    void Start()
    {
        if(orbitAround == null)
        {
            orbitAround = FindObjectOfType<Earth>()?.transform;
        }
        if (orbitAround)
        {
            transform.parent = orbitAround;
            transform.localPosition = Vector3.zero;
        }

    }

    internal void SetRotation(Quaternion spawnRot)
    {
        transform.rotation = spawnRot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(orbitAxis.x * OrbitAngularSpeed * Time.deltaTime,
                        orbitAxis.y * OrbitAngularSpeed * Time.deltaTime,
                        orbitAxis.z * OrbitAngularSpeed * Time.deltaTime);

    }
}
