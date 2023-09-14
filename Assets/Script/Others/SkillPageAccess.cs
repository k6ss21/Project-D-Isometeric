using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPageAccess : MonoBehaviour
{
    private CustomInput input = null;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask playerLayerMask;

    public bool isSkillCanvasOpen;
    public GameObject skillCanvas;
    public GameObject instructionPopUp;

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

    public void Start()
    {
        skillCanvas = ReferenceManager.instance.skillCanvas.gameObject;
        skillCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);

        if (collider != null)
        {
            instructionPopUp.SetActive(true);
            if (input.Player.SkillPage.WasPerformedThisFrame())
            {
              //  Debug.Log("Open SKill Menu");
                isSkillCanvasOpen = true;
                FindObjectOfType<GameEventManager>().PauseTimer();
                skillCanvas.SetActive(true);
            }
        }
        else
        {
            instructionPopUp.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

    public void CloseSkillCanvas()
    {
        FindObjectOfType<GameEventManager>().ResumeTimer();
        isSkillCanvasOpen = false;

    }
}
