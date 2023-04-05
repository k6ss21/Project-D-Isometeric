using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float minTime;
    public float maxTime;
    public bool canSpawn;
    float spawnTimer;

    void Start()
    {
        GetTime();
    }

    void Update()
    {
        if (canSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {

                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                GetTime();
            }
        }
    }

    void GetTime()
    {
        spawnTimer = Random.Range(minTime, maxTime);
    }
}
