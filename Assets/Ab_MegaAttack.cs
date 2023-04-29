using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Ab_MegaAttack : MonoBehaviour
{
    public float cooldownTime;
    bool coolDown;
    Button button;
    public static event Action OnMegaAttackTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void MegaAttackCall()
    {
        if (!coolDown)
        {
            Debug.Log("MegaAttack Trigger Active...");
            OnMegaAttackTrigger?.Invoke();
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" MegaAttack CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
