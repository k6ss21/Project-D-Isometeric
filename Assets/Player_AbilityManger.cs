using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_AbilityManger : MonoBehaviour
{

    void OnEnable()
    {
        Ab_Lightning.OnLightningTrigger += Ab_LightningInitiate;
    }

    void OnDisable()
    {
         Ab_Lightning.OnLightningTrigger -= Ab_LightningInitiate;
    }

    #region ABILITY ATTACK

    [SerializeField] GameObject lightningVfxPrefab;
  
    [SerializeField] Transform lightningPoint;
    void Ab_LightningInitiate()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.lightningSound, transform.position);
        var lightningVfxGameObj = Instantiate(lightningVfxPrefab, lightningPoint.position, Quaternion.identity);
    }

    #endregion

}
