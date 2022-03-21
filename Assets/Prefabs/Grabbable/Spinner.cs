using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour, IDragable
{
    GameObject LookRef;
    [SerializeField]Transform ObjectSpinned;
    [SerializeField]Transform spinOffset;
    [SerializeField] [Range(0, 1)] float Damping = 0.5f;
    [SerializeField] float spinSpeed = 20f;

    public GameObject GetGameObject()
    {
        return null;
    }

    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        LookRef.transform.position = grabPoint;
        LookRef.transform.parent = grabber.transform;
        spinOffset.LookAt(LookRef.transform, Vector3.up);
        ObjectSpinned.transform.parent = spinOffset;
        
    }

    public void Released(Vector3 ThrowVelocity)
    {
        ObjectSpinned.parent = transform;
        LookRef.transform.parent = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        LookRef = new GameObject($"{gameObject.name} look ref");
    }

    // Update is called once per frame
    void Update()
    {
        if (LookRef.transform.parent)
        {
            Quaternion goalRotation = Quaternion.LookRotation((LookRef.transform.position - spinOffset.position).normalized, Vector3.up);
            float lerpAlpha = Mathf.Clamp((1 - Damping) * spinSpeed * Time.deltaTime, 0, 1f);
            spinOffset.rotation = Quaternion.Slerp(spinOffset.rotation, goalRotation, lerpAlpha);

            //spinOffset.LookAt(LookRef.transform, Vector3.up);
        }
    }
}
