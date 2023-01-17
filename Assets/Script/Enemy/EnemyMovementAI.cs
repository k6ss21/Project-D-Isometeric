using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMovementAI : MonoBehaviour
{
    // Speed of the enemy

    public EnemyData enemyData;

    float minSpeed;
    float maxSpeed;
    float speed ;

    // Reference to the A* pathfinding component
    public AIPath aiPath;
    public AIDestinationSetter aIDestinationSetter;
    Vector3 direction;
    // Update is called once per frame

    public SpriteRenderer spriteRenderer;

    IAnimationManager animationManager;


    public float angle;

    void Start()
    {
        aIDestinationSetter.target = FindObjectOfType<Player>().transform;
        animationManager = GetComponent(typeof(IAnimationManager)) as IAnimationManager;
        minSpeed = enemyData.minSpeed;
        maxSpeed = enemyData.maxSpeed;
        speed = Random.Range(minSpeed,maxSpeed);
        aiPath.maxSpeed = speed;


    }
    void Update()
    {

        direction = aiPath.desiredVelocity.normalized;
        angle = GetAngleFromVectorFloat(direction);

        ChangeSpriteUsingAngle();
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
    void ChangeSpriteUsingAngle()
    {
        if (angle <= 75 && angle >= 15)
        {
            animationManager.Walk("NE");
            // Debug.Log("NE");
        }
        if (angle <= 14 && angle >= 346)
        {
            //  Debug.Log("E");
            animationManager.Walk("E");
        }
        if (angle <= 345 && angle >= 285)
        {
            //  Debug.Log("SE");
            animationManager.Walk("SE");
        }

        if (angle <= 284 && angle >= 255)
        {
            //  Debug.Log("S");
            animationManager.Walk("S");
        }
        if (angle <= 254 && angle >= 195)
        {
            // Debug.Log("SW");
            animationManager.Walk("SW");
        }
        if (angle <= 194 && angle >= 165)
        {
            //  Debug.Log("W");
            animationManager.Walk("W");
        }
        if (angle <= 164 && angle >= 105)
        {
            // Debug.Log("NW");
            animationManager.Walk("NW");
        }
        if (angle <= 104 && angle >= 74)
        {
            // Debug.Log("N");
            animationManager.Walk("N");
        }

    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
