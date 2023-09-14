using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_SpawnBreaker : MonoBehaviour
{
     public float cooldownTime;

     public float time;
    bool coolDown;
    Button button;
    public static event Action<float> OnSpawnBreakerTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void SpawnBreakerCall()
    {
        if (!coolDown)
        {
           // Debug.Log("SpawnBreaker Trigger Active...");
             AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_SpawnBreaker, this.transform.position);
            OnSpawnBreakerTrigger?.Invoke(time);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            //Debug.Log("SpawnBreaker Ability CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
