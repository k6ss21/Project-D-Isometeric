using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AI : MonoBehaviour
{
    public GameObject ratPrefab;


    public float minTime;
    public float maxTime;
    float spawnTimer;


    public int minCount;
    public int maxCount;

    int spawnCount;

    public Transform SpawnPoint;

    void Start()
    {
        GetRandomTimeAndCount();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Debug.Log("SpawnRat");
            SpawnEnemy();
            GetRandomTimeAndCount();
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

}
