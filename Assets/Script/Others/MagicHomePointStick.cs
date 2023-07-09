using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class MagicHomePointStick : MonoBehaviour
{
    private StudioEventEmitter emitter;
    void Start()
    {
        emitter = AudioManager.instance.InitializeEventEmitter(FMODEvents.instance.Ab_MagicHomePointCane, this.gameObject);
        emitter.Play();
    }
   public void InitiateCoroutine(float time)
    {
        StartCoroutine(DestroyAfterTime(time));
    }
    public IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emitter.Stop();
        Destroy(this.gameObject);
    }
}
