using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRHand : MonoBehaviour, IXRControllerInterface
{

    [SerializeField] Animator handAnimator;
    [SerializeField] GameObject pointerObject;
    GameObject rayCastedObject;
    [SerializeField] Transform teleportLocation;
    [SerializeField] LazerPointer lazerPointer;
    [SerializeField] GameObject GrabbingPoint;
    [SerializeField] Transform ThrowVelocityRefPoint;
    [SerializeField] GameObject planet;
    

    IDragable objectInHand;
    Vector3 Velocity;
    Vector3 OldPosition;

   IEnumerator CalculateAverageSpeed()
    {
        while (true)
        {
            Velocity = (ThrowVelocityRefPoint.position - OldPosition) / 0.1f;
            OldPosition = ThrowVelocityRefPoint.position;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        if(lazerPointer == null)
        {
           lazerPointer =  GetComponent<LazerPointer>();
        }
        StartCoroutine(CalculateAverageSpeed());

    }

    public void UpdateLocalPosition(Vector3 location)
    {
        transform.localPosition = location;
    }

    public Vector3 LocalPosition()
    {
        return transform.localPosition;
    }

    public Quaternion LocalRotation()
    {
        return transform.localRotation;
    }

    public void UpdateStickPosition(Vector2 direction)
    {
        Debug.Log("Position is: " + direction);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        planet.transform.rotation = Quaternion.Euler(new Vector3(0, -angle, angle));
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

    internal void TriggerPressed()
    {
        if(lazerPointer!= null && lazerPointer.GetFocusedObject(out GameObject objectInFocus, out Vector3 ContactPoint))
        {
            IDragable objectAsDraggable = objectInFocus.GetComponent<IDragable>();
            if(objectAsDraggable == null)
            {
                objectAsDraggable = objectInFocus.GetComponentInParent<IDragable>();
            }

            if(objectAsDraggable != null)
            {
                objectAsDraggable.Grabbed(GrabbingPoint, ContactPoint);
                objectInHand = objectAsDraggable;
            }
        }
    }

    internal void TriggerReleased()
    {
        if(objectInHand as UnityEngine.Object)
        {
            objectInHand.Released(Velocity);
        }


    }

    private void Update()
    {


        
    }

    public Vector2 GetPointerScreenPosition()
    {
        if (lazerPointer != null)
        {
            return lazerPointer.getPointerScreenPosition();
        }
        return Vector2.zero;
    }
}
