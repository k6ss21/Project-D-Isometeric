using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    private CustomInput input = null;

    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
        ShowDialogue();
    }


    void Update()
    {
        if (input.Ability.Touch.WasPerformedThisFrame())
        {
            if (index > (lines.Length - 1))
            {
                LevelManager.instance.LoadNextLevel();
                return;
            }
            index++;
            ShowDialogue();

        }
    }

    void ShowDialogue()
    {
        textComponent.text = lines[index].ToString();

    }

}
