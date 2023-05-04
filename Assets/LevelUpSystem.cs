using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUpSystem : MonoBehaviour
{
    public int level;
    public int currentXp;
    public int GainedXp;
    public int requiredXp;

    public int[] reqLevelXp;
    public Slider LevelSlider;
    public TextMeshProUGUI levelNumberText;

    //   test
    public float sliderValue;

    void Start()
    {
        level = 1;
        levelNumberText.text = level.ToString();
        requiredXp = reqLevelXp[1];
        UpdateLevelBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GainXp(20);
        }
           if (GainedXp >= requiredXp)
        {
            LevelUp();
        }
      
    }

    void GainXp(int xpGained)
    {
        GainedXp += xpGained;
        UpdateLevelBar();

    }

    void UpdateLevelBar()
    {
        currentXp = GainedXp - reqLevelXp[level - 1];
        sliderValue = (float)currentXp / (float)(requiredXp - reqLevelXp[level - 1]);
        LevelSlider.value = sliderValue;
       
    }

    void LevelUp()
    {
  
     if(level >= reqLevelXp.Length)
     {
          Debug.Log("Max level reached");
          return;
     }
        level++;
        levelNumberText.text = level.ToString();
        requiredXp = reqLevelXp[level];
        UpdateLevelBar();
    }

}
