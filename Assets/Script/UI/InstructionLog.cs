using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InstructionLog : MonoBehaviour
{
   public  TextMeshProUGUI textGUI;

    
    public void ChangeText(string text)
    {
        textGUI.text = text.ToString();
    }

}

