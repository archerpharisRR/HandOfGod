using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IDragable
{
    ParticleSystem ps;
    MeshRenderer mr;
    Rigidbody rb;
    Animator animator;


    private void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i hit something");
        ps.Play();
        mr.enabled = false;
        Destroy(gameObject, 0.3f);
        
    }

    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {

        transform.position = grabPoint;
        transform.parent = grabber.transform;
        rb.isKinematic = true;
        animator.enabled = false;

        
    }

    public void Released(Vector3 ThrowVelocity)
    {
        transform.parent = null;
        rb.isKinematic = false;
        animator.enabled = true;

    }

    public GameObject GetGameObject()
    {
        return null;
    }
}
