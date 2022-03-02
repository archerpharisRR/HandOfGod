using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour, IDragable
{
    GameObject lookRef;
    [SerializeField] Transform leftLane;
    [SerializeField] Transform actualCar;
    Vector3 originalPos;

    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        Debug.Log("I'm a car! You grabbed me!");
        lookRef = GameObject.CreatePrimitive(PrimitiveType.Cube);
        BoxCollider bc;
        MeshRenderer mr;
        bc = lookRef.AddComponent<BoxCollider>();
        bc.isTrigger = true;
        mr = lookRef.GetComponent<MeshRenderer>();
        mr.enabled = false;
        lookRef.AddComponent<LSIndependent>();
        originalPos = transform.position;
        lookRef.transform.position = grabPoint;
        lookRef.transform.parent = grabber.transform;

        




        //self = transform;
        //if (self.position.x != -2.5f)
        //{
        //    self.Translate(leftLane.localPosition.x, 0, 0);
        //}



    }



    public void Released(Vector3 ThrowVelocity)
    {
        lookRef.transform.parent = null;

    }

    //IEnumerator SmoothMove(Vector3 Direction, float speed)
    //{
    //    float startTime = Time.time;
    //    Vector3 startPos = transform.localPosition;
    //    Vector3 endPos = leftLane.transform.localPosition;

    //    while(startPos != endPos && (Time.time - startTime) * speed < 1f)
    //    {
    //        float move = Mathf.Lerp(0, 1, (Time.time - startTime) * speed);

    //        transform.localPosition += Direction * move;
    //        yield return null;
    //    }
        
    //}

    private void Start()
    {
       
        
    }

    void Update()
    {
        if (lookRef != null)
        {
            if (lookRef.transform.parent)
            {
                Debug.Log("currently holding");
 
                //transform.position = new Vector3(1, 0 ,0);

            }
            else
            {
                Debug.Log("not holding");
                
            }
        }
    }
}
