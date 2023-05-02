using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_Decamp : MonoBehaviour
{
    public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnDecampTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void DecampCall()
    {
        if (!coolDown)
        {
            Debug.Log("Decamp Trigger Active...");
            OnDecampTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" Decamp CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
