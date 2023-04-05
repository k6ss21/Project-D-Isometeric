using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TrailRenderer trailRenderer;
    public bool isStatic;
    public bool isProjectile;

    private int sortingOrderNumber;

    void Start()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
    }

    void Update()
    {
        sortingOrderNumber = (int)(transform.position.y * -100);
        if (!isStatic)
        {
            spriteRenderer.sortingOrder = sortingOrderNumber;
        }
        if (isProjectile)
        {
            trailRenderer.sortingOrder = sortingOrderNumber;
        }
    }
}


