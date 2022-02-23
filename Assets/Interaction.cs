using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isTouching;
    GameObject touchedObject;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isTouching = true;
        touchedObject = collision.gameObject;
        rb = collision.gameObject.GetComponent<Rigidbody>();
        
    }



    public void GrabItem()
    {

        if(touchedObject == null)
        {
            return;
        }
        Debug.Log("We grabbing bois");
        touchedObject.transform.parent = transform;
        rb.isKinematic = true;
        

    }

    public void ReleaseItem()
    {
        if (touchedObject == null)
        {
            return;
        }
        Debug.Log("we letting go bois");
        touchedObject.transform.parent = null;
        rb.isKinematic = false;
        touchedObject = null;
    }
}
