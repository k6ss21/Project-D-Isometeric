using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_Lightning : MonoBehaviour
{

    public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnLightningTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void LightningCall()
    {
        if (!coolDown)
        {
           // Debug.Log("Lightning Attack Trigger Active...");
            OnLightningTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
          //  Debug.Log("Lightning Attack  cooldown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }

}
