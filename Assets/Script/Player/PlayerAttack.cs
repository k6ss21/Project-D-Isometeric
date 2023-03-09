
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMOD.Studio;
public class PlayerAttack : MonoBehaviour
{
    #region COMPONENTS
    PlayerAnimationManger playerAnimationManger;
    IsoCharacterController characterController;
    MouseOverUICheck mouseOverUICheck;
    Animator animator;
    PlayerAttackCollider playerAttackCollider;
    #endregion

    public Transform projectilePf;

    [Header("Attack Points")]
    private Transform attackPoint;
    public Transform attackPoint_SENE;
    public Transform attackPoint_SWNW;
    public Transform attackPoint_N;
    public Transform attackPoint_S;
    public Transform attackPoint_E;
    public Transform attackPoint_W;
    [Space(5)]



    private float attackDelay;
    public bool isAttacking{get; private set;}
    public bool isAttackSword { get; private set; }
    public bool isAttackShoot { get; private set; }
    private float attackShootTimer;
    public float attackShootTime;
    public float DefaultDamageValue;



    private EventInstance slashAttack_SFX;
    void Start()
    {
        playerAnimationManger = GetComponent<PlayerAnimationManger>();
        playerAttackCollider = GetComponentInChildren<PlayerAttackCollider>();
        characterController = GetComponent<IsoCharacterController>();
        mouseOverUICheck = GetComponent<MouseOverUICheck>();
        animator = GetComponent<Animator>();

        slashAttack_SFX = AudioManager.instance.CreateEventInstance(FMODEvents.instance.slashAttack);

        isAttacking = false;
        isAttackSword = false;
        isAttackShoot = false;
    }
    void Update()
    {
        ManageInput();
        AttackShootTimer();
        UpdateSound();

    }

    void ManageInput()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (mouseOverUICheck.IsPointerOverUIElement()) {; return; }
            if (!isAttacking)       
            {
                isAttacking = true;
                isAttackSword = true;
                AttackSword();
                playerAttackCollider.SetDamageValue(DefaultDamageValue);
                StartCoroutine(AttackDelayRoutine(animator.GetCurrentAnimatorStateInfo(0).length));
            }
            else
            {
                //Debug.Log("Attack CoolDown");
            }

        }

        if (Input.GetMouseButtonDown(0)) //Projectile Shoot
        {
            if (mouseOverUICheck.IsPointerOverUIElement()) {; return; }
            //Debug.Log("Attack shoot");
            if (!isAttacking)
            {
                isAttacking = true;
                AttackShoot();
                StartCoroutine(AttackDelayRoutine(0.5f));
            }
        }
    }

    #region ATTACK FUNTIONS
    IEnumerator AttackDelayRoutine(float t)
    {
        attackDelay = t;
        yield return new WaitForSeconds(attackDelay);
        playerAnimationManger.PlayerIdle();
        isAttacking = false;
        isAttackSword = false;
    }
    public void AttackShoot()
    {
        isAttackShoot = true;
        attackShootTimer = attackShootTime;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 shootDir = (mousePos - transform.position).normalized;
        float angle = GetAngleFromVectorFloat(shootDir);
        string dir = ChangeDirectionUsingAngle(angle);
        ChangeAttackPoint(dir);
        playerAnimationManger.Attack2Idle(dir);
        var projectile = Instantiate(projectilePf, attackPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Setup(shootDir);


        //CinemachineCameraShake.Instance.ShakeCamera(.2f, .05f); // Fix  it Later..
    }
    public void AttackShootTimer()
    {
        if (isAttackShoot)
        {
            attackShootTimer -= Time.deltaTime;
        }
        if (attackShootTimer <= 0)
        {
            isAttackShoot = false;
        }
    }
    public void AttackSword()
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

    #endregion

    #region SFX & OTHERS

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
        if (angle <= 14 && angle >= 0 || angle <= 360 && angle >= 346)
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

    void ChangeAttackPoint(string dir)
    {
        switch (dir)
        {
            case "NE":
                attackPoint = attackPoint_SENE;
                break;
            case "NW":
                attackPoint = attackPoint_SWNW;
                break;
            case "SE":
                attackPoint = attackPoint_SENE;
                break;
            case "SW":
                attackPoint = attackPoint_SWNW;
                break;
            case "S":
                attackPoint = attackPoint_S;
                break;
            case "N":
                attackPoint = attackPoint_N;
                break;
            case "E":
                attackPoint = attackPoint_E;
                break;
            case "W":
                attackPoint = attackPoint_W;
                break;

        }
    }
    private void UpdateSound()
    {
        if (isAttackSword)
        {
            PLAYBACK_STATE plabackState;
            slashAttack_SFX.getPlaybackState(out plabackState);
            if (plabackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                slashAttack_SFX.start();
            }
        }
        else
        {
            slashAttack_SFX.stop(STOP_MODE.ALLOWFADEOUT);
        }

    }
    #endregion

}
