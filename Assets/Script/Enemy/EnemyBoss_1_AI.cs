using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AI : MonoBehaviour, IDamagable
{
    public GameObject ratPrefab;


    [Header("Timer")]
    public float minTime;
    public float maxTime;
    float spawnTimer;
    [Space(10)]

    [Header("Counter")]
    public int minCount;
    public int maxCount;
    [Space(10)]

    [Header("Spawn")]

    public bool canSpawn;
    int spawnCount;
    public Transform SpawnPoint;
    [Space(10)]

    [Header("Health")]

    public float health;
    public float currentHealth;



    void Start()
    {
        GetRandomTimeAndCount();
        currentHealth = health;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (canSpawn)
        {
            if (spawnTimer <= 0)
            {
                Debug.Log("SpawnRat");
                SpawnEnemy();
                GetRandomTimeAndCount();
            }
        }
    }


    void GetRandomTimeAndCount()
    {

        spawnTimer = Random.Range(minTime, maxTime);
        spawnCount = Random.Range(minCount, maxCount);
    }

    void SpawnEnemy()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 rdmPos = SpawnPoint.position + new Vector3(Random.Range(.01f, .02f), Random.Range(.01f, .02f));
            var ratSpawm = Instantiate(ratPrefab, rdmPos, Quaternion.identity);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

}
