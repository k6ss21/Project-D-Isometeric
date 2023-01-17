using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class AbilitySpace : MonoBehaviour
{
    public List<GameObject> AbilityButtonList;


    public static event Action<List<GameObject>> OnStoreData;
    public void UpdateList()
    {
        AbilityButtonList.Clear();
        foreach (Transform child in transform)
        {
            var tempPrefab = child.GetComponent<AbilitySlot>().abilityPrefab;
            if (tempPrefab != null)
            {
                AbilityButtonList.Add(tempPrefab);
            }
        }
    }

    public void StoreData()
    {
        OnStoreData?.Invoke(AbilityButtonList);
    }
}
