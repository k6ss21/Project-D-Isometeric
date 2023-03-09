using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillButtons : MonoBehaviour
{
    public Image page1;
    public Image page2;
    public Image page3;

    public TextMeshProUGUI b1;
    public TextMeshProUGUI b2;
    public TextMeshProUGUI b3;

    Color defaultColor;
    float defaultFontSize;

    void Start()
    {
        defaultColor = b1.color;

        defaultFontSize = b1.fontSize;

    }

    public void OpenPage1()
    {
        b1.color = Color.white;
        b2.color = defaultColor;
        b3.color = defaultColor;

        PlayClickSound();

        page3.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page1.gameObject.SetActive(true);
    }
    public void OpenPage2()
    {
        b1.color = defaultColor;
        b2.color = Color.white;
        b3.color = defaultColor;

        PlayClickSound();

        page3.gameObject.SetActive(false);
        page2.gameObject.SetActive(true);
        page1.gameObject.SetActive(false);
    }
    public void OpenPage3()
    {
        b1.color = defaultColor;
        b2.color = defaultColor;
        b3.color = Color.white;
        PlayClickSound();
        page3.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);
        page1.gameObject.SetActive(false);
    }

    public void PlayClickSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickSound, this.transform.position);
    }

}
