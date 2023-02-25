using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AbilityData : MonoBehaviour
{
   static AbilityData instance;

   public List<GameObject> abilityButtonList;

   public static event Action OnAbilityDataUpdate;

    void OnEnable()
    {
        AbilitySpace.OnStoreData += StoreAbilityList;
    }
      void OnDisable()
    {
        AbilitySpace.OnStoreData -= StoreAbilityList;
    }


     void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void StoreAbilityList(List<GameObject> list)
    {
        abilityButtonList = list;
        OnAbilityDataUpdate?.Invoke();
    }

}
