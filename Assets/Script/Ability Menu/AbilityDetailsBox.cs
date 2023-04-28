using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AbilityDetailsBox : MonoBehaviour
{

    public TextMeshProUGUI abilityNameText;
    public TextMeshProUGUI abilityDescriptionText;

    public Button button;
    public AbilityIcon abilityIcon;
    public SkillPoints skillPointsManager;

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
    }
    private void UpdateDetailsBox(string a, string b,int points, AbilityIcon ab_Icon)
    {
        abilityIcon = ab_Icon;
        skillPointsNeed = points;
        UIShowHide(true);
        UpdateAbilityDetailsBoxText(a, b);
    }

    private void UIShowHide(bool value)
    {
        button.gameObject.SetActive(value);
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
        Debug.Log("Button Click");
        if(skillPointsManager.currentSkillPoints >= skillPointsNeed)
        {
        abilityIcon.isLocked = false;
        }
        else{
            Debug.Log("Not Enogh Skill Points");
        }
    }
}
