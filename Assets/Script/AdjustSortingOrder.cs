using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isStatic;

    void Start()
    {
        spriteRenderer.sortingOrder =  (int)(transform.position.y * -100);
    }
    
    void Update()
    {
        if(!isStatic)
        {
            spriteRenderer.sortingOrder =  (int)(transform.position.y * -100);
        }
    }

}
