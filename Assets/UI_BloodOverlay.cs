using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_BloodOverlay : MonoBehaviour
{

    public float defaultAlphaValue;
    public float alphaValue{get; set;}

    public float reduceAmount;

    Image bloodOverlayImage;
   


    void Start()
    {
        bloodOverlayImage = GetComponent<Image>();
        ChangeColorAlpha(0f);
    }
    void Update()
    {
        ChangeColorAlpha(alphaValue);
        if(alphaValue>0)
        {
            alphaValue -= reduceAmount;
            ChangeColorAlpha(alphaValue);
        }
    }
    void ChangeColorAlpha(float value)
    {
        
        var tempColor = bloodOverlayImage.color;
        tempColor.a = value;
        bloodOverlayImage.color = tempColor;
    }
    public void ShowBloodOverlay()
    {
        alphaValue = defaultAlphaValue;
    }

}
