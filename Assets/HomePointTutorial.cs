using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePointTutorial : MonoBehaviour
{
    [SerializeField] private GameObject HomepointTutCanvas;
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
            if (Input.GetKeyDown(KeyCode.E))
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

                Time.timeScale = 0;
                isActive= true;
                tutorial.EnableAllUI(false);
                HomepointTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        isActive= false;
        Time.timeScale = 1;
        tutorial.EnableAllUI(true);
        HomepointTutCanvas.SetActive(false);
        tutorial.homePointTut = true;
    }
}
