using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ab_Healing : MonoBehaviour
{
    public int count;
    public float healthValue;
    bool coolDown;

    public float cooldownTime;
    public static event Action<float> OnAbilityHeal;
    Button button;


    void Start()
    {
        count = 0;
        button = GetComponent<Button>();
        coolDown = false;
    }

    public void HealCall()
    {
        if (!coolDown)
        {
            //Debug.Log("Player Healing...");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_Healing, this.transform.position);
            OnAbilityHeal?.Invoke(healthValue);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());
        }
        else
        {
           // Debug.Log("Ability cooldown");
        }
    }

    IEnumerator CoolDownRoutine()
    {

        yield return new WaitForSeconds(cooldownTime);
        coolDown = false;
        button.enabled = true;

    }

}
