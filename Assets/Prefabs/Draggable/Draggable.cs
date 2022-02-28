using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour, IDragable
{

    [SerializeField] XRHand leftHand;
    [SerializeField] float verticalSpeed = 5f;
    [SerializeField] float HorizontalSpeed = 5f;
    float h = 0;
    float v = 0;
    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        Debug.Log($"{grabber.name} grabbed me");

        h = HorizontalSpeed * leftHand.LocalPosition().x;
        v = verticalSpeed * leftHand.LocalPosition().y;



    }

    public void Released(Vector3 ThrowVelocity)
    {
        h = 0;
        v = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(h, v, 0);
        
    }
}
