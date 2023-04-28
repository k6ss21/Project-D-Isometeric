using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_SkyFallVFX : MonoBehaviour
{
    public GameObject AimSprite;
    public GameObject fallProjectilePrefab;


    public float minInstantiateInterval;
    public float maxInstantiateInterval;

    public Vector3 posOffset;
    // private float aimTimer;
    // public float aimTime;
    public bool isAiming;
    private bool aimSet;
    void Update()
    {
        // if (aimTimer > 0)
        // {
        //     aimTimer -= Time.deltaTime;

        // }

        if (isAiming && !aimSet )
        {
            // aimTimer = aimTime;
            AimSprite.SetActive(true);
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            AimSprite.transform.position = mousePos;
            
            if (Input.GetMouseButtonDown(0))
            {
                aimSet = true;
                var shootPos = mousePos;
                shootPos.z = 0;
                Vector3 shootDir = (shootPos - (shootPos + posOffset)).normalized;
                AimSprite.transform.position = shootPos;
               
                StartCoroutine(StartAttack(shootPos));
            }
        }
    }

    IEnumerator StartAttack(Vector3 shootPos)
    
    {
        InstantiateProjectile(shootPos,new Vector3(0, 0, 0) );
        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));;
        InstantiateProjectile(shootPos,new Vector3(0.1f, 0, 0) );

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos,new Vector3(-0.1f, 0, 0) );

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos,new Vector3(0.15f, 0, 0) );

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos,new Vector3(-0.15f, 0, 0) );
        isAiming = false;


    }

    void InstantiateProjectile(Vector3 shootPos, Vector3 changeOffset)
    {
        Vector3 shootDir = ((shootPos + changeOffset) - (shootPos + posOffset +changeOffset)).normalized;
        var fallProjectile4 = Instantiate(fallProjectilePrefab, shootPos + posOffset + changeOffset, Quaternion.identity);
        fallProjectile4.GetComponent<FallProjectile>().Setup(shootDir, 10);
    }
    


}
