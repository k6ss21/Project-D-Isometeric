using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pause;
    public Canvas pauseCanvas;
    public Canvas settingsCanvas;
    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        PauseResume();
    }
    void PauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
                pause = true;
            }
            else
            {
                pauseCanvas.gameObject.SetActive(false);
                settingsCanvas.gameObject.SetActive(false);
                Time.timeScale = 1f;
                pause = false;
            }
        }
    }
    public void ResumeButton()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    public void SettingsButton()
    {
        Debug.Log("Settings Button Pressed");
        pauseCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
        this.GetComponent<SettingsMenu>().UpdateVolumeAmount();
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        LevelManager.instance.LoadLevel("Main Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        settingsCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);

    }

}
