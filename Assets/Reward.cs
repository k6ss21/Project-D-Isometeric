using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Reward : MonoBehaviour
{
    public int rewardPoint;

    public static event Action<int> OnRewardCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnRewardCollected?.Invoke(rewardPoint);
            Destroy(this.gameObject);
        }
    }
}
