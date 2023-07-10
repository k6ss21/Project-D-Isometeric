using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LabPoint : MonoBehaviour
{

    public float circleRadius;
    public LayerMask playerLayerMask;
    public GameObject instructionPopUp;

    public static event Action OnReturnLastPos;

    void Update()
    {
        LabPointRange();
    }
    void LabPointRange() //Home Point Range Function
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);

        if (collider != null)
        {
            instructionPopUp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.TeleportToLab, this.transform.position);
                OnReturnLastPos?.Invoke();
            }
        }
        else
        {
            instructionPopUp.SetActive(false);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
