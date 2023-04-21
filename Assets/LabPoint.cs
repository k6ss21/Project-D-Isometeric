using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LabPoint : MonoBehaviour
{

    public float circleRadius;
    public LayerMask playerLayerMask;

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

          if(Input.GetKeyDown(KeyCode.E))
          {
             OnReturnLastPos?.Invoke();
          } 
        }
        
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
