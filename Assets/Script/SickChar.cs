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




    public static event Action OnHealComplete;
    public static event Action<bool> OnSetHealing;

    void Start()
    {
        animator = GetComponent<Animator>();
        maxValue = healingDuration;
        sliderCanvas.gameObject.SetActive(false);
        UpdateProgressBar();
    }

    void Update()
    {

        HealPrompt();
        if (IsHealing)
        {
            healingProgress += healingRate * Time.deltaTime;
            UpdateProgressBar();

            if (healingProgress >= healingDuration)
            {
                healingProgress = 0f;
                Heal();
            }
        }
    }

    public void CancelHealing()
    {
        IsHealing = false;
        OnSetHealing?.Invoke(false);


    }

    void Heal()
    {
        IsHealing = false;
        OnHealComplete?.Invoke();
        Debug.Log("Healed!");
        animator.Play("SickChar_Disappear");
        Destroy(this.gameObject, .5f);
    }

    void HealPrompt()
    {
        var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayer);


        if (collider != null)
        {
            if (!_textVisible)
            {
                if (collider.GetComponent<Player>().IsHealing)
                {
                    ShowInstructionCantHealText();
                }
                else
                {
                    ShowInstructionText();
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (collider.GetComponent<Player>().IsHealing) { Debug.Log("You can Only heal One Person at a Time"); return; }
                Debug.Log("Healing Started");
                //collider.GetComponent<Player>().IsHealing = true;
                sliderCanvas.gameObject.SetActive(true);
                OnSetHealing?.Invoke(true);

                IsHealing = true;

            }

        }
        else
        {
            DestroyText();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
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
    void ShowInstructionCantHealText()
    {
        if (_floatingTextPrefab)
        {
            _textVisible = true;
            floatingText = Instantiate(_floatingTextPrefab, promptPoint.position, Quaternion.identity);
            floatingText.transform.SetParent(this.transform);
            floatingText.GetComponentInChildren<TextMesh>().text = cantHealtext;

        }
    }

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
