using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AbilityDetailsBox : MonoBehaviour
{

    public TextMeshProUGUI abilityNameText;
    public TextMeshProUGUI abilityDescriptionText;
    public TextMeshProUGUI errorText;

    public Button unlockButton;
    public AbilityIcon abilityIcon;
    public SkillPoints skillPointsManager;
    public LevelUpSystem levelUpSystem;

    private int skillPointsNeed;
    void OnEnable()
    {
        AbilityIcon.OnAbilityIconClick += UpdateDetailsBox;
    }
    void OnDisable()
    {
        AbilityIcon.OnAbilityIconClick -= UpdateDetailsBox;
    }

    void Awake()
    {
        skillPointsManager = FindObjectOfType<SkillPoints>();
        levelUpSystem = skillPointsManager.GetComponent<LevelUpSystem>();
        unlockButton.interactable = false;
    }
    private void UpdateDetailsBox(Ab_Details ab_Details, AbilityIcon ab_Icon)
    {
        abilityIcon = ab_Icon;
        skillPointsNeed = ab_Details.skillPointsNeeded;
        UIShowHide(true);
        if (ab_Icon.isLocked)
        {
            if (ab_Icon.levelNeeded <= levelUpSystem.level) // Ability is locked and Can Unlock.
            {
                unlockButton.interactable = true;
                if (skillPointsManager.currentSkillPoints >= skillPointsNeed)
                {
                    errorText.color = Color.white;
                    errorText.text = $"{skillPointsNeed} SP";
                }
                else
                {
                     errorText.color = Color.red;
                    errorText.text = $"{skillPointsNeed} SP"; 
                }
            }
            else
            {
                unlockButton.interactable = false; // Ability is locked and Cant Unlock.
                errorText.color = Color.red;
                errorText.text = $"Level {ab_Icon.levelNeeded} Needed";
            }
        }
        else
        {
            unlockButton.interactable = false;  //Ability is Unlocked already.
            errorText.color = Color.white;
            errorText.text = $"";
        }
        UpdateAbilityDetailsBoxText(ab_Details.name, ab_Details.description);
    }

    private void UIShowHide(bool value)
    {
        unlockButton.gameObject.SetActive(value);
        abilityNameText.gameObject.SetActive(value);
        abilityDescriptionText.gameObject.SetActive(value);
    }

    private void UpdateAbilityDetailsBoxText(string name, string description)
    {
        abilityNameText.text = name.ToString();
        abilityDescriptionText.text = description.ToString();
    }

    public void OnUnlockButtonClick()
    {
       // Debug.Log("Button Click");
        if (skillPointsManager.currentSkillPoints >= skillPointsNeed)
        {
            skillPointsManager.RemoveSkillPoints(skillPointsNeed);
            abilityIcon.isLocked = false;
            unlockButton.interactable = false; //After Ablility Unlocked Disable Button and Change the text.
            errorText.color = Color.white;
            errorText.text = $"";
        }
        else
        {
         //   Debug.Log("Not Enogh Skill Points");
        }
    }
}
