using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss_1_AnimationEventCall : MonoBehaviour
{
   IEnemyAttackManger attackManager;

    void Start()
    {
        attackManager = GetComponentInParent<IEnemyAttackManger>();
    }

    public void EndAttackAnimCall()
    {
        attackManager.EndAttackAnim();
    }
}
