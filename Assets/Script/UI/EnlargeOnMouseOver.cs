using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EnlargeOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // The Text component to be enlarged
    public TextMeshProUGUI text;

    // The original font size of the Text component
    private float originalSize;

    // The size to enlarge the font to when the mouse is over the text
    public float enlargedSize = 20;

    void Start()
    {
        // Store the original font size
        originalSize = text.fontSize;
        enlargedSize = originalSize + 5f;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Enlarge the font when the mouse is over the text
//        Debug.Log("on over");
        text.fontSize = enlargedSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restore the original font size when the mouse is no longer over the text
        text.fontSize = originalSize;
    }
}
