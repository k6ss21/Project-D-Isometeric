using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillPoints : MonoBehaviour, IDataPersistence
{
    private int totalSkillPoints;
    [field: SerializeField] public int currentSkillPoints { get; private set; }
    public TextMeshProUGUI earnedSkillPointText;

    void OnEnable()
    {
        Reward.OnRewardCollected += AddSkillPoints;
    }

    void OnDisable()
    {
        Reward.OnRewardCollected -= AddSkillPoints;
    }
    void Start()
    {
        UpdateUIText();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //   ScreenCapture.CaptureScreenshot("ScreenShot.png");
            //GainXp(100);
            Debug.Log("Current Skill Points = " + currentSkillPoints);
        }
    }
    public void AddSkillPoints(int amount)
    {
        currentSkillPoints += amount;
        UpdateUIText();

    }

    public void RemoveSkillPoints(int amount)
    {
        currentSkillPoints -= amount;
        UpdateUIText();
    }
    public void UpdateUIText()
    {
        earnedSkillPointText.text = currentSkillPoints.ToString();
    }

    public void LoadData(GameData data)
    {
        this.currentSkillPoints = data.skillPoints;
        //UpdateUIText();
    }

    public void SaveData(GameData data)
    {
        data.skillPoints = this.currentSkillPoints;

    }
}
