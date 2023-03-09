using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    [field: Header("Heal SFX")]
    [field: SerializeField] public EventReference healStarted { get; private set; }


    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootSteps { get; private set; }
    [field: SerializeField] public EventReference slashAttack { get; private set; }
     [field: SerializeField] public EventReference PlayerHurt { get; private set; }

    [field: Header("Env SFX")]
    [field: SerializeField] public EventReference FirePlace { get; private set; }
    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Enemy")]
    [field: SerializeField] public EventReference enemyDamage { get; private set; }
     [field: SerializeField] public EventReference batsFlying { get; private set; }
     [field: SerializeField] public EventReference singleBatFlying { get; private set; }

    [field: Header("UI")]
    [field: SerializeField] public EventReference clickSound { get; private set; }



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
