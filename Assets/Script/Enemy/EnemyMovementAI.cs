using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMovementAI : MonoBehaviour
{
    // Speed of the enemy

    public EnemyData enemyData;

    IEnemyAttackManger enemyAttackManger;

    float minSpeed;
    float maxSpeed;
    float speed;

    // Reference to the A* pathfinding component
    public AIPath aiPath;
    public AIDestinationSetter aIDestinationSetter;
    Vector3 direction;
    // Update is called once per frame

    public SpriteRenderer spriteRenderer;

    IAnimationManager animationManager;

    public bool isIdle;
    public float angle;
    public bool isTopDown;
    private string lastMoveDir;
    
  

    void Start()
    {
        aIDestinationSetter.target = FindObjectOfType<Player>().RandomFollowPos();
        isTopDown = FindObjectOfType<GameEventManager>().topDown;
        animationManager = GetComponent(typeof(IAnimationManager)) as IAnimationManager;
        enemyAttackManger = gameObject.GetComponent<IEnemyAttackManger>();
        minSpeed = enemyData.minSpeed;
        maxSpeed = enemyData.maxSpeed;

        speed =Mathf.Round(((Random.Range(minSpeed, maxSpeed))*100))/100;       
        aiPath.maxSpeed = speed;
        lastMoveDir = "N";
        animationManager.Idle(lastMoveDir);


    }
    void Update()
    {

        direction = aiPath.desiredVelocity.normalized;
        angle = GetAngleFromVectorFloat(direction);

        // ChangeSpriteUsingAngle();
        if (isTopDown && !aiPath.reachedDestination)
        {
            ChangeSpriteUsingAngleTopDown();
        }
        else
        {
            ChangeSpriteUsingAngle();
        }
        
//        Debug.Log(enemyAttackManger.isAttacking );
        if (aiPath.velocity == Vector3.zero && !enemyAttackManger.isAttacking)
        {
            isIdle = true;
            animationManager.Idle(lastMoveDir);
            LookAtTargetWhenIdle();
        }
        else
        {
            isIdle = false;
        }

    }
    public void SetDefault()
    {
        speed =Mathf.Round(((Random.Range(minSpeed, maxSpeed))*100))/100;       
        aiPath.maxSpeed = speed;
        lastMoveDir = "N";
        animationManager.Idle(lastMoveDir);
    }
    
    void LookAtTargetWhenIdle()
    {
        Vector3 targetDir = (aIDestinationSetter.target.position - transform.position).normalized;
        float dirAngle = GetAngleFromVectorFloat(targetDir);
        DirUsingAngle(dirAngle);

    }

    void ChangeSprite()
    {
        if ((direction.x >= 0.27f && direction.x <= .97f) && (direction.y <= .97f && direction.y >= 0.27f))
        {
            spriteRenderer.flipX = false;

            Debug.Log("NE");
        }
        if ((direction.x >= 0.98f) && (direction.y <= 0.26f && direction.y >= -0.26f))
        {
            Debug.Log("E");
            spriteRenderer.flipX = false;

        }
        if ((direction.x >= 0.27f && direction.x <= .97f) && (direction.y >= -.97f && direction.y <= -0.27f))
        {
            Debug.Log("SE");
            spriteRenderer.flipX = false;

        }

        if ((direction.x <= 0.26f && direction.x >= -0.26f) && (direction.y <= 0.98f))
        {
            Debug.Log("S");
            spriteRenderer.flipX = false;

        }
        if ((direction.x <= -0.27f && direction.x >= -.97f) && (direction.y >= -.97f && direction.y <= -0.27f))
        {
            Debug.Log("SW");
            spriteRenderer.flipX = true;

        }
        if ((direction.x <= -0.98f) && (direction.y <= 0.26f && direction.y >= -0.26f))
        {
            Debug.Log("W");
            Debug.Log("E");
            spriteRenderer.flipX = true;

        }
        if ((direction.x <= -0.27f && direction.x >= -.97f) && (direction.y <= .97f && direction.y >= 0.27f))
        {
            Debug.Log("NW");
            spriteRenderer.flipX = true;
            Debug.Log("NE");
        }
        if ((direction.x >= -0.26f && direction.x <= 0.26f) && (direction.y <= 0.98f))
        {
            Debug.Log("N");
            spriteRenderer.flipX = false;
            //  spriteRenderer.sprite = nSprite;
        }


    }
    // void ChangeSpriteUsingAngle()
    // {
    //     if (angle <= 75 && angle >= 15)
    //     {
    //         animationManager.Walk("NE");
    //         // Debug.Log("NE");
    //     }
    //     if (angle <= 14 && angle >= 346)
    //     {
    //         //  Debug.Log("E");
    //         animationManager.Walk("E");
    //     }
    //     if (angle <= 345 && angle >= 285)
    //     {
    //         //  Debug.Log("SE");
    //         animationManager.Walk("SE");
    //     }

    //     if (angle <= 284 && angle >= 255)
    //     {
    //         //  Debug.Log("S");
    //         animationManager.Walk("S");
    //     }
    //     if (angle <= 254 && angle >= 195)
    //     {
    //         // Debug.Log("SW");
    //         animationManager.Walk("SW");
    //     }
    //     if (angle <= 194 && angle >= 165)
    //     {
    //         //  Debug.Log("W");
    //         animationManager.Walk("W");
    //     }
    //     if (angle <= 164 && angle >= 105)
    //     {
    //         // Debug.Log("NW");
    //         animationManager.Walk("NW");
    //     }
    //     if (angle <= 104 && angle >= 74)
    //     {
    //         // Debug.Log("N");
    //         animationManager.Walk("N");
    //     }

    // }

    void ChangeSpriteUsingAngle()
    {
        if (angle <= 89 && angle >= 1)
        {
            lastMoveDir = "NE";
            animationManager.Walk("NE");
            // Debug.Log("NE");
        }

        if (angle <= 360 && angle >= 271)
        {
            //  Debug.Log("SE");
            lastMoveDir = "SE";
            animationManager.Walk("SE");

        }

        if (angle <= 270 && angle >= 180)
        {
            // Debug.Log("SW");
            lastMoveDir = "SW";
            animationManager.Walk("SW");
        }

        if (angle <= 179 && angle >= 90)
        {
            // Debug.Log("NW");
            lastMoveDir = "NW";
            animationManager.Walk("NW");
        }

    }

    void ChangeSpriteUsingAngleTopDown()
    {
        if (angle <= 45 && angle >= 0 || angle <= 360 && angle >= 316)
        {
            lastMoveDir = "E";
            animationManager.Walk("E");
        }
        if (angle <= 135 && angle >= 46)
        {
            lastMoveDir = "N";
            animationManager.Walk("N");
        }
        if (angle <= 225 && angle >= 136)
        {
            lastMoveDir = "W";
            animationManager.Walk("W");
        }
        if (angle <= 315 && angle >= 226)
        {
            lastMoveDir = "S";
            animationManager.Walk("S");
        }
    }

    void DirUsingAngle(float dirAngle) //Change Last Direction When Idle With Angle
    {
        if (dirAngle <= 89 && dirAngle >= 1)
        {
            lastMoveDir = "NE";
        }

        if (dirAngle <= 360 && dirAngle >= 271)
        {
            //  Debug.Log("SE");
            lastMoveDir = "SE";
        }

        if (dirAngle <= 270 && dirAngle >= 180)
        {
            // Debug.Log("SW");
            lastMoveDir = "SW";
        }
        if (dirAngle <= 179 && dirAngle >= 90)
        {
            // Debug.Log("NW");
            lastMoveDir = "NW";
        }
        if (dirAngle <= 45 && dirAngle >= 0 || dirAngle <= 360 && dirAngle >= 316)
        {
            lastMoveDir = "E";
        }
        if (dirAngle <= 135 && dirAngle >= 46)
        {
            lastMoveDir = "N";
        }
        if (dirAngle <= 225 && dirAngle >= 136)
        {
            lastMoveDir = "W";
        }
        if (dirAngle <= 315 && dirAngle >= 226)
        {
            lastMoveDir = "S";
        }


    }





    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public string GetLastMoveDir()
    {
        return lastMoveDir;
    }
}
