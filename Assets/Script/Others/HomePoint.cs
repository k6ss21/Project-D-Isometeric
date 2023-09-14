using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

[RequireComponent(typeof(StudioEventEmitter))]
public class HomePoint : MonoBehaviour
{
    private CustomInput input = null;
    private bool canAccessLab;
    public Transform labTeleportPoint;
    public Canvas skillCanvas;

    private bool canAccessSkill;
    private bool SkillMenuOpen;

    public float circleRadius;
    public LayerMask playerLayerMask;

    public float coolDownTime;
    public float coolDownTimer;

    bool coolDown;

    [Header("Floating Test")]
    public InstructionPopUp instructionPopUp;
    private bool _textVisible = false;

    public LayerMask playerLayer;

    private StudioEventEmitter emitter;

    public static event Action<Vector3> OnTeleportToLab;


    void Awake()
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
        skillCanvas = ReferenceManager.instance.skillCanvas;
        labTeleportPoint = ReferenceManager.instance.labTeleportPoint;
        //  instructionBox = FindObjectOfType<InstructionBox>();
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.FirePlace, this.gameObject);
        emitter.Play();
        if (skillCanvas != null)
        {
            skillCanvas.gameObject.SetActive(false);
        }
        SkillMenuOpen = false;


    }

    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        HomePointRange();
        CoolDown();
        TeleportToLab();
        // if(skillCanvas!=null){
        // SkillMenu();
        // }
        PopUpText();
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     InstructionBox.instance.SpawnInstructionPopUpText("TEsting Instruction Box");
        // }

    }

    void CoolDown()
    {
        if (coolDownTimer <= 0)
        {
            coolDown = false;
        }
        else
        {
            coolDown = true;
        }
    }

    void TeleportToLab()
    {
        if (input.Player.Interact.WasPerformedThisFrame())
        {
            if (canAccessLab)
            {
                if (!coolDown)
                {
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.TeleportToLab, this.transform.position);
                    OnTeleportToLab?.Invoke(labTeleportPoint.position);
                    coolDownTimer = coolDownTime;
                }
                else
                {
                    InstructionBox.instance.SpawnInstructionPopUpText("Skill Menu Cool Down " + "(" + (int)coolDownTimer % 60 + " sec left" + ")");
                }

            }
        }
    }

    void PopUpText()
    {
        var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayer);


        if (collider != null)
        {
            if (canAccessLab && !coolDown)
            {
                if (!_textVisible)
                {
                    instructionPopUp.gameObject.SetActive(true);
                    //   instructionPopUp.Show(text);

                }
            }
        }
        else
        {
            instructionPopUp.gameObject.SetActive(false);
            //instructionPopUp.Hide();
        }

    }

    // void SkillMenu()
    // {

    //     //Menu Input Key = "I"
    //     if (Input.GetKeyDown(KeyCode.I))
    //     {

    //         if (canAccessSkill && !coolDown)
    //         {
    //             skillCanvas.gameObject.SetActive(true);
    //             SkillMenuOpen = true;
    //             coolDownTimer = coolDownTime;
    //         }
    //         else
    //         {
    //             SkillMenuLogs();
    //         }
    //     }


    //     void SkillMenuLogs()
    //     {
    //         if(instructionBox != null)
    //         {
    //             if(!canAccessSkill)
    //             {
    //                  instructionBox.SpawnInstructionPopUpText("You're Outside Home Point");
    //             }
    //             else
    //             {
    //                 if(coolDown)
    //                 {
    //                      instructionBox.SpawnInstructionPopUpText("Skill Menu Cool Down " +"(" + (int)coolDownTimer % 60+" sec left"+")");
    //                 }
    //             }
    //         }
    //     }



    //     //Stop Time When Menu is Open
    //     if (SkillMenuOpen)
    //     {
    //         Time.timeScale = 0;

    //     }
    //     else
    //     {
    //         Time.timeScale = 1;
    //     }
    // }


    void HomePointRange() //Home Point Range Function
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);

        if (collider != null)
        {
            canAccessSkill = true;
            canAccessLab = true;
        }
        else
        {
            canAccessSkill = false;
            canAccessLab = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

    public void CloseMenu() // Close Button Function
    {
        SkillMenuOpen = false;
    }

}
