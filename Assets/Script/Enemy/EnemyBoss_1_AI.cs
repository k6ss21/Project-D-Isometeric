using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class EnemyBoss_1_AI : MonoBehaviour, IDamagable
{
    public GameObject ratPrefab;

    public GameObject floatinTextPrefab;

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
    public Transform spawnPoint;
    [Space(10)]

    [Header("Health")]

    public float health;
    public float currentHealth;

    public GameObject deadPS_VFX_Prefab;

    public GameObject deathReward;

    private Action<EnemyBoss_1_AI> destroyAction;


    public void Init(Action<EnemyBoss_1_AI> destroy)
    {
        destroyAction = destroy;
    }
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


    void GetRandomTimeAndCount()  //Function for getting random and count to spawn child rat enemies
    {

        spawnTimer = Random.Range(minTime, maxTime);
        spawnCount = Random.Range(minCount, maxCount);
    }

    void SpawnEnemy() //Funtion for Spawning child rat enemy 
    {

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 rdmPos = spawnPoint.position + new Vector3(Random.Range(.01f, .02f), Random.Range(.01f, .02f));
            var ratSpawm = Instantiate(ratPrefab, rdmPos, Quaternion.identity);
        }
    }

    #region HEALTH

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(floatinTextPrefab && currentHealth > 0)
        {
            ShowFloatingText(currentHealth);
        }
        AudioManager.instance.PlayOneShot(FMODEvents.instance.enemyDamage,this.transform.position);
        if (currentHealth <= 0)
        {
            Instantiate(deathReward, spawnPoint.position , Quaternion.identity);
            Instantiate(deadPS_VFX_Prefab, transform.position, Quaternion.identity);
            destroyAction(this);
        }

    }

    #endregion

    void ShowFloatingText(float text) //PopUp Current Health.
    {
       var popUp = Instantiate(floatinTextPrefab, transform.position,  Quaternion.identity, transform);
       popUp.GetComponent<TextMesh>().text = text.ToString();
    }
}
