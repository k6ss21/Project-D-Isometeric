using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    [field: Header("Sick Char")]
    [field: SerializeField] public EventReference healStarted { get; private set; }
    [field: SerializeField] public EventReference coughing { get; private set; }




    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootSteps { get; private set; }
    [field: SerializeField] public EventReference slashAttack { get; private set; }
     [field: SerializeField] public EventReference swordSlash { get; private set; }
    [field: SerializeField] public EventReference PlayerHurt { get; private set; }
    [field: SerializeField] public EventReference ProjectileShoot { get; private set; }
    [field: SerializeField] public EventReference TeleportToLab { get; private set; }
    [field: SerializeField] public EventReference dash { get; private set; }



    [field: Header("Env SFX")]
    [field: SerializeField] public EventReference FirePlace { get; private set; }
    [field: SerializeField] public EventReference gateDestroy { get; private set; }
    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Enemy")]
    [field: SerializeField] public EventReference enemyDamage { get; private set; }
    [field: SerializeField] public EventReference enemyDead { get; private set; }
    [field: SerializeField] public EventReference batsFlying { get; private set; }
    [field: SerializeField] public EventReference singleBatFlying { get; private set; }

    [field: SerializeField] public EventReference enemySpawn { get; private set; }

    [field: Header("UI")]
    [field: SerializeField] public EventReference clickSound { get; private set; }

    [field: Header("ABILITY")]
    [field: SerializeField] public EventReference lightningSound { get; private set; }
    [field: SerializeField] public EventReference lightningHitGround { get; private set; }

    [field: SerializeField] public EventReference ab_decamp { get; private set; }
    [field: SerializeField] public EventReference Ab_CureSimulator { get; private set; }
    [field: SerializeField] public EventReference Ab_SlowLevelTimer { get; private set; }
    [field: SerializeField] public EventReference Ab_DamageDebuff { get; private set; }
    [field: SerializeField] public EventReference Ab_Healing { get; private set; }
    [field: SerializeField] public EventReference Ab_Immunity { get; private set; }
    [field: SerializeField] public EventReference Ab_InstantCureSimulator { get; private set; }
    [field: SerializeField] public EventReference Ab_MagicHomePointCane { get; private set; }
    [field: SerializeField] public EventReference Ab_Regenesis { get; private set; }
    [field: SerializeField] public EventReference Ab_Rehabilitation { get; private set; }
    [field: SerializeField] public EventReference Ab_InstantRehabilitation { get; private set; }
    [field: SerializeField] public EventReference Ab_Sheild { get; private set; }
    [field: SerializeField] public EventReference Ab_SpawnBreaker { get; private set; }
    [field: SerializeField] public EventReference Ab_StopTimer { get; private set; }
    [field: SerializeField] public EventReference Ab_Speed { get; private set; }
    [field: SerializeField] public EventReference Ab_WarmUp { get; private set; }



    public static FMODEvents instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMODEvents instance in scene");
        }
        instance = this;
    }
}
