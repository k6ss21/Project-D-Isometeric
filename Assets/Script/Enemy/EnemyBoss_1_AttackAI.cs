using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AttackAI : MonoBehaviour, IEnemyAttackManger
{
    #region COMPONENTS
    IAnimationManager animationManager;
    EnemyMovementAI enemyMovementAI;
    Animator animator;
    #endregion


    [Header("Attack Settings")]
    public float attackInterval;
    public bool canAttack;
    public float circleRadius;
    public LayerMask playerLayerMask;
    private float attackTimer;
    private bool attackTimerActivate;

    public bool isAttacking { get; set; }


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
        PlayerCheck();

        if (attackTimerActivate)
        {
            attackTimer -= Time.deltaTime;
        }
        if (enemyMovementAI.isIdle && canAttack)
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

    void PlayerCheck()
    {
        var collider2D = Physics2D.OverlapCircle(transform.position, circleRadius, playerLayerMask);

        if (collider2D != null)
        {
            canAttack = true;

        }
        else
        {
            canAttack = false;
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
            //  StartCoroutine(AttackAnimInterval((animator.GetCurrentAnimatorStateInfo(0).normalizedTime)));
            StartCoroutine(AttackAnimInterval(attackInterval));
        }
    }

    IEnumerator AttackAnimInterval(float t)
    {

        yield return new WaitForSeconds(t);
        isAttacking = false;

    }


    public void EndAttackAnim()
    {
        attackTimerActivate = true;
        isAttacking = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

}
