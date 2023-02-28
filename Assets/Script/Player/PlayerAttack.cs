
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    // public float angle;
    public Transform projectilePf;

    private float attackDelay;
    public  bool isAttacking;

    PlayerAnimationManger playerAnimationManger;


    Animator animator;

    public float DefaultDamageValue;
    PlayerAttackCollider playerAttackCollider;

    MouseOverUICheck mouseOverUICheck;
    void Start()
    {
        playerAnimationManger = GetComponent<PlayerAnimationManger>();
        playerAttackCollider = GetComponentInChildren<PlayerAttackCollider>();
        mouseOverUICheck = GetComponent<MouseOverUICheck>();
        animator = GetComponent<Animator>();
        isAttacking = false;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(mouseOverUICheck.IsPointerOverUIElement()){return;}
            if (!isAttacking)
            {
                isAttacking = true;
                Attack1();
                playerAttackCollider.SetDamageValue(DefaultDamageValue);
                StartCoroutine(AttackDelayRoutine(animator.GetCurrentAnimatorStateInfo(0).length));
            }
            else
            {
              //Debug.Log("Attack CoolDown");
            }

        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Attack shoot");
            Attack(); 
        }
    }

    IEnumerator AttackDelayRoutine(float t)
    {
        attackDelay = t;
        yield return new WaitForSeconds(attackDelay);
        playerAnimationManger.PlayerIdle();
        isAttacking = false;
    }

    public void Attack()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var projectile = Instantiate(projectilePf, transform.position, Quaternion.identity);

        Vector3 shootDir = (mousePos - transform.position).normalized;
        float angle = GetAngleFromVectorFloat(shootDir);
        //  ChangeDirectionUsingAngle();
        projectile.GetComponent<Projectile>().Setup(shootDir);

        //CinemachineCameraShake.Instance.ShakeCamera(.2f, .05f); // Fix  it Later..
    }

    public void Attack1()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 shootDir = (mousePos - transform.position).normalized;
        float angle = GetAngleFromVectorFloat(shootDir);
       // Debug.Log("Angle  =" + angle);
        string dir = ChangeDirectionUsingAngle(angle);
      //  Debug.Log("Dir = " + dir);
        playerAnimationManger.Attack(dir);


    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    string ChangeDirectionUsingAngle(float angle)
    {
        string dir;
        if (angle <= 75 && angle >= 15)
        {
          //  Debug.Log("NE");
            dir = "NE";
            return dir;
        }
        if (angle <= 14&& angle >=0 ||angle <=360 && angle >= 346)
        {
            //Debug.Log("E");
            dir = "E";
            return dir;
        }
        if (angle <= 345 && angle >= 285)
        {
           // Debug.Log("SE");
            dir = "SE";
            return dir;
        }

        if (angle <= 284 && angle >= 255)
        {
          //  Debug.Log("S");
            dir = "S";
            return dir;

        }
        if (angle <= 254 && angle >= 195)
        {
           // Debug.Log("SW");
            dir = "SW";
            return dir;

        }
        if (angle <= 194 && angle >= 165)
        {
           // Debug.Log("W");
            dir = "W";
            return dir;

        }
        if (angle <= 164 && angle >= 105)
        {
           // Debug.Log("NW");
            dir = "NW";
            return dir;

        }
        if (angle <= 104 && angle >= 74)
        {
            //Debug.Log("N");
            dir = "N";
            return dir;

        }
        return null;



    }

}
