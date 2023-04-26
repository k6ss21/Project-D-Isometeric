using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ab_Regenesis : MonoBehaviour
{

    Player player;
    public float cooldownTime;
    bool coolDown;
    Button button;
   
    void Start()
    {
        player = FindObjectOfType<Player>();
        button = GetComponent<Button>();
        coolDown = false;
    }
    public void RegenesisCall()
    {
        if (!coolDown)
        {
            Debug.Log("Regenesis Trigger Active...");
            player.gameObject.SetActive(true);
            player.TakeHealth(50);
            coolDown = true;
            button.enabled = false;
            // StartCoroutine(CoolDownRoutine());

        }
        else
        {
            Debug.Log(" Cant use Regenesis Twice");
        }
        IEnumerator CoolDownRoutine()
        {

            yield return new WaitForSeconds(cooldownTime);
            coolDown = false;
            button.enabled = true;

        }
    }

}
