using System.Collections;
using System.Collections.Generic;


public interface IAnimationManager
{
    void Walk(string dir);
    void Idle(string dir);

    void Attack1(string dir);
  
}

public interface IDamagable
{
    void TakeDamage(float damage);
}

public interface IEnemyAttackManger
{
    bool isAttacking {get; set;}
}