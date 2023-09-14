using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Ab_GrowBig : MonoBehaviour
{
    public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnGrowBigTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void GrowBigCall()
    {
        if (!coolDown)
        {
           // Debug.Log("GrowBig Trigger Active...");
            OnGrowBigTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
           // Debug.Log(" GrowBig CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
