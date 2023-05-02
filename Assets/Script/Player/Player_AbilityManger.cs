using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_AbilityManger : MonoBehaviour
{
    Player player;
    IsoCharacterController isoCharacterController;
    PlayerAttack playerAttack;
    PlayerAnimationManger playerAnimationManger;



    void OnEnable()
    {
        Ab_Lightning.OnLightningTrigger += Ab_LightningInitiate;
        Ab_SkyFall.OnSkyFallTrigger += Ab_SkyFallInitiate;
        Ab_MagicHomePointCane.OnMagicHomePointCanePlaceTrigger += Ab_MagicHomePointInitiate;
        Ab_Decamp.OnDecampTrigger += Ab_DecampInitiate;
    }

    void OnDisable()
    {

        Ab_Lightning.OnLightningTrigger -= Ab_LightningInitiate;
        Ab_SkyFall.OnSkyFallTrigger -= Ab_SkyFallInitiate;
        Ab_MagicHomePointCane.OnMagicHomePointCanePlaceTrigger -= Ab_MagicHomePointInitiate;
        Ab_Decamp.OnDecampTrigger -= Ab_DecampInitiate;
    }

    void Start()
    {
        isoCharacterController = GetComponent<IsoCharacterController>();
        player = GetComponent<Player>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimationManger = GetComponent<PlayerAnimationManger>();
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

    #region Ab_SKYFALL ATTACK

    [SerializeField] GameObject skyFallVfxPrefab;

    void Ab_SkyFallInitiate()
    {
        var skyFallVfx = Instantiate(skyFallVfxPrefab, transform.position, Quaternion.identity);
        playerAttack.SetAttackAbilityActive(true);
        skyFallVfx.GetComponent<Ab_SkyFallVFX>().isAiming = true;
    }
    #endregion

    #region AB_GROWBIG 

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.T))
    //     {
    //         Ab_GrowBig_Grow();
    //     }
    // }

    void Ab_GrowBig_Grow()
    {
        playerAttack.SetAbilityActive(true);
        playerAnimationManger.Ab_GrowBig_Grow();
    }

    public void OnAbilityGrowBig()
    {
        playerAttack.SetAbilityActive(false);
        this.gameObject.transform.parent.localScale = new Vector3(2, 2, 2);
    }

    #endregion

    #region Ab_MagicHomePoint

    [SerializeField] GameObject magicHomePointStickPrefab;
    public Transform labTeleportPoint;

    public Canvas skillCanvas;

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.T))
    //     {
    //         Ab_MagicHomePointInitiate(5f);
    //     }
    // }

    void Ab_MagicHomePointInitiate(float time)
    {
        var magicHomePointStick = Instantiate(magicHomePointStickPrefab, transform.position, Quaternion.identity);

        magicHomePointStick.GetComponent<MagicHomePointStick>().InitiateCoroutine(time);
        magicHomePointStick.GetComponent<HomePoint>().labTeleportPoint = labTeleportPoint;
        magicHomePointStick.GetComponent<HomePoint>().skillCanvas = skillCanvas;

    }

    #endregion

    #region Ab_Decamp

    void Ab_DecampInitiate()
    {
        isoCharacterController.Teleport(labTeleportPoint.position);
    }
    #endregion

}
