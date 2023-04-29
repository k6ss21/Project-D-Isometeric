using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class Ab_SkyFallVFX : MonoBehaviour
{
    public GameObject AimSprite;
    public GameObject fallProjectilePrefab;

    public Ab_SkyFallAimRef ab_SkyFallAimRef;


    public float minInstantiateInterval;
    public float maxInstantiateInterval;

    public Vector3 posOffset;
    // private float aimTimer;
    // public float aimTime;
    public bool isAiming;
    private bool aimSet;

    public static event Action<bool> OnAbilityEnd;

    void Update()
    {
        // if (aimTimer > 0)
        // {
        //     aimTimer -= Time.deltaTime;

        // }

        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     isAiming = true;
        // }

        if (isAiming && !aimSet)
        {
            // aimTimer = aimTime;
            AimSprite.SetActive(true);
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            AimSprite.transform.position = mousePos;

            if (Input.GetMouseButtonDown(0))
            {
                if (ab_SkyFallAimRef.canSetAim)
                {
                    aimSet = true;
                    var shootPos = mousePos;
                    shootPos.z = 0;
                    Vector3 shootDir = (shootPos - (shootPos + posOffset)).normalized;
                    AimSprite.transform.position = shootPos;
                    StartCoroutine(StartAttack(shootPos));
                }
                else
                {
                    Debug.Log("Cant Use Here!!!");
                }
            }
        }
    }

    IEnumerator StartAttack(Vector3 shootPos)

    {
        AimSprite.GetComponent<SpriteRenderer>().enabled = false;
        InstantiateProjectile(shootPos, new Vector3(0, 0, 0));
        OnAbilityEnd?.Invoke(false);
        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval)); ;
        InstantiateProjectile(shootPos, new Vector3(0.1f, 0, 0));

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos, new Vector3(-0.1f, 0, 0));

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos, new Vector3(0.15f, 0, 0));

        yield return new WaitForSeconds(Random.Range(minInstantiateInterval, maxInstantiateInterval));
        InstantiateProjectile(shootPos, new Vector3(-0.15f, 0, 0));
        isAiming = false;


    }

    void InstantiateProjectile(Vector3 shootPos, Vector3 changeOffset)
    {
        Vector3 shootDir = ((shootPos + changeOffset) - (shootPos + posOffset + changeOffset)).normalized;
        var fallProjectile4 = Instantiate(fallProjectilePrefab, shootPos + posOffset + changeOffset, Quaternion.identity);
        fallProjectile4.GetComponent<FallProjectile>().Setup(shootDir, 10);
    }


}



