using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDir;
    private float damage;

    [Header("Projectile Settings")]
    public float shootSpeed;
    public GameObject ImpactPrefab;
    public void Setup(Vector3 dir,float value) //Setup Direction and Damage value of projectile
    {
        shootDir = dir;
        damage = value;
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

       var target = other.gameObject.GetComponentInParent (typeof (IDamagable)) as  IDamagable;
        
        if (target != null)
        {
            Instantiate(ImpactPrefab, transform.position,Quaternion.identity);
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
//        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Projecitle Destroy"))
        {

           //Debug.Log("hiting Elevation");
            Destroy(gameObject);
        }

    }


}
