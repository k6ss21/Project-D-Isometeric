using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFill : MonoBehaviour
{
    AbilityData abilityData;
    public List<GameObject> abilityButtonList;

    void Awake()
    {
        abilityData = FindObjectOfType<AbilityData>();
        this.abilityButtonList = abilityData.abilityButtonList;

    }

    void Start()
    {
        UpdateAbilityButton();
    }

    void UpdateAbilityButton()
    {
        int listCount = abilityButtonList.Count;
        for (int i = 0; i < listCount; i++)
        {
            var tempObj = abilityButtonList[i];
            Instantiate(tempObj,transform);
        }


    }
}
