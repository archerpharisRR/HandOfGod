using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour, IDragable
{
    Transform holder;
    [SerializeField]float grabbingFlyTime = 10f;
    [SerializeField] float ThrowForceMultiplier = 2f;
    Coroutine GrabbingCoroutine;

    Rigidbody rigidBody;
    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        Debug.Log($"{grabber.name} grabbed me");
        holder = grabber.transform;
        GrabbingCoroutine = StartCoroutine(StartGrabbing());
        if (rigidBody)
        {
            rigidBody.isKinematic = true;
            rigidBody.velocity = Vector3.zero;
        }
       



    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    IEnumerator StartGrabbing()
    {

        float timer = 0f;

        while(timer < grabbingFlyTime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, holder.position, timer/grabbingFlyTime);
        }

        transform.position = holder.position;
        transform.parent = holder;
    }




    public void Released(Vector3 ThrowVelocity)
    {
        if(GrabbingCoroutine != null)
        {
            StopCoroutine(GrabbingCoroutine);
            transform.parent = null;
            if (rigidBody)
            {
                rigidBody.isKinematic = false;
                rigidBody.velocity = ThrowVelocity * ThrowForceMultiplier;
            }
        }

    }

    public GameObject GetGameObject()
    {
        return null;
    }
}
