using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas skillMenuCanvas;
    [SerializeField] private Canvas SettingCanvas;
    [SerializeField] private GameObject LevelsCanvas;
    [SerializeField] private Button playButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button skillMenuButton;
    [SerializeField] private Button settingsButton;

    public string newGameLevelName = "Level_3";
    private string currentLevelName;

    void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueButton.gameObject.SetActive(false);
            currentLevelName = newGameLevelName;
        }
        SettingCanvas.gameObject.SetActive(false);
        LevelsCanvas.gameObject.SetActive(false);
    }
    public void PlayButton()
    {
        // Debug.Log("Play");
        // DisableAllButtonAfterPress();
        DataPersistenceManager.instance.NewGame();
        LevelManager.instance.LoadLevel(newGameLevelName);

    }
    public void ContinueButton()
    {
        DisableAllButtonAfterPress();
        LevelManager.instance.LoadLevel(currentLevelName);
    }
    public void SkillMenuButton()
    {
        mainCanvas.gameObject.SetActive(false);
        skillMenuCanvas.gameObject.SetActive(true);
    }
    public void SettingsButton()
    {
        mainCanvas.gameObject.SetActive(false);
        SettingCanvas.gameObject.SetActive(true);
    }
    public void SettingsBackButton()
    {
        mainCanvas.gameObject.SetActive(true);
        SettingCanvas.gameObject.SetActive(false);
    }
    public void skillMenuCloseButton()
    {
        mainCanvas.gameObject.SetActive(true);
        skillMenuCanvas.gameObject.SetActive(false);
    }
    public void LevelsButton()
    {
        mainCanvas.gameObject.SetActive(false);
        LevelsCanvas.SetActive(true);
    }
    public void LevelsCloseButton()
    {
        mainCanvas.gameObject.SetActive(true);
        LevelsCanvas.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    private void DisableAllButtonAfterPress()
    {
        playButton.interactable = false;
        continueButton.interactable = false;
        settingsButton.interactable = false;
        skillMenuButton.interactable = false;
    }
    public void LoadData(GameData data)
    {
        this.currentLevelName = data.levelName;
    }

    public void SaveData(GameData data)
    {
        data.levelName = this.currentLevelName;
    }
}
