using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float walkSpeed;
    public float frameRate;

    PlayerAnimationManger _playerAnimator;

    Vector2 inputDir;

    public bool isTopDown;

    public string lastMoveDir;

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimationManger>();
        IdleAnim();
    }
    void Update()
    {
        inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (isTopDown)
        {
            HandleMovementTopDown();
        }
        else
        {
            HandleMovement();
        }


        if (rb.velocity == Vector2.zero)
        {
           IdleAnim();
        }

    }

    void IdleAnim()
    {
        _playerAnimator.PlayerIdle(lastMoveDir);
      
    }

   

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

    Vector2 CarToIso(Vector2 car)
    {
        Vector2 pos = new Vector2();

        pos.x = car.x - car.y;
        pos.y = (car.x + car.y) / 2;
        return pos;
    }

}
