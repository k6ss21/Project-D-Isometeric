using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class IsoCharacterController : MonoBehaviour
{
    #region COMPONENTS
    private Rigidbody2D rb;
    private PlayerAnimationManger _playerAnimator;
    private PlayerAttack playerAttack;
    #endregion

    #region  PLAYER 
    [Header("Speed Setting")]


    public float defaultWalkSpeed; //Player default Walk Speed.
    private float walkSpeed; //Player changing walkspeed when abilities active.

    private Vector2 inputDir; // Movement Input Vector.

    public bool isIdle { get; set; }
    private bool isTopDown;

    public string lastMoveDir; // String Contains Direction of last input Direction.

    private EventInstance playerFootsteps; //SFX Instance  for Footsteps. 

    public bool canMove { get; set; } //Boolean to Stop Movement.

    #endregion

    void OnEnable()
    {
        Ab_Speed.OnSpeedBoost += SpeedBoost;
        Stairway.OnPlayerTeleport += Teleport;
        HomePoint.OnTeleportToLab += Teleport;
        LabPoint.OnReturnLastPos += TeleportToLastPos;
    }
    void OnDisable()
    {
        Ab_Speed.OnSpeedBoost -= SpeedBoost;
        Stairway.OnPlayerTeleport -= Teleport;
        HomePoint.OnTeleportToLab -= Teleport;
        LabPoint.OnReturnLastPos -= TeleportToLastPos;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isTopDown = FindObjectOfType<GameEventManager>().topDown;
        _playerAnimator = GetComponent<PlayerAnimationManger>();
        playerAttack = GetComponent<PlayerAttack>();

        playerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.PlayerFootSteps); //Setting FMOD Evnets 
        lastMoveDir = "SW";
        walkSpeed = defaultWalkSpeed;
        canMove = true;
    }
    void Update()
    {
        inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //Get Input from Player
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            UpdateMovement();
        }
        HandleIdle();
    }

    #region PLAYER MOVEMENT
    void UpdateMovement()
    {
        if (isTopDown)
        {
            if (!playerAttack.isAttacking) //cant move when attacking 
            {
                HandleMovementTopDown();
                UpdateSound();
            }
            else
            {
                rb.velocity = Vector2.zero;
                UpdateSound();
            }
        }
        else
        {
            if (!playerAttack.isAttacking) //cant move when attacking 
            {
                HandleMovement();
                UpdateSound();
            }
            else
            {
                rb.velocity = Vector2.zero;
                UpdateSound();
            }
        }
    }
    void HandleMovement()
    {

        Vector2 dir = new Vector2();
        Vector2 motion = new Vector2();

        if (Input.GetKey(KeyCode.W))//  MOve NW
        {
            dir += Vector2.up;
            lastMoveDir = "NW";
            _playerAnimator.PlayerWalk("NW");
        }
        else if (Input.GetKey(KeyCode.A)) //Move SW
        {
            dir += Vector2.left;
            lastMoveDir = "SW";
            _playerAnimator.PlayerWalk("SW");
        }
        else if (Input.GetKey(KeyCode.D)) //  Move NE
        {
            dir += Vector2.right;
            lastMoveDir = "NE";
            _playerAnimator.PlayerWalk("NE");

        }
        else if (Input.GetKey(KeyCode.S)) // Move SE
        {
            dir += Vector2.down;
            lastMoveDir = "SE";

            _playerAnimator.PlayerWalk("SE");
        }
        // Debug.Log("Nor =" + dir);
        motion = dir.normalized * walkSpeed;
        Vector2 temp = CarToIso(motion);
        rb.velocity = temp;
    }
    void HandleMovementTopDown()
    {

        Vector2 dir = new Vector2();
        Vector2 motion = new Vector2();

        if (Input.GetKey(KeyCode.W))//  MOve N
        {
            dir += Vector2.up;
            lastMoveDir = "N";

            _playerAnimator.PlayerWalk("N");

        }
        else if (Input.GetKey(KeyCode.A)) //Move W
        {
            dir += Vector2.left;
            lastMoveDir = "W";
            _playerAnimator.PlayerWalk("W");


        }
        else if (Input.GetKey(KeyCode.D)) //  Move E
        {
            dir += Vector2.right;
            lastMoveDir = "E";


            _playerAnimator.PlayerWalk("E");

        }


        else if (Input.GetKey(KeyCode.S)) // Move S
        {
            dir += Vector2.down;
            lastMoveDir = "S";
            _playerAnimator.PlayerWalk("S");
        }
        // Debug.Log("Nor =" + dir);
        motion = dir.normalized * walkSpeed;
        // Vector2 temp = CarToIso(motion);
        rb.velocity = motion;
    }
    #endregion

    #region PLAYER IDLE

    void HandleIdle()
    {

        if (inputDir == Vector2.zero && !playerAttack.isAttacking && !playerAttack.isAbilityActive)
        {
            isIdle = true;
            IdleAnim();
        }
        else
        {
            isIdle = false;
        }
    }
    void IdleAnim()
    {
        _playerAnimator.PlayerIdle(lastMoveDir);

    }
    #endregion

    #region  SPEED FUNTIONS
    void SpeedBoost(float speed, float time)
    {
        Debug.Log("speed Boost");
        walkSpeed = speed;
        StartCoroutine(SpeedBoostTimer(time));
    }
    IEnumerator SpeedBoostTimer(float time)
    {
        yield return new WaitForSeconds(time);
        walkSpeed = defaultWalkSpeed;
    }
    #endregion

    #region OTHERS

    private Vector3 lastPos;

    public void Teleport(Vector3 pos)
    {
        lastPos = transform.position;
        transform.position = pos;

    }
    public void TeleportToLastPos()
    {
        transform.position = lastPos;
    }

    #endregion  

    #region SFX & OTHERS

    Vector2 CarToIso(Vector2 car)
    {
        Vector2 pos = new Vector2();

        pos.x = car.x - car.y;
        pos.y = (car.x + car.y) / 2;
        return pos;
    }
    void UpdateSound()
    {
        if (rb.velocity != Vector2.zero)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
    #endregion

    #region TEST

    void TestMovement()
    {

        if (inputDir.y > 0)//  MOve NW
        {
            Debug.Log("Move NW");
        }
        if (inputDir.x < 0) //Move SW
        {
            Debug.Log("Move SW");
        }
        if (inputDir.x > 0) //  Move NE
        {
            Debug.Log("Move NE");
        }
        if (inputDir.y < 0) // Move SE
        {
            Debug.Log("Move SE");
        }
    }
    #endregion

}
