using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoints : MonoBehaviour
{
    private int totalSkillPoints;
    private int currentSkillPoints;

    void OnEnable()
    {
        Reward.OnRewardCollected += AddSkillPoints;
    }

    void OnDisable()
    {
        Reward.OnRewardCollected -= AddSkillPoints;
    }
    public void AddSkillPoints(int amount)
    {
        currentSkillPoints += amount;

    }


}
