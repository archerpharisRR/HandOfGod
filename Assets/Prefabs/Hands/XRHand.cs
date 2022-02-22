using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRHand : MonoBehaviour
{

    [SerializeField] Animator handAnimator;
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

    public void SetGripValue(float numbah)
    {
        handAnimator.SetFloat("Grip", numbah);
    }
}
