using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct ThreatSpawnSetting
    {
        public Threats ThreatToSpawn;
        public float Weight;
        public int maxCount;

    }

    public class ThreatHandler
    {
        Threats _threatToSpawn;
        Vector2 _weightRange;
        int _maxCount;
        int _currentCount;

        public ThreatHandler(Threats threat, Vector2 weightRange, int maxCount)
        {
            _threatToSpawn = threat;
            _weightRange = weightRange;
            _maxCount = maxCount;
            _currentCount = 0;

        }

        public void SpawnThreat()
        {
            Threats newThreat = GameObject.Instantiate(_threatToSpawn);
            newThreat.Init();
            Threats.OnDestroyed += ReduceCount;
            _currentCount++;
        }

        private void ReduceCount()
        {
            _currentCount--;
        }

        public bool CanSpawn()
        {
            return _currentCount < _maxCount;
        }

        public bool IsFloatInWeightRange(float val)
        {
            return val > _weightRange.x && val < _weightRange.y;
        }
    }


    [SerializeField] ThreatSpawnSetting[] threatPrefabs;
    [SerializeField] float MinSpawnInterval = 1f;
    [SerializeField] float MaxSpawnInterval = 5f;
    [SerializeField] Counter counter;

    List<ThreatHandler> threatHandlers;


    // Start is called before the first frame update
    void Start()
    {
        PopulateThreatHandlers();
        StartCoroutine(StartSpawnThreat());
    }

    private void PopulateThreatHandlers()
    {
        threatHandlers = new List<ThreatHandler>();
        float weight = 0;
        foreach(ThreatSpawnSetting setting in threatPrefabs)
        {
            threatHandlers.Add(new ThreatHandler(setting.ThreatToSpawn, new Vector2(weight, weight + setting.Weight), setting.maxCount));
        }
    }

    // Update is called once per frame
    void Update()
    {
        DifficultyIncreaser();
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
        int randomIndex =  UnityEngine.Random.Range(0, threatPrefabs.Length);
        Threats newThreat = Instantiate(GetRandomThreat());
        newThreat.Init();

  
    }

    Threats GetRandomThreat()
    {

        float maxWeight = MaxWeight();
        

        float RandPointer = UnityEngine.Random.Range(0f, maxWeight);

        Threats pick = null;
        float currentWeight = 0;
        foreach(ThreatSpawnSetting setting in threatPrefabs)
        {
            currentWeight += setting.Weight;
            if ( currentWeight > RandPointer)
            {
                pick = setting.ThreatToSpawn;
                break;
            }

        }

        

        return pick;
    }

    float MaxWeight()
    {
        float maxWeight = 0;


        foreach (ThreatSpawnSetting setting in threatPrefabs)
        {
            maxWeight += setting.Weight;
        }
        return maxWeight;
    }


    

    void DifficultyIncreaser()
    {
        if (counter.timer >= 10 && counter.timer < 20)
        {
            Debug.Log("difficulty level 1");
            MaxSpawnInterval = 6f;
        }
        if (counter.timer >= 21 && counter.timer < 30)
        {
            Debug.Log("difficulty level 2");
            MaxSpawnInterval = 4f;
        }

        if (counter.timer >= 31)
        {
            Debug.Log("difficulty level 3");
            MaxSpawnInterval = 2f;
        }
    }
}
