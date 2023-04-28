using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_Rehabilitation : MonoBehaviour
{
    
    public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnRehabilitationTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void RehabilitationCall()
    {
        if (!coolDown)
        {
            Debug.Log("Rehabilitation Trigger Active...");
            OnRehabilitationTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
           // StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" Cant use Rehabilitation Twice");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
