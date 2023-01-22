using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPoint : MonoBehaviour
{
    public float range;
    public LayerMask playerLayerMask;

    public float HeatingRate;
    public float warmInterval;
    float timer;

    void Start()
    {
        timer = -1;
    }

    void Update()
    {


        Collider2D collider = Physics2D.OverlapCircle(transform.position, range, playerLayerMask);

        if (collider != null)
        {
            HeatTimer();
            Player player = collider.GetComponent<Player>();
            if (timer <= 0)
            {
                player.WarmUp(HeatingRate);
                timer = warmInterval;
            }


        }
        else
        {
            timer = -1;
        }
    }

    void HeatTimer()
    {
        timer -= Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
