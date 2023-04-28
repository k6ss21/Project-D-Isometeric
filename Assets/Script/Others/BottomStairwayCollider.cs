using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomStairwayCollider : MonoBehaviour
{
    Stairway stairway;

    void Start()
    {
        stairway = GetComponentInParent<Stairway>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            stairway.PlayerToTop();
        }
    }
}
