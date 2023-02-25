using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_Speed : MonoBehaviour
{
    bool coolDown;
    float cooldownTime;
    Button button;
    public float speed;
    public float time;
    public static event Action<float,float> OnSpeedBoost;
    void Start()
    {
        button = GetComponent<Button>();
    }

    public void SpeedCall()
    {
        if (!coolDown)
        {
            Debug.Log("Player Speed Boost Active...");
            OnSpeedBoost?.Invoke(speed, time);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log("Ab_speed cooldown");
        }
    }

    IEnumerator CoolDownRoutine()
    {

        yield return new WaitForSeconds(cooldownTime);
        coolDown = false;
        button.enabled = true;

    }
}
