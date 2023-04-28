using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_SkyFall : MonoBehaviour
{
   public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnSkyFallTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void SkyFallCall()
    {
        if (!coolDown)
        {
            Debug.Log("SkyFall Trigger Active...");
            OnSkyFallTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
           // StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" Cant use SkyFall Twice");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
