using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private TextAsset defaultGameDataFile;

    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistence();
        LoadGame();
    }

    public void NewGame()
    {
        Debug.Log("New Game Created");
        this.gameData = new GameData();
        // string defaultGameData = defaultGameDataFile.ToString();
        // Debug.Log("Default Game Data : " + defaultGameData);
        // dataHandler.CreateNewGameData(gameData, defaultGameData);

    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        Debug.Log("Saved Skill count = " + gameData.skillPoints);

        dataHandler.Save(gameData);
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No Game Data Found. Initialize Default Game Data");
            NewGame();
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        // Debug.Log("Loaded Skill count = " + gameData.skillPoints);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistence()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void Delete()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log("File Not Found!!");
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(DataPersistenceManager))]
class CustomDeleteButton : Editor
{
    public override void OnInspectorGUI()
    {
        var dataPersistenceManager = (DataPersistenceManager)target;
        if (dataPersistenceManager == null) return;
        if (GUILayout.Button("Delete Persistent File"))
        {
            dataPersistenceManager.Delete();
        }
    }
}

#endif