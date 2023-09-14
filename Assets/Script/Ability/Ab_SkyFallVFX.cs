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
    private CustomInput input = null;



    private void Awake()
    {
        input = new CustomInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    void Update()
    {
        // if (aimTimer > 0)
        // {
        //     aimTimer -= Time.deltaTime;

        // }



        if (isAiming && !aimSet)
        {
            // aimTimer = aimTime;
            // AimSprite.SetActive(true);
            // var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // mousePos.z = 0;
            // AimSprite.transform.position = mousePos;

            if (input.Ability.Touch.WasPerformedThisFrame())
            {
                if (ab_SkyFallAimRef.canSetAim)
                {
                    aimSet = true;
                    var touchPos = input.Ability.Touch.ReadValue<Vector2>();
                    Vector3 shootPos = new Vector3(touchPos.x, touchPos.y, 0);
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



