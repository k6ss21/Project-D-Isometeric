using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_Immunity : MonoBehaviour
{
    public float cooldownTime;

    public float immunityValue;
    bool coolDown;
    Button button;
    public static event Action<float> OnImmunityTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void ImmunityCall()
    {
        if (!coolDown)
        {
           // Debug.Log("Immunity Trigger Active...");
             AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_Immunity,this.transform.position);
            OnImmunityTrigger?.Invoke(immunityValue);
            coolDown = true;
            button.enabled = false;
           StartCoroutine(CoolDownRoutine());

        }
        else
        {
         //   Debug.Log(" Ability Immunity Cooldown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
