using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUpSystem : MonoBehaviour, IDataPersistence
{
    public int level;
    public int currentXp;
    public int gainedXp;
    public int requiredXp;

    public int[] reqLevelXp;
    public Slider LevelSlider;
    public TextMeshProUGUI levelNumberText;

    //   test
    public float sliderValue;


    void OnEnable()
    {
        Reward.OnRewardCollected += GainXp;
        GameOver.OnRetry += LoseXp;
    }
    void OnDisable()
    {
        Reward.OnRewardCollected -= GainXp;
        GameOver.OnRetry -= LoseXp;
    }
    void Start()
    {
        level = 1;
        levelNumberText.text = level.ToString();
        requiredXp = reqLevelXp[1];
        UpdateLevelBar();
    }

    void Update()
    {
        
        if (gainedXp >= requiredXp)
        {
            LevelUp();
        }

    }

    void GainXp(int xpGained)
    {
        int gain = (int)xpGained / (int)2;
        gainedXp += gain;
        UpdateLevelBar();

    }
    void LoseXp(int xpLosed)
    {
        int lose = (int)xpLosed / (int)2;
        gainedXp -= lose;
        UpdateLevelBar();
        if(gainedXp <=0)
        {
            gainedXp = 0;
            UpdateLevelBar();
        }

    }

    void UpdateLevelBar()
    {
        currentXp = gainedXp - reqLevelXp[level - 1];
        sliderValue = (float)currentXp / (float)(requiredXp - reqLevelXp[level - 1]);
        LevelSlider.value = sliderValue;

    }

    void LevelUp()
    {

        if (level >= reqLevelXp.Length)
        {
           // Debug.Log("Max level reached");
            return;
        }
        level++;
        levelNumberText.text = level.ToString();
        requiredXp = reqLevelXp[level];
        UpdateLevelBar();
    }

    public void LoadData(GameData data)
    {
        this.gainedXp = data.gainedXp;
    }

    public void SaveData(GameData data)
    {
        data.gainedXp = this.gainedXp;
    }
}
