using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
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

    public Projectile projectilePf;

    [Header("Attack Points")]
    private Transform attackPoint;
    [SerializeField] private Transform attackPoint_SENE;
    [SerializeField] private Transform attackPoint_SWNW;
    [SerializeField] private Transform attackPoint_N;
    [SerializeField] private Transform attackPoint_S;
    [SerializeField] private Transform attackPoint_E;
    [SerializeField] private Transform attackPoint_W;
    [Space(5)]



    private float attackDelay;
    public bool canAttack { get; set; }
    public bool isAttacking { get; private set; }
    public bool isAttackSword { get; private set; }
    public bool isAttackShoot { get; private set; }
    private float attackShootTimer;

    [Header("Attack Settings")]

    [SerializeField] private float DefaultDamageValue;
    [SerializeField] private float shootDamage;

    public bool isAbilityActive;
    public bool isAttackAbilityActive;
    [SerializeField] float attackShootTime;

    private EventInstance slashAttack_SFX;

    private Coroutine swordCoroutine;

    void OnEnable()
    {
        Ab_SkyFallVFX.OnAbilityEnd += SetAttackAbilityActive;
        Ab_MegaAttack.OnMegaAttackTrigger += MegaAttack;
    }

    void OnDisable()
    {
        Ab_SkyFallVFX.OnAbilityEnd -= SetAttackAbilityActive;
        Ab_MegaAttack.OnMegaAttackTrigger -= MegaAttack;
    }

    void Start()
    {
        playerAnimationManger = GetComponent<PlayerAnimationManger>();
        playerAttackCollider = GetComponentInChildren<PlayerAttackCollider>();
        characterController = GetComponent<IsoCharacterController>();
        mouseOverUICheck = GetComponent<MouseOverUICheck>();
        animator = GetComponent<Animator>();

        CreatePooledProjectileObjects();
        slashAttack_SFX = AudioManager.instance.CreateEventInstance(FMODEvents.instance.slashAttack);
        canAttack = true;
        isAttacking = false;
        isAttackSword = false;
        isAttackShoot = false;
    }
    void Update()
    {
        if (canAttack && !isAbilityActive && !isAttackAbilityActive)
        {
            ManageInput();
        }
        AttackShootTimer();
        // UpdateSound();

    }

    public void SetAttackAbilityActive(bool value)
    {
        isAttackAbilityActive = value;
    }
     public void SetAbilityActive(bool value)
    {
        isAbilityActive = value;
    }

    void ManageInput()
    {

        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     if (!isAttacking)
        //     {
        //         isAttacking = true;
        //         MegaAttack();
        //         StartCoroutine(AttackDelayRoutine(2.5f));
        //     }
        // }
        if (Input.GetMouseButtonDown(1))
        {

            if (mouseOverUICheck.IsPointerOverUIElement()) {; return; }
            if (!isAttacking)
            {
                isAttacking = true;
                isAttackSword = true;
                AttackSword();
                playerAttackCollider.SetDamageValue(DefaultDamageValue);
                // StartCoroutine(AttackDelayRoutine(animator.GetCurrentAnimatorStateInfo(0).length));
                swordCoroutine = StartCoroutine(AttackDelayRoutine(.375f));

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
                AudioManager.instance.PlayOneShot(FMODEvents.instance.ProjectileShoot, this.transform.position);
                AttackShoot();
                StartCoroutine(AttackDelayRoutine(attackShootTime));
            }
        }
    }

    public void OnFinishAttackAnim()
    {
        isAttacking = false;
        isAttackSword = false;
    }

    #region ATTACK FUNCTIONS

    void SetCanAttack(bool b)
    {
        canAttack = b;
    }
    IEnumerator AttackDelayRoutine(float t)
    {
        attackDelay = t;
        yield return new WaitForSeconds(attackDelay);
        //  playerAnimationManger.PlayerIdle();
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
        characterController.lastMoveDir = dir;
        playerAnimationManger.Attack2Idle(dir);
        //var projectile = Instantiate(projectilePf, attackPoint.position, Quaternion.identity);

        Projectile projectile = GetPooledProjectileObject();

        if (projectile != null)
        {
            projectile.transform.position = attackPoint.position;
            projectile.gameObject.SetActive(true);
            projectile.Setup(shootDir, shootDamage);
            projectile.Init(DestroyProjectile);
        }


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
        characterController.lastMoveDir = dir;
        playerAnimationManger.Attack(dir);


    }

    public void MegaAttack()
    {
        if (swordCoroutine != null) { StopCoroutine(swordCoroutine); } //Stops Coroutine of Sword Attack of it is running.
        isAttacking = true;
        playerAnimationManger.MegaAttack(characterController.lastMoveDir);
        StartCoroutine(AttackDelayRoutine(2.5f));

    }




    #endregion

    #region OBJECT POOL
    private List<Projectile> projectilePooledObjects = new List<Projectile>();

    private int amountToPool = 10;

    private void CreatePooledProjectileObjects()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            Projectile obj = Instantiate(projectilePf, transform.position, Quaternion.identity, this.transform);
            obj.gameObject.SetActive(false);
            projectilePooledObjects.Add(obj);
        }
    }

    private Projectile GetPooledProjectileObject()
    {
        for (int i = 0; i < projectilePooledObjects.Count; i++)
        {
            if (!projectilePooledObjects[i].gameObject.activeInHierarchy)
            {
                return projectilePooledObjects[i];
            }
        }
        return null;
    }

    private void DestroyProjectile(Projectile projectile)
    {
        projectile.gameObject.transform.position = transform.position;
        projectile.gameObject.SetActive(false);
        //   Destroy(projectile.gameObject);
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
