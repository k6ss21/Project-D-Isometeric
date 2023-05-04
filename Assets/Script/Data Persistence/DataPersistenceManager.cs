using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }
        instance = this;
    }

    void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("No Game Data Found. Initialize Default Game Data");
            NewGame();
        }
    }
    public void LoadGame()
    {
        
    }

     private void OnApplicationQuit() {
        SaveGame();
    }
}
