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

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimationManger>();
    }
    void Update()
    {
        inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        HandleMovement();

        if (rb.velocity == Vector2.zero)
        {
            _playerAnimator.PlayerIdle();
        }

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
            _playerAnimator.PlayerWalk(2);

        }
        else if (Input.GetKey(KeyCode.A)) //Move SW
        {
            dir += Vector2.left;
            _playerAnimator.PlayerWalk(4);

        }
        else if (Input.GetKey(KeyCode.D)) //  Move NE
        {
            dir += Vector2.right;
            _playerAnimator.PlayerWalk(1);
        }


        else if (Input.GetKey(KeyCode.S)) // Move SE
        {
            dir += Vector2.down;
            _playerAnimator.PlayerWalk(3);
        }
        // Debug.Log("Nor =" + dir);
        motion = dir.normalized * walkSpeed;
        Vector2 temp = CarToIso(motion);
        rb.velocity = temp;
    }

    Vector2 CarToIso(Vector2 car)
    {
        Vector2 pos = new Vector2();

        pos.x = car.x - car.y;
        pos.y = (car.x + car.y) / 2;
        return pos;
    }

}
