using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuTutorial : MonoBehaviour
{
    [SerializeField] private GameObject skillMenuTutCanvas;
    public bool isCompleted;
    public bool isActive;
    Tutorial tutorial;

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
            if (input.Player.SkillPage.WasPerformedThisFrame())
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
                isActive = true;
                tutorial.EnableAllUI(false);
                skillMenuTutCanvas.SetActive(true);
            }
        }
    }

    public void OkButton()
    {
        isCompleted = true;
        isActive = false;
        Time.timeScale = 1;
        tutorial.EnableAllUI(true);
        skillMenuTutCanvas.SetActive(false);
        tutorial.skillMenutTut = true;
    }
}
