using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    Animator animator;
    public bool isOpen;

    public GameObject m_light;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isOpen)
        {
            animator.SetBool("IsOpen_Anim", true);
            m_light.SetActive(true);
        }
        else
        {
            animator.SetBool("IsOpen_Anim", false);
            m_light.SetActive(false);
        }
    }
}
