using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private float damage;

    public void SetDamageValue(float value)
    {
        damage = value;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var target = other.GetComponentInParent(typeof(IDamagable)) as IDamagable;

        if (target != null)
        {
            //Debug.Log("Attacking!!");
            target.TakeDamage(damage);
        }
    }

    

}
