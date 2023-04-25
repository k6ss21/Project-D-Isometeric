using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_LightningPS : MonoBehaviour
{
 [SerializeField] ParticleSystem particleSystem;

 private void OnParticleCollision(GameObject other) {
  
    AudioManager.instance.PlayOneShot(FMODEvents.instance.lightningHitGround,transform.position);
 }
}
