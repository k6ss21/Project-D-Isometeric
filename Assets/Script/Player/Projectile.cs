using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDir;

    public float damage; 
    public float shootSpeed;
    public void Setup(Vector3 dir)
    {
        shootDir = dir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));

    }

    void Update()
    {
        transform.position += shootDir * shootSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyAI target = other.GetComponent<EnemyAI>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Elevation"))
        {
            Destroy(gameObject); 
        }
    }


}
