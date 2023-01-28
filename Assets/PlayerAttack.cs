using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float angle;
    public Transform projectilePf;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        
    }

    public void Attack()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var projectile = Instantiate(projectilePf, transform.position, Quaternion.identity);

        Vector3 shootDir = (mousePos - transform.position).normalized;
        angle = GetAngleFromVectorFloat(shootDir);
        ChangeDirectionUsingAngle();
        projectile.GetComponent<Projectile>().Setup(shootDir);

        //CinemachineCameraShake.Instance.ShakeCamera(.2f, .05f); // Fix  it Later..
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void ChangeDirectionUsingAngle()
    {
        if (angle <= 75 && angle >= 15)
        {
            Debug.Log("NE");
        }
        if (angle <= 14 && angle >= 346)
        {
            Debug.Log("E");
        }
        if (angle <= 345 && angle >= 285)
        {
            Debug.Log("SE");
        }

        if (angle <= 284 && angle >= 255)
        {
            Debug.Log("S");

        }
        if (angle <= 254 && angle >= 195)
        {
            Debug.Log("SW");

        }
        if (angle <= 194 && angle >= 165)
        {
            Debug.Log("W");

        }
        if (angle <= 164 && angle >= 105)
        {
            Debug.Log("NW");

        }
        if (angle <= 104 && angle >= 74)
        {
            Debug.Log("N");

        }

    }

}