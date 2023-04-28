using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_LightningColiision : MonoBehaviour
{

    [SerializeField] ParticleSystem particleSystem;
    public int events;
    List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        events = particleSystem.GetCollisionEvents(other, collisionEvents);
        Debug.Log("Events " + events);

        Debug.Log("Hit Name " + other.name);
        if(other.TryGetComponent(out IDamagable enemy))
        {
            Debug.Log("Enemy Found");
            enemy.TakeDamage(20);
        }


    }
   
}
