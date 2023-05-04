using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillPoints : MonoBehaviour
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


}
