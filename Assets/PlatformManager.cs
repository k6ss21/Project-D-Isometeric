using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<EnemySpawner> enemySpawners = new List<EnemySpawner>();

    public bool sick;
     
     public Transform boxPos;
     public Vector2 boxVectors;
    public LayerMask SickCharMask;


    void Update()
    {
        var collider2D = Physics2D.OverlapBox(boxPos.position, boxVectors,27,SickCharMask);
        if(collider2D!= null)
        {
            sick = true;
        }
        else{
            sick = false;
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.canSpawn = true;
            }
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (EnemySpawner enemySpawner in enemySpawners)
            {
                enemySpawner.canSpawn = false;
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
