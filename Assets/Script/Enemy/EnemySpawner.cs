using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBoss_1_AI enemyboss_1_Prefab;

    public float minTime;
    public float maxTime;
    public bool canSpawn;
    float spawnTimer;

    void Start()
    {
        GetTime();
        CreatePooledEnemyBoss_1_Objects();
    }

    void Update()
    {
        if (canSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.enemySpawn, this.transform.position);
                //GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                EnemyBoss_1_AI enemyBoss_1 = GetPooledEnmeyBoss_1_Object();
                if(enemyBoss_1 != null)
                {
                    enemyBoss_1.transform.position = transform.position;
                    enemyBoss_1.gameObject.SetActive(true);
                    enemyBoss_1.gameObject.GetComponent<EnemyBoss_1_AttackAI>().isAttacking = false;
                    enemyBoss_1.Init(DestroyEnemyBoss_1);
                }
                
                GetTime();
            }
        }
    }

    void GetTime()
    {
        spawnTimer = Random.Range(minTime, maxTime);
    }

    #region OBJECT POOL
    private List<EnemyBoss_1_AI> enemyboss_1_PooledObjects = new List<EnemyBoss_1_AI>();

    private int amountToPool = 10;

    private void CreatePooledEnemyBoss_1_Objects()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            EnemyBoss_1_AI obj = Instantiate(enemyboss_1_Prefab, transform.position, Quaternion.identity, this.transform);
            obj.gameObject.SetActive(false);
            enemyboss_1_PooledObjects.Add(obj);
        }
    }

    private EnemyBoss_1_AI GetPooledEnmeyBoss_1_Object()
    {
        int pooledCount = enemyboss_1_PooledObjects.Count;
        for (int i = 0; i < pooledCount; i++)
        {
            if (!enemyboss_1_PooledObjects[i].gameObject.activeInHierarchy)
            {
                return enemyboss_1_PooledObjects[i];
            }
        }
        return null;
    }

    private void DestroyEnemyBoss_1(EnemyBoss_1_AI  enemyBoss_1_AI)
    {
        enemyBoss_1_AI.gameObject.transform.position = transform.position;
        enemyBoss_1_AI.gameObject.SetActive(false);
        //   Destroy(projectile.gameObject);
    }

    #endregion  
}
