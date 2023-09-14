using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickCharTutorial : MonoBehaviour
{
    [SerializeField] private GameObject SickTutCanvas;
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
                tutorial.EnableAllUI(false);
                isActive = true;
                Time.timeScale = 0;
                SickTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        Time.timeScale = 1;
        isActive= false;
        tutorial.EnableAllUI(true);
        SickTutCanvas.SetActive(false);
        tutorial.sickTut = true;
    }
}
