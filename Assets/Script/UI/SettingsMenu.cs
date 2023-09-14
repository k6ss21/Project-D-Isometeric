using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingsMenu : MonoBehaviour, IDataPersistence
{
    float volumeAmount = 1f;
    public TextMeshProUGUI VolumeAmountText;
    public Canvas pauseMenuCanvas;

    void Start()
    {
        UpdateVolumeAmount();

    }

    public void AddVolumeButton()
    {
      //  Debug.Log("Add Volume");
        volumeAmount += 0.1f;
        UpdateVolumeAmount();
        if (volumeAmount >= 1f)
        {
            volumeAmount = 1f;
            UpdateVolumeAmount();
        }
    }
    public void ReduceVolumeButton()
    {
      //  Debug.Log("Reduce Volume");
        volumeAmount -= 0.1f;
        UpdateVolumeAmount();
        if (volumeAmount <= 0f)
        {
            volumeAmount = 0f;
            UpdateVolumeAmount();
        }
    }

    public void UpdateVolumeAmount()
    {
        AudioManager.instance.masterVolume = volumeAmount;
        VolumeAmountText.text = volumeAmount.ToString("F1");
    }

    public void LoadData(GameData data)
    {
        this.volumeAmount = data.masterVolume;
        AudioManager.instance.masterVolume = data.masterVolume;
    }

    public void SaveData(GameData data)
    {
        data.masterVolume = this.volumeAmount;
    }
}
