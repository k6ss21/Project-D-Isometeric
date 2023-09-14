using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_WarmUp : MonoBehaviour
{
    public float cooldownTime;

    public float tempValue;
    bool coolDown;
    Button button;
    public static event Action<float> OnWarmUpTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void WarmUpCall()
    {
        if (!coolDown)
        {
            //Debug.Log("WarmUp Trigger Active...");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_WarmUp, this.transform.position);
            OnWarmUpTrigger?.Invoke(tempValue);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
           // Debug.Log(" WWarmUp CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}

