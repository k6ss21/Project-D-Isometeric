using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class SickChar : MonoBehaviour
{
    // Healing duration in seconds
    public float healingDuration = 20f;

    // Amount of healing per second
    public float healingRate = 1f;

    // Current healing progress
    float healingProgress = 0f;

    public bool IsHealing = false;

    public float circleRadius;
    public LayerMask playerLayer;

    public float disableRadius;

    Material material;



    [Header("Floating Test")]
    [SerializeField] private GameObject _floatingTextPrefab;
    [SerializeField] private string text = "Press E to Loot";
    [SerializeField] private string cantHealtext;
    private bool _textVisible = false;
    private GameObject floatingText;
    public Transform promptPoint;
    [Space(10)]

    [Header("Progress Bar")]
    public Slider progressBar;
    public Canvas sliderCanvas;

    public float maxValue;
    public float currentValue;


    public Animator animator;


    InstructionBox instructionBox;

    public static event Action<SickChar> OnHealComplete;
    public static event Action<bool> OnSetHealing;

    void Start()
    {
        animator = GetComponent<Animator>();
        material = GetComponent<SpriteRenderer>().material;
        instructionBox = FindObjectOfType<InstructionBox>();
        maxValue = healingDuration;
        sliderCanvas.gameObject.SetActive(false);
        UpdateProgressBar();
    }

    void Update()
    {

        HealPrompt();
        DisableOutline();
        if (IsHealing)
        {
            healingProgress += healingRate * Time.deltaTime;
            UpdateProgressBar();

            if (healingProgress >= healingDuration)
            {
                healingProgress = 0f;
                HealComplete();
            }
        }
    }

    public void CancelHealing()
    {
        IsHealing = false;
        OnSetHealing?.Invoke(false);


    }

    void HealComplete()
    {
        IsHealing = false;
        OnHealComplete?.Invoke(this);
        Debug.Log("Healed!");
        animator.Play("SickChar_Disappear");
        Destroy(this.gameObject, .5f);
    }

    void HealPrompt()
    {
        var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayer);



        if (collider != null)
        {
            Player playerScript = collider.GetComponent<Player>();
            if (!_textVisible)
            {
                if (playerScript.IsHealing)
                {
                    // ShowInstructionCantHealText();
                }
                else
                {
                    ShowInstructionText();
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (playerScript.IsHealing)
                {
                    // Debug.Log("You can Only heal One Person at a Time");
                    if (instructionBox != null)
                    {
                        if (!IsHealing)
                        {
                            instructionBox.SpawnInstructionPopUpText("You can only heal person at a time");
                        }
                    }
                    return;
                }
                if (playerScript.lowImmunity)
                {
                    // Debug.Log("You can Only heal One Person at a Time");
                    if (instructionBox != null)
                    {
                        if (!IsHealing)
                        {
                            instructionBox.SpawnInstructionPopUpText("Can't Heal, Immunity is too low");
                        }
                    }
                    return;
                }
                StarHealing();

            }

        }
        else
        {
            DestroyText();
        }

    }

    public void StarHealing()
    {
        Debug.Log("Healing Started");
        //collider.GetComponent<Player>().IsHealing = true;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.healStarted, this.transform.position);
        sliderCanvas.gameObject.SetActive(true);
        OnSetHealing?.Invoke(true);
        IsHealing = true;
    }

    public void DisableOutline()
    {
        var collider = Physics2D.OverlapCircle(transform.position, disableRadius, playerLayer);

        if (collider != null)
        {
            material.SetInt("_Outline", 0);
            //  Debug.Log("ouline = " + false);
        }
        else
        {
            material.SetInt("_Outline", 1);
            //   Debug.Log("ouline = " + true);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
        Gizmos.DrawWireSphere(transform.position, disableRadius);

    }

    void ShowInstructionText()
    {
        if (_floatingTextPrefab)
        {
            _textVisible = true;
            floatingText = Instantiate(_floatingTextPrefab, promptPoint.position, Quaternion.identity);
            floatingText.transform.SetParent(this.transform);
            floatingText.GetComponentInChildren<TextMesh>().text = text;

        }
    }
    // void ShowInstructionCantHealText()
    // {
    //     if (_floatingTextPrefab)
    //     {
    //         _textVisible = true;
    //         floatingText = Instantiate(_floatingTextPrefab, promptPoint.position, Quaternion.identity);
    //         floatingText.transform.SetParent(this.transform);
    //         floatingText.GetComponentInChildren<TextMesh>().text = cantHealtext;

    //     }
    // }

    void DestroyText()
    {
        _textVisible = false;
        Destroy(floatingText, .1f);
    }

    void UpdateProgressBar()
    {
        currentValue = healingProgress;
        float fillAmount = currentValue / maxValue;
        progressBar.value = fillAmount;
    }


}