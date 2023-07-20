using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AbilityData : MonoBehaviour
{
   static AbilityData instance;

   public List<GameObject> abilityButtonList;

   public static event Action<AbilityData> OnAbilityDataUpdate;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        AbilitySpace.OnStoreData += StoreAbilityList;
    }
      void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        AbilitySpace.OnStoreData -= StoreAbilityList;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnAbilityDataUpdate?.Invoke(this);
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
        OnAbilityDataUpdate?.Invoke(this);
    }

}
