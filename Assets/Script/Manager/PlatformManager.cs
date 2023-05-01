using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
    public List<MovingLight> movingLights = new List<MovingLight>();

    public List<Collider2D> sickColliders = new List<Collider2D>();
    public List<SickChar> sickChars = new List<SickChar>();
    public bool sick;
    //public bool isLaboratory;
    public GameObject stairway;
    bool playerPresent;
    public Transform boxPos;
    public Vector2 boxVectors;
    public LayerMask SickCharMask;

    ContactFilter2D sickContactFilter2D;
    void OnEnable()
    {
        Ab_Rehabilitation.OnRehabilitationTrigger += HealAllSick;
        Ab_InstantRehabilitation.OnInstantRehabilitationTrigger += InstantHealAllSick;
        Ab_SpawnBreaker.OnSpawnBreakerTrigger += DisableEnemySpawner;
        SickChar.OnHealComplete += RemoveSickFromList;
    }

    void OnDisable()
    {
        Ab_InstantRehabilitation.OnInstantRehabilitationTrigger -= InstantHealAllSick;
        Ab_Rehabilitation.OnRehabilitationTrigger -= HealAllSick;
        Ab_SpawnBreaker.OnSpawnBreakerTrigger -= DisableEnemySpawner;
        SickChar.OnHealComplete -= RemoveSickFromList;


    }

    private void Start()
    {

        sickContactFilter2D.layerMask = SickCharMask;
    }

    void Update()
    {

        var collider2D = Physics2D.OverlapBox(boxPos.position, boxVectors, 27, SickCharMask);
        if (collider2D != null)
        {

            sick = true;
            if (stairway != null)
            {

                stairway.SetActive(false);
            }
        }
        else
        {
            sick = false;
            if (stairway != null)
            {
                stairway.SetActive(true);
            }
        }


    }

    void DisableEnemySpawner(float time)
    {
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            enemySpawner.canSpawn = false;
        }
        StartCoroutine(ReEnableEnemySpawner(time));
    }

    IEnumerator ReEnableEnemySpawner(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            enemySpawner.canSpawn = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerPresent = true;
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.canSpawn = true;
            }
            foreach (MovingLight movingLight in movingLights)
            {
                movingLight.isOpen = true;
            }
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.canSpawn = false;
            }
            foreach (MovingLight movingLight in movingLights)
            {
                movingLight.isOpen = false;
            }

        }

    }

    void RemoveSickFromList(SickChar sickChar)
    {
        Debug.Log("sick char = " + sickChar);
        sickChars.Remove(sickChar);

    }

    void HealAllSick()
    {
        if (playerPresent)
        {
            foreach (SickChar sickChar in sickChars)
            {
                sickChar.StarHealing();
            }
        }
    }

    void InstantHealAllSick(float multi)
    {
        if (playerPresent)
        {
            foreach (SickChar sickChar in sickChars)
            {
                sickChar.StarHealing();
                sickChar.ChangeHealingRate(multi);
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.matrix = Matrix4x4.TRS(boxPos.position, boxPos.rotation, boxVectors);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }


}
