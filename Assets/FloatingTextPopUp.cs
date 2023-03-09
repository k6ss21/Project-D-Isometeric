using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextPopUp : MonoBehaviour
{
    public float destroyTime = 2f;
    public Vector3 offset = new Vector3(0,2,0);

    Vector3  randomIntensity = new Vector3(.1f,0,0);
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomIntensity.x,randomIntensity.x),
        Random.Range(-randomIntensity.y,randomIntensity.y),
        Random.Range(-randomIntensity.z,randomIntensity.z));
    }
}
