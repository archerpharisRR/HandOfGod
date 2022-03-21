using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Threats
{
    OrbitMovementCloud omc;
    float minRoll = -5f;
    float maxRoll = 5f;

    public override void Init()
    {
        omc = GetComponent<OrbitMovementCloud>();
        RandomNumber();
        Invoke("DestroyAfterTenSeconds", 15f);
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
}
