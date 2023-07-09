using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Ab_EnemyDamageDeBuff : MonoBehaviour
{
    public float cooldownTime;
    public float debuffMulti;
    public float debuffTime;
    bool coolDown;
    Button button;
    public static event Action<float, float> OnEnemyDamageDeBuffTrigger;
    void Start()
    {
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void EnemyDamageDeBuffCall()
    {
        if (!coolDown)
        {
            Debug.Log("EnemyDamageDeBuff Trigger Active...");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Ab_DamageDebuff, this.transform.position);
            OnEnemyDamageDeBuffTrigger?.Invoke(debuffMulti, debuffTime);
            coolDown = true;
            button.enabled = false;
            StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" EnemyDamageDeBuff CoolDown");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }
}
