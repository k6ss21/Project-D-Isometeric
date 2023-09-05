using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarTutorial : MonoBehaviour
{
   
    [SerializeField] private GameObject PlayerBarTutCanvas;
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
                tutorial.EnableSomeUI(false);
                PlayerBarTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        isActive= false;
        Time.timeScale = 1;
        tutorial.EnableSomeUI(true);
        PlayerBarTutCanvas.SetActive(false);
        tutorial.RechargeChamberTut = true;
    }
}
