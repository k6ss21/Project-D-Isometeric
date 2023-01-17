using System.Collections;
using System.Collections.Generic;


public interface IAnimationManager
{
    void Walk(string dir);
  
}

public interface IDamagable
{
    void TakeDamage(float damage);
}