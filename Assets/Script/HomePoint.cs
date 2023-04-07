using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


[RequireComponent(typeof(StudioEventEmitter))]
public class HomePoint : MonoBehaviour
{

    public Canvas skillCanvas;
    private bool canAccessSkill;
    private bool SkillMenuOpen;

    public float circleRadius;
    public LayerMask playerLayerMask;

    public float coolDownTime;
    public float coolDownTimer;

    bool coolDown;

    [Header("Floating Test")]
    [SerializeField] private GameObject _floatingTextPrefab;
    [SerializeField] private string text = "Press I for Skill Menu";
    private bool _textVisible = false;
    private GameObject floatingText;
    public Transform promptPoint;

    public LayerMask playerLayer;

    InstructionBox instructionBox;

    private StudioEventEmitter emitter;

    void Start()
    {
        instructionBox = FindObjectOfType<InstructionBox>();
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.FirePlace, this.gameObject);
        emitter.Play();
        skillCanvas.gameObject.SetActive(false);
        SkillMenuOpen = false;
    }

    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        HomePointRange();
        CoolDown();
        SkillMenu();
     //   PopUpText();


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

    // void PopUpText()
    // {
    //     var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayer);


    //     if (collider != null && canAccessSkill && !coolDown)
    //     {
    //         if (!_textVisible)
    //         {
    //             ShowInstructionText();

    //         }
    //     }
    //     else
    //     {

    //         DestroyText();
    //     }

    // }
    // void DestroyText()
    // {
    //     _textVisible = false;
    //     Destroy(floatingText, .1f);
    // }

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
    void SkillMenu()
    {

        //Menu Input Key = "I"
        if (Input.GetKeyDown(KeyCode.I))
        {

            if (canAccessSkill && !coolDown)
            {
                skillCanvas.gameObject.SetActive(true);
                SkillMenuOpen = true;
                coolDownTimer = coolDownTime;
            }
            else
            {
                SkillMenuLogs();
            }
        }


        void SkillMenuLogs()
        {
            if(instructionBox != null)
            {
                if(!canAccessSkill)
                {
                     instructionBox.SpawnInstructionPopUpText("You're Outside Home Point");
                }
                else
                {
                    if(coolDown)
                    {
                         instructionBox.SpawnInstructionPopUpText("Skill Menu Cool Down " +"(" + (int)coolDownTimer % 60+" sec left"+")");
                    }
                }
            }
        }



        //Stop Time When Menu is Open
        if (SkillMenuOpen)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }


    void HomePointRange() //Home Point Range Function
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);
        
        if (collider != null)
        {
            canAccessSkill = true;
        }
        else
        {
            canAccessSkill = false;
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
