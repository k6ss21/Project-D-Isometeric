
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_CureStimulator : MonoBehaviour
{
    public float cooldownTime;
    public float amountMulti;
    bool coolDown;
    Button button;
    public static event Action<float> OnCureStimulateTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void CureStimulateCall()
    {
        if (!coolDown)
        {
            Debug.Log("CureStimulate Trigger Active...");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_CureSimulator, this.transform.position);
            OnCureStimulateTrigger?.Invoke(amountMulti);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" CureStimulator Ability CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
