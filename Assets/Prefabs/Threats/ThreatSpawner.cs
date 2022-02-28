using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatSpawner : MonoBehaviour
{
    [SerializeField] Threats[] threats;
    [SerializeField] float MinSpawnInterval = 1f;
    [SerializeField] float MaxSpawnInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawnThreat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawnThreat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Mathf.Lerp(MinSpawnInterval, MaxSpawnInterval, Random.Range(0f, 1f)));
            SpawnRandomThreat();
        }
    }

    private void SpawnRandomThreat()
    {
        int randomIndex =  Random.Range(0, threats.Length);
        Threats newThreat = Instantiate(threats[randomIndex]);
        newThreat.Init();
    }
}
