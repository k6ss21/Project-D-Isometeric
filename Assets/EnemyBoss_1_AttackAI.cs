using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AttackAI : MonoBehaviour, IEnemyAttackManger
{
    IAnimationManager animationManager;

    EnemyMovementAI enemyMovementAI;
    Animator animator;
    public float attackTimer;
    public float attackInterval;
    public bool attackTimerActivate;


    public bool isAttacking{get; set;}


    //test (DELETE)

    public float animtestTime;

    void Start()
    {
        animationManager = GetComponent(typeof(IAnimationManager)) as IAnimationManager;
        enemyMovementAI = GetComponent<EnemyMovementAI>();
        animator = GetComponentInChildren<Animator>();
        attackTimer = attackInterval;
        isAttacking = false;
       
    }

    void Update()
    {
        if (attackTimerActivate)
        {
            attackTimer -= Time.deltaTime;
        }
        if (enemyMovementAI.isIdle)
        {
            attackTimerActivate = true;
            Attack();
        }
        else
        {
            attackTimer = attackInterval;
            attackTimerActivate = false;
        }
    }

    void Attack()
    {
        if (attackTimer <= 0)
        {
            attackTimerActivate = false;
            isAttacking = true;
            attackTimer = attackInterval;
            animationManager.Attack1(enemyMovementAI.GetLastMoveDir());
          //  StartCoroutine(AttackAnimInterval((animator.GetCurrentAnimatorStateInfo(0).normalizedTime)% 1< 0.99fz));
        }
    }

    IEnumerator AttackAnimInterval(float t)
    {
        animtestTime = t;
        yield return new WaitForSeconds(t);
        attackTimerActivate = true;
        isAttacking = false;

    }


    public void EndAttackAnim()
    {
         attackTimerActivate = true;
        isAttacking = false;
    }


}
