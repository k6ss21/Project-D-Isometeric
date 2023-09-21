using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour, IDataPersistence
{
    public static LevelManager instance;
    string levelName;
    int levelIndexNumber;
    int counter = 0;
    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Image fillImage;


    private float target;
    //test
    int number;

    string level;

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
    void OnEnable()
    {
       // SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }

    void OnDisable()
    {
       // SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnLoaded;
    }

    void OnSceneUnLoaded(Scene scene)
    {
      //StartCoroutine(SaveLevelInfo());
        
        number = SceneManager.GetActiveScene().buildIndex + 1;
        level =GetSceneNameFromBuildIndex(number) ;
        // if (level == "Main Menu" || number != 0)
        // {
        //     Debug.Log("Main Menu");
        // }
        // else
        if(number != 0)
         {
           //Debug.Log("Next Level : " + level + levelIndexNumber);          
            levelName = level;
            levelIndexNumber = number;
         }

    }

    // IEnumerator SaveLevelInfo()
    // {
        
    //     yield return new WaitForSeconds(.5f);
       
    //     // Debug.Log("Next Level : " + levelName);
    // }

    public async void LoadLevel(string sceneName)
    {
        target = 0;
        fillImage.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        if (mainMenu != null)
        {
            mainMenu.SetActive(false);
        }
        loadingCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;

        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        //await Task.Delay(100);
        loadingCanvas.SetActive(false);

    }
    void Update()
    {
        fillImage.fillAmount = Mathf.MoveTowards(fillImage.fillAmount, target, 3 * Time.deltaTime);

    }
    public void LoadLastPlayedLevel()
    {
        LoadLevel(levelName);
    }
    public void LoadNextLevel()
    {
        // Debug.Log("Loading Next Level...");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        LoadLevel(GetSceneNameFromBuildIndex(sceneIndex));
    }
    public void ReloadLevel()
    {
        // Debug.Log("Loading Next Level...");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        LoadLevel(GetSceneNameFromBuildIndex(sceneIndex));
    }

    public static string GetSceneNameFromBuildIndex(int index)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(index);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        return sceneName;
    }


    public void LoadData(GameData data)
    {
        this.levelIndexNumber = data.levelIndexNumber;
        this.levelName = data.levelName;
    }

    public void SaveData(GameData data)
    {
        data.levelName = this.levelName;
        data.levelIndexNumber = this.levelIndexNumber;
    }
}
