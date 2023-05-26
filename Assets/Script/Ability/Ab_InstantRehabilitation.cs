using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_InstantRehabilitation : MonoBehaviour
{
    
    public float cooldownTime;

    public float amountMulti;
    bool coolDown;
    Button button;
    public static event Action<float> OnInstantRehabilitationTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void InstantRehabilitationCall()
    {
        if (!coolDown)
        {
            Debug.Log("Instant Rehabilitation Trigger Active...");
            OnInstantRehabilitationTrigger?.Invoke(amountMulti);
            coolDown = true;
            button.enabled = false;
           // StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" Can't use Instant Rehabilitation Twice");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
