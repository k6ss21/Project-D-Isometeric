using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LabPoint : MonoBehaviour
{
    private CustomInput input = null;
    public float circleRadius;
    public LayerMask playerLayerMask;
    public GameObject instructionPopUp;

    public static event Action OnReturnLastPos;
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
            if (input.Player.Interact.WasPerformedThisFrame())
            {
               // Debug.Log("Is presssed");
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
