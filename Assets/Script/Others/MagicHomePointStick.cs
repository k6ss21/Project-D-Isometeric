using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHomePointStick : MonoBehaviour
{
   public void InitiateCoroutine(float time)
    {
        StartCoroutine(DestroyAfterTime(time));
    }
    public IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
