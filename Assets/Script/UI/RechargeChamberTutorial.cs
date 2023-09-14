using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeChamberTutorial : MonoBehaviour
{

    [SerializeField] private GameObject RechargeChamberTutCanvas;
    public bool isCompleted;
    Tutorial tutorial;
    public bool isActive;
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
        tutorial = GetComponentInParent<Tutorial>();
    }

    void Update()
    {
        if (isActive)
        {
            if (input.Player.Use.WasPerformedThisFrame())
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
                isActive = true;
                Time.timeScale = 0;
                tutorial.EnableAllUI(false);
                RechargeChamberTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        isActive = false;
        Time.timeScale = 1;
        tutorial.EnableAllUI(true);
        RechargeChamberTutCanvas.SetActive(false);
        tutorial.RechargeChamberTut = true;
    }
}
