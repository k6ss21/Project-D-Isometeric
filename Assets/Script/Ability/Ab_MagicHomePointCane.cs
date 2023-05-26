using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ab_MagicHomePointCane : MonoBehaviour
{
    public float cooldownTime;
    public float activeTime;
    bool coolDown;
    Button button;
    public static event Action<float> OnMagicHomePointCanePlaceTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void MagicHomePointCanePlaceCall()
    {
        if (!coolDown)
        {
            Debug.Log("MagicHomePointCanePlace Trigger Active...");
            OnMagicHomePointCanePlaceTrigger?.Invoke(activeTime);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" MagicHomePointCane Ability CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
