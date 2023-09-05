using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeChamberTutorial : MonoBehaviour
{

    [SerializeField] private GameObject RechargeChamberTutCanvas;
    public bool isCompleted;
    Tutorial tutorial;
    public bool isActive;

    void Start()
    {
        tutorial = GetComponentInParent<Tutorial>();
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OkButton();
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCompleted)
        {
            if (other.CompareTag("Player"))
            {
                isActive= true;
                Time.timeScale = 0;
                tutorial.EnableAllUI(false);
                RechargeChamberTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        isActive= false;
        Time.timeScale = 1;
        tutorial.EnableAllUI(true);
        RechargeChamberTutCanvas.SetActive(false);
        tutorial.RechargeChamberTut = true;
    }
}
