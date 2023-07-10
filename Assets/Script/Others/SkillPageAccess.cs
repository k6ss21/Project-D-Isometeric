using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPageAccess : MonoBehaviour
{

    [SerializeField] float circleRadius;
    [SerializeField] LayerMask playerLayerMask;

    public bool isSkillCanvasOpen;
    public GameObject skillCanvas;
    public GameObject instructionPopUp;

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
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Open SKill Menu");
                isSkillCanvasOpen = true;
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
        isSkillCanvasOpen = false;
    }
}
