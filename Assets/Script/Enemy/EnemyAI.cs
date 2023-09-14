using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour, IDamagable
{
    public float health;
    public float currentHealth;
    public float damage;
    public float attackRadius;
    public LayerMask playerLayer;


    public float attackInterval;
    private float attackTimer;
    public static event Action<float> OnAttack;
    void Start()
    {
        currentHealth = health;
    }
    void Update()
    {
        attackTimer -= Time.deltaTime;

        var collider = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayer);
        if (collider != null)
        {
            if (attackTimer <= 0)
            {
                Attack();
            }
        }
    }
    void Attack()
    {
        attackTimer = attackInterval;
        OnAttack?.Invoke(damage);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth<= 0)
        {
            Destroy(gameObject);
        }
        //Debug.Log("Hitting Enemy!!!!");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
