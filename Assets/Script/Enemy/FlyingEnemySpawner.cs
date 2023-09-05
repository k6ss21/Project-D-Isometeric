using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyingEnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float spawnRate = 1f;

    float nextSpawnTime;
    public bool canSpawn;

    public List<Transform> spawnPoints;

    public enum Direction
    {
        NE,
        SE,
        NW,
        SW
    }
    public Direction direction;
    private Vector2 dir;
    private bool isWaveActive;

    void OnEnable()
    {
        GameEventManager.OnSpawnWaveCall += Spawn;
    }

    void OnDisable()
    {
        GameEventManager.OnSpawnWaveCall -= Spawn;
    }

    void Start()
    {
        DirectonSelector();
    }
    void Update()
    {
        // UpdateSound();
    }



    void DirectonSelector()
    {
        switch (direction)
        {
            case Direction.NE:
                dir = Vector2.right;
                break;
            case Direction.SE:
                dir = Vector2.down;
                break;
            case Direction.NW:
                dir = Vector2.up;
                break;

            case Direction.SW:
                dir = Vector2.left;
                break;


        }
    }

    public void Spawn()
    {
        if(canSpawn)
        {
        foreach (Transform points in spawnPoints)
        {
            GameObject enemy = Instantiate(enemyPrefab, points.transform.position, Quaternion.identity);
            enemy.GetComponent<FlyingEnemyMovementAI>().SetDir(dir);
            nextSpawnTime = Time.time + spawnRate;
        }
        }

    }


}
