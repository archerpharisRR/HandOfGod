using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Threats, IDragable
{
    OrbitMovementCloud omc;
    float minRoll = -5f;
    float maxRoll = 5f;
    [SerializeField] int damage = 1;
    Rigidbody rb;

    public override void Init()
    {
        omc = GetComponent<OrbitMovementCloud>();
        RandomNumber();
        Invoke("DestroyAfterTenSeconds", 20f);
    }

    void RandomNumber()
    {
        omc.orbitAxis.x = Random.Range(minRoll, maxRoll);
        omc.orbitAxis.y = Random.Range(minRoll, maxRoll);
        omc.orbitAxis.z = Random.Range(minRoll, maxRoll);
    }

    void DestroyAfterTenSeconds()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Rock Type2 04(Clone)")
        {
            Destroy(gameObject);
        }
    }

    internal float DamageDealt()
    {
        return damage;
    }

    public void Grabbed(GameObject grabber, Vector3 grabPoint)
    {
        transform.position = grabPoint;
        transform.parent = grabber.transform;
        rb.isKinematic = true;
        omc.enabled = false;
 
    }

    public void Released(Vector3 ThrowVelocity)
    {
        transform.parent = null;
        rb.isKinematic = false;

    }

    public GameObject GetGameObject()
    {
        return null;
    }
}
