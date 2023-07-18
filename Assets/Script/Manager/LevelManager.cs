using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour, IDataPersistence
{
    public static LevelManager instance;
    string levelName;

    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Image fillImage;
    private float target;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelName = SceneManager.GetActiveScene().name;
        // Debug.Log("Next Level : " + levelName);
    }

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
    public void LoadNextLevel()
    {
        // Debug.Log("Loading Next Level...");
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

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

    }

    public void SaveData(GameData data)
    {
        data.levelName = this.levelName;
    }
}
