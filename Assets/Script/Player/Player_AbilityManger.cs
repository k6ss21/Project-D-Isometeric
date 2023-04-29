using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_AbilityManger : MonoBehaviour
{

    PlayerAttack playerAttack;

    void OnEnable()
    {
        Ab_Lightning.OnLightningTrigger += Ab_LightningInitiate;
        Ab_SkyFall.OnSkyFallTrigger += Ab_SkyFallInitiate;
    }

    void OnDisable()
    {
        Ab_Lightning.OnLightningTrigger -= Ab_LightningInitiate;
          Ab_SkyFall.OnSkyFallTrigger -= Ab_SkyFallInitiate;
    }

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    #region Ab_Lightning ATTACK

    [SerializeField] GameObject lightningVfxPrefab;

    [SerializeField] Transform lightningPoint;
    void Ab_LightningInitiate()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.lightningSound, transform.position);
        var lightningVfxGameObj = Instantiate(lightningVfxPrefab, lightningPoint.position, Quaternion.identity);
    }

    #endregion

    # region Ab_SKYFALL ATTACK

    [SerializeField] GameObject skyFallVfxPrefab;

    void Ab_SkyFallInitiate()
    {
        var skyFallVfx = Instantiate(skyFallVfxPrefab, transform.position, Quaternion.identity);
        playerAttack.SetAblityActive(true);
        skyFallVfx.GetComponent<Ab_SkyFallVFX>().isAiming = true;
    }
    #endregion
}
