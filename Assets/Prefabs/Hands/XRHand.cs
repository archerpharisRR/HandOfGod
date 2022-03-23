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

        if (lazerPointer != null && lazerPointer.GetFocusedObject(out GameObject objectInFocus, out Vector3 dsad))
        {
            GameObject item = objectInFocus;
            if(direction.y > 0)
            {
                Debug.Log("we're pushing up");

            }
        }

        //this is code to rotate the earth with the stick. Messes with car spawns, don't use it.
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //planet.transform.rotation = Quaternion.Euler(new Vector3(0, -angle, angle));
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

        if(lazerPointer != null)
        {
            GameObject currentObjectOverUI = lazerPointer.GetCurrentPointingUI();

            if(currentObjectOverUI != null)
            {
                InventorySlot slot = GetCurrentOverSlot();
                if(slot != null && !slot.IsEmpty())
                {
                    InventoryComponent item = slot.GrabItem();
                    IDragable objectAsDraggable = item.GetComponent<IDragable>();
                    if(objectAsDraggable as UnityEngine.Object)
                    {
                        objectInHand = objectAsDraggable;
                    }
                }
            }

        }
        


    }

    InventorySlot GetCurrentOverSlot()
    {
        if(lazerPointer == null)
        {
            return null;
        }
        GameObject currentOVERUI = lazerPointer.GetCurrentPointingUI();

        if(currentOVERUI != null)
        {
            return currentOVERUI.GetComponent<InventorySlot>();
        }
        return null;
    }


   

    internal void TriggerReleased()
    {
        InventoryComponent item = null;
        GameObject currentObjectOverUI = lazerPointer.GetCurrentPointingUI();

        if (lazerPointer != null && lazerPointer.GetFocusedObject(out GameObject objectInFocus, out Vector3 dsad) && currentObjectOverUI)
        {
            item = objectInFocus.GetComponent<InventoryComponent>();
            InventorySlot slot = currentObjectOverUI.GetComponent<InventorySlot>();
            slot.StoreItem(item);

        }

        //if (objectInHand as UnityEngine.Object && currentObjectOverUI)
        //{
            
        //}



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
            return lazerPointer.GetPointerScreenPosition();
        }
        return Vector2.zero;
    }
}
