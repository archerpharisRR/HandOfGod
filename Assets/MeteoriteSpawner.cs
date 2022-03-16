using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{

    [SerializeField] GameObject meteorPrefab;
    [SerializeField] float spawnRadius;
    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 10f;
    [SerializeField] float meteorSpeed;
    [SerializeField] Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawnThreat());
    }

    IEnumerator StartSpawnThreat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Mathf.Lerp(minSpawnInterval, maxSpawnInterval, Random.Range(0f, 1f)));
            SpawnMeteor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab, Random.insideUnitSphere * spawnRadius + transform.position, Random.rotation);
        Rigidbody rb = newMeteor.GetComponent<Rigidbody>();
        newMeteor.transform.LookAt(playerPos);
        rb.velocity = newMeteor.transform.forward * meteorSpeed;
        Destroy(newMeteor, 4f);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
