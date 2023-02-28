using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimEnd : MonoBehaviour
{

    public void DestroyParent()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }

    public void DestroyGameObject()
    {
        Destroy(transform.gameObject);
    }
}
