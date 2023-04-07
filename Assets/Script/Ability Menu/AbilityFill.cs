using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFill : MonoBehaviour
{
    AbilityData abilityData;
    public List<GameObject> abilityButtonList;
    AbilityBar abilityBar;

    void OnEnable()
    {
        AbilityData.OnAbilityDataUpdate += UpdateAbilityList;
    }
    void OnDisable()
    {
        AbilityData.OnAbilityDataUpdate -= UpdateAbilityList;
    }
    void Awake()
    {
        abilityBar = GetComponent<AbilityBar>();
        abilityData = FindObjectOfType<AbilityData>();
        this.abilityButtonList = abilityData.abilityButtonList;

    }

    void Start()
    {
        ClearAbilityChildGameObject();
        UpdateAbilityButton();
    }

    void UpdateAbilityButton()
    {
        int listCount = abilityButtonList.Count;
        for (int i = 0; i < listCount; i++)
        {
            var tempObj = abilityButtonList[i];
            Instantiate(tempObj, transform);
        }
        abilityBar.CurrentAbilityList = abilityButtonList;

    }

    void UpdateAbilityList()
    {
        this.abilityButtonList = abilityData.abilityButtonList;
        ClearAbilityChildGameObject();
        UpdateAbilityButton();
    }

    void ClearAbilityChildGameObject()
    {
        int childCount = transform.childCount;
      //  Debug.Log("ChildCount = " + childCount);
        if (childCount > 0)
        {
            foreach(Transform child in transform)
            {
               // Debug.Log("Destroyed = "+ child.gameObject.name);
                Destroy(child.gameObject);
            }

        }
    }
}
