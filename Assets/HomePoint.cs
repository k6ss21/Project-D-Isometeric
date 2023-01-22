using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePoint : MonoBehaviour
{

    public Canvas skillCanvas;
    private bool canAccessSkill;
    private bool SkillMenuOpen;

    public float circleRadius;
    public LayerMask playerLayerMask;


    void Start()
    {
        skillCanvas.gameObject.SetActive(false);
        SkillMenuOpen = false;
    }

    void Update()
    {
        HomePointRange();
        SkillMenu();


    }

    void SkillMenu()
    {
        //Menu Input Key = "I"
        if (canAccessSkill == true)
        {

            if (Input.GetKeyDown(KeyCode.I))
            {
                skillCanvas.gameObject.SetActive(true);
                SkillMenuOpen = true;
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
