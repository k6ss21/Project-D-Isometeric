using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class AdjustSortingOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TrailRenderer trailRenderer;
    public SortingGroup sortingGroup;
    public bool isStatic;

    public bool isSpriteRenderer;
    public bool isProjectile;
    public bool isSortingGroup;
    public int sortingOrderNumber;

    void Start()
    {
        // if (!isStatic && spriteRenderer)
        // {
        //     spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
        // }
    }

    void Update()
    {
        sortingOrderNumber = (int)(transform.position.y * -100);
        if (!isStatic && spriteRenderer)
        {
            spriteRenderer.sortingOrder = sortingOrderNumber;
        }
        if (isProjectile)
        {
            trailRenderer.sortingOrder = sortingOrderNumber;
        }
        if (isSortingGroup)
        {
            sortingGroup.sortingOrder = sortingOrderNumber;
        }
    }
}


