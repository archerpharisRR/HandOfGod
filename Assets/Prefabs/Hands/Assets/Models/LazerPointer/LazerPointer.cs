using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPointer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask PointerTraceLayerMask;

    public bool GetFocusedObject(out GameObject objectInFocus, out Vector3 contactPoint)
    {
        objectInFocus = null;
        contactPoint = Vector3.zero;

        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude,
            PointerTraceLayerMask)){
            objectInFocus = hitInfo.collider.gameObject;
            contactPoint = hitInfo.point;
            return true;


        }
        return false;
    }

    private void Start()
    {
        if(lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    internal Vector2 getPointerScreenPosition()
    {
        float traceLength = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude;
        Vector3 PointerPosition = transform.position + transform.forward * traceLength;
        return Camera.main.WorldToScreenPoint(PointerPosition);
    }
}
