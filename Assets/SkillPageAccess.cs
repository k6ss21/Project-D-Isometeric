using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPageAccess : MonoBehaviour
{

    [SerializeField] float circleRadius;
    [SerializeField] LayerMask playerLayerMask;

    public bool isSkillCanvasOpen;
    public GameObject skillCanvas;

    public void Start()
    {
        skillCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);

        if(collider != null)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Open SKill Menu");
                isSkillCanvasOpen = true;
                skillCanvas.SetActive(true);
            }
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
