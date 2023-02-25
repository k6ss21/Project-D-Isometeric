using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ab_shield : MonoBehaviour
{
    public float cooldownTime;
    bool coolDown;
    Button button;
    public float time;
    public static event Action<float> OnShieldActive;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void ShieldCall()
    {
        if (!coolDown)
        {
            Debug.Log("Player Shield Active...");
            OnShieldActive?.Invoke(time);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log("Ab_shield cooldown");
        }
    }

    IEnumerator CoolDownRoutine()
    {

        yield return new WaitForSeconds(cooldownTime);
        coolDown = false;
        button.enabled = true;

    }

}
