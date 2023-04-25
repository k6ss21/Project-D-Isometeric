using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ab_LightningVFX : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public int test;
    void Update()
    {
        if(!particleSystem.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
