using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    SpriteRenderer m_spriteRenderer;
    SpriteRenderer p_spriteRenderer;


    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        p_spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        m_spriteRenderer.sortingOrder = p_spriteRenderer.sortingOrder;
    }

    void Update()
    {
        m_spriteRenderer.sortingOrder = p_spriteRenderer.sortingOrder;
    }

}
