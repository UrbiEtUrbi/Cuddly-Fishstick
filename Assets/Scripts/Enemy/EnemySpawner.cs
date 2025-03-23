using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab;
        public float spawnWeight; // Weight for random selection
    }

    [System.Serializable]
    public class Wave
    {
        public EnemyType[] enemyTypes;
        public int enemyCount;
        public float spawnInterval;
        public ObjectListData Objects;
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float waveDelay = 5.0f;
    public UnityEvent<string, ObjectListData> OnWaveStart;

    private int currentWaveIndex = 0;
    private int enemiesSpawnedInWave = 0;
    private float nextSpawnTime;

    private void Start()
    {
        if(waves.Length > 0)
        {
            StartWave();
        }
        EnemyManager.Instance.OnWaveComplete.AddListener(OnWaveComplete);
    }

    private void Update()
    {
        if (currentWaveIndex < waves.Length && Time.time >= nextSpawnTime && enemiesSpawnedInWave < waves[currentWaveIndex].enemyCount)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + waves[currentWaveIndex].spawnInterval;
        }

    }

    private void StartWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            enemiesSpawnedInWave = 0;
            nextSpawnTime = Time.time + waves[currentWaveIndex].spawnInterval;
            OnWaveStart.Invoke($"Wave {currentWaveIndex + 1} Started!", waves[currentWaveIndex].Objects);
            Debug.Log($"Starting Wave {currentWaveIndex + 1}");
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemyPrefab = GetRandomEnemyPrefab(waves[currentWaveIndex].enemyTypes);
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemiesSpawnedInWave++;
        }
    }

    private void OnWaveComplete()
    {
        Debug.Log($"Wave {currentWaveIndex} completed");
        currentWaveIndex++;
        if(currentWaveIndex <= waves.Length)
        {
            
            StartCoroutine(StartWaveWithDelay());
        }
        else
        {
            EnemyManager.Instance.CheckWinCondition();
        }
    }
    
    private GameObject GetRandomEnemyPrefab(EnemyType[] enemyTypes)
    {
        float totalWeight = 0;
        foreach (var enemyType in enemyTypes)
        {
            totalWeight += enemyType.spawnWeight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        foreach (var enemyType in enemyTypes)
        {
            cumulativeWeight += enemyType.spawnWeight;
            if (randomValue <= cumulativeWeight)
            {
                return enemyType.prefab;
            }
        }

        return null;
    }

    private IEnumerator StartWaveWithDelay()
    {
        yield return new WaitForSeconds(waveDelay);
        StartWave();
    }
}
