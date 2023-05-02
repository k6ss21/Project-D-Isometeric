using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AttackCollider : MonoBehaviour
{
    public float damage;
    private bool isDamaged = false;

    void OnEnable()
    {
        Ab_EnemyDamageDeBuff.OnEnemyDamageDeBuffTrigger += Ab_EnemyDamageDeBuffInitiate;
    }

    void OnDisable()
    {
        Ab_EnemyDamageDeBuff.OnEnemyDamageDeBuffTrigger -= Ab_EnemyDamageDeBuffInitiate;
    }

    void Ab_EnemyDamageDeBuffInitiate(float valueMulti, float time)
    {
        SetDamageValue(valueMulti);

    }

    IEnumerator RevertDamageValue(float time)
    {
        yield return new WaitForSeconds(time);
        SetDamageValue(1);
    }

    public void SetDamageValue(float valueMulti)
    {
        damage *= valueMulti;
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

