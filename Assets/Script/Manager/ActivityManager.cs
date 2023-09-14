using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{
    public int totalActivitySlot;
    public int currentActivitySlot;

    public GameObject healingStatsUI_Prefab;
    public RectTransform backGroudUI;

    void OnEnable()
    {

    }
    void OnDisable()
    {

    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.T))
        // {
        //     MangeHealing();
        // }
    }

    void AddActivitySlot()
    {
        currentActivitySlot++;
        if (currentActivitySlot >= totalActivitySlot)
        {
            Debug.Log("Fulllll");
        }

    }

    void MangeHealing()
    {
        AddActivitySlot();
        var statsUI = Instantiate(healingStatsUI_Prefab, transform.position, Quaternion.identity);
        statsUI.transform.SetParent(backGroudUI);
        UpdateBackGroundSize();
    }

    void UpdateBackGroundSize()
    {
        backGroudUI.anchoredPosition = new Vector2(backGroudUI.anchoredPosition.x, backGroudUI.anchoredPosition.y +(-30));
        backGroudUI.sizeDelta = new Vector2 (backGroudUI.sizeDelta.x, backGroudUI.childCount * 60); 
    }



}
