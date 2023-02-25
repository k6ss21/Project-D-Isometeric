using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Ab_SlowLevelTimer : MonoBehaviour
{
    public int count;
    bool coolDown;

    public float cooldownTime;

    public float multi;
    public float time;
    public static event Action<float,float> OnSlowLevelTimer;
    Button button;

    void Start()
    {
        count = 0;
        button = GetComponent<Button>();
        coolDown = false;
    }

    public void SlowTimerCall()
    {
        if (!coolDown)
        {
           // Debug.Log("Slow Down Level Timer...");
            OnSlowLevelTimer?.Invoke(multi,time);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());
        }
        else
        {
            Debug.Log("Slow Down Level Timer Ability cooldown");
        }
    }

    IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        coolDown = false;
        button.enabled = true;

    }

}
