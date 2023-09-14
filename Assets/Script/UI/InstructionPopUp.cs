using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionPopUp : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public Canvas popupCanvas;

    [SerializeField] string text;
    void Start()
    {
        popupCanvas = GetComponentInChildren<Canvas>();
        popupCanvas.gameObject.SetActive(false);
        Show(text);
    }

    public void Show(string text)
    {
        popupCanvas.gameObject.SetActive(true);
        instructionText.text = text.ToString();

    }
    public void Hide()
    {
        popupCanvas.gameObject.SetActive(false);
    }
}
