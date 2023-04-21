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
    void OnEnable()
    {
        AbilityIcon.OnAbilityIconClick += UpdateDetailsBox;
    }
    void OnDisable()
    {
        AbilityIcon.OnAbilityIconClick -= UpdateDetailsBox;
    }

    void Update()
    {
        button.onClick.AddListener(OnUnlockButtonClick);
    }
    private void UpdateDetailsBox(string a, string b, AbilityIcon ab_Icon)
    {
        abilityIcon = ab_Icon;
        UpdateAbilityDetailsBoxText(a, b);
    }

    private void UpdateAbilityDetailsBoxText(string name, string description)
    {
        abilityNameText.text = name.ToString();
        abilityDescriptionText.text = description.ToString();
    }

    public void OnUnlockButtonClick()
    {
        Debug.Log("Button Click");
        abilityIcon.isLocked = false;
    }
}
