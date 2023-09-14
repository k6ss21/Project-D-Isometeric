using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class SickChar : MonoBehaviour
{
    private CustomInput input = null;

    // Healing duration in seconds
    public float healingDuration = 20f;

    // Amount of healing per second
    public float healingRate = 1f;

    // Current healing progress
    float healingProgress = 0f;

    public bool IsHealing = false;

    private bool healingCompleted;

    public float circleRadius;
    public LayerMask playerLayer;

    public float disableRadius;

    Material material;



    [Header("Floating Test")]
    [SerializeField] private GameObject _floatingTextPrefab;
    public GameObject instructionPopUp;
    [SerializeField] private string text = "Press E to Loot";
    [SerializeField] private string cantHealtext;
    private bool _textVisible = false;
    private GameObject floatingText;
    public Transform promptPoint;
    [Space(10)]

    [Header("Progress Bar")]
    public Slider progressBar;
    public Canvas sliderCanvas;
    public Image sliderFillImage;
    // Color activeColor = Color.HSVToRGB(.96f, .83f, .87f);
    Color activeColor = Color.green;
    Color inActiveColor = Color.red;
    public float maxValue;
    public float currentValue;


    public Animator animator;


    InstructionBox instructionBox;

    public static event Action<SickChar> OnHealComplete;
    public static event Action<bool> OnSetHealing;
    private void Awake() {
        input = new CustomInput();
        
    }

    void OnEnable()
    {
        input.Enable();
        Ab_CureStimulator.OnCureStimulateTrigger += ChangeHealingRate;
    }

    void OnDisable()
    {
        input.Disable();
        Ab_CureStimulator.OnCureStimulateTrigger -= ChangeHealingRate;
    }

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
        //DisableOutline();

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

    public void ChangeHealingRate(float boost)
    {
        healingRate *= boost;
        Debug.Log("Healing Rate Changed " + healingRate);
    }

    public void CancelHealing()
    {
        // Debug.Log("Cancel Healing");
        if (IsHealing)
        {
            instructionBox.SpawnInstructionPopUpText("Sick healing Canceled");
            sliderFillImage.color = inActiveColor;
            IsHealing = false;
            OnSetHealing?.Invoke(false);
        }

    }

    void HealComplete()
    {
        IsHealing = false;
        healingCompleted = true;
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
                // if (playerScript.IsHealing)
                // {
                //     // ShowInstructionCantHealText();
                // }
                // else
                // {
                //     ShowInstructionText();
                // }
                instructionPopUp.gameObject.SetActive(true);
                /// ShowInstructionText();

            }

            if (input.Player.Use.WasPerformedThisFrame())
            {
              //  Debug.Log("Healing Started");
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
            instructionPopUp.gameObject.SetActive(false);
            //            instructionPopUp.Hide();
        }

    }

    public void StarHealing()
    {
       // Debug.Log("Healing Started");
        //collider.GetComponent<Player>().IsHealing = true;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.healStarted, this.transform.position);
        sliderCanvas.gameObject.SetActive(true);
        sliderFillImage.color = activeColor;
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

    // #region 
    // [SerializeField] float randomTime;

    // IEnumerator CoughingSfxPlay(float timer)
    // {
    //     yield return new WaitForSeconds(cou)
    // }
    // #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
        Gizmos.DrawWireSphere(transform.position, disableRadius);

    }

    // void ShowInstructionText()
    // {
    //     if (_floatingTextPrefab)
    //     {
    //         _textVisible = true;
    //         floatingText = Instantiate(_floatingTextPrefab, promptPoint.position, Quaternion.identity);
    //         floatingText.transform.SetParent(this.transform);
    //         floatingText.GetComponentInChildren<TextMesh>().text = text;

    //     }
    // }
    // // void ShowInstructionCantHealText()
    // // {
    // //     if (_floatingTextPrefab)
    // //     {
    // //         _textVisible = true;
    // //         floatingText = Instantiate(_floatingTextPrefab, promptPoint.position, Quaternion.identity);
    // //         floatingText.transform.SetParent(this.transform);
    // //         floatingText.GetComponentInChildren<TextMesh>().text = cantHealtext;

    // //     }
    // // }

    void ShowInstructionText()
    {
        GameObject obj = Instantiate(instructionPopUp.gameObject);
        obj.GetComponent<InstructionPopUp>().Show(text);
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
