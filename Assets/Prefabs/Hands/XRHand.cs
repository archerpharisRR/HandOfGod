using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRHand : MonoBehaviour
{

    [SerializeField] Animator handAnimator;
    [SerializeField] GameObject pointerObject;
    GameObject rayCastedObject;
    [SerializeField] Transform teleportLocation;


    private void Awake()
    {

    }

    public void UpdateLocalPosition(Vector3 location)
    {
        transform.localPosition = location;
    }

    internal void UpdateLocalRotation(Quaternion rotation)
    {
        transform.localRotation = rotation;
    }

    public void SetTriggerValue(float numbah)
    {
        handAnimator.SetFloat("Trigger", numbah);

    }

    public void Point()
    {
        Vector3 forward = pointerObject.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(pointerObject.transform.position, forward, Color.green);

        RaycastHit hit;
        Ray myRay = new Ray(pointerObject.transform.position, forward);
        Physics.Raycast(myRay, out hit);

        if (hit.collider)
        {
            rayCastedObject = hit.collider.gameObject;
            rayCastedObject.transform.position = teleportLocation.transform.position;
        }
    }

    public void SetGripValue(float numbah)
    {
        handAnimator.SetFloat("Grip", numbah);

    }
}
