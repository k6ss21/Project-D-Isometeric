using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameEventManager : MonoBehaviour
{
    private float spawnTimer;


    public float minTime;
    public float maxTime;

    public static event Action OnSpawnWaveCall;

    void Start()
    {
        spawnTimer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            OnSpawnWaveCall?.Invoke();
            spawnTimer = Random.Range(minTime, maxTime);

        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
             OnSpawnWaveCall?.Invoke();
        }

    }

}

