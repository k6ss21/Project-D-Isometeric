

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomOverlapCollider : MonoBehaviour
{
    public BoxCollider2D boxcollider2D;

    public Collider2D[] resultCollider;

    ContactFilter2D contactFilter2D = new ContactFilter2D().NoFilter();
    public LayerMask playerLayerMask;

    public int colliders;
    void Update()
    {
       colliders = Physics2D.OverlapCollider(boxcollider2D, contactFilter2D, resultCollider);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Collider = " + other.gameObject.name);
    }
}
