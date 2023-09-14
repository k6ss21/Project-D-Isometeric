using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool sickTut;
    public bool homePointTut;
    public bool skillMenutTut;
     public bool RechargeChamberTut;
     public bool PlayerBarTut;

    [SerializeField]private GameObject infoCharCanvas;
    [SerializeField]private GameObject playerBarCanvas;
    [SerializeField]private GameObject instructionboxCanvas;
    [SerializeField]private GameObject  skillpointCanvas;

    public void EnableAllUI(bool value)
    {
        infoCharCanvas.SetActive(value);
        playerBarCanvas.SetActive(value);
        instructionboxCanvas.SetActive(value);
       // skillpointCanvas.SetActive(value);
    }
    public void EnableSomeUI(bool value)
    {
        infoCharCanvas.SetActive(value); 
        instructionboxCanvas.SetActive(value);
        
    }


}
