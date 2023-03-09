using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AttackCollider : MonoBehaviour
{
    public float damage;
    private bool isDamaged = false;


    public void SetDamageValue(float value)
    {
        damage = value;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var target = other.GetComponent<Player>();

        if (target != null && !isDamaged)
        {
            target.TakeDamage(damage);
           // isDamaged = true;
         //   Debug.Log("Player Damage ");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isDamaged = false;
    }
}

