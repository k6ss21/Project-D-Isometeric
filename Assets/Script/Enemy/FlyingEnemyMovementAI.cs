using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovementAI : MonoBehaviour
{
    public float speedMin;
    public float speedMax;

    private float speed;
    public Vector2 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(speedMin, speedMax);

    }
    void Update()
    {
        Vector2 dir = new Vector2();
        Vector2 motion = new Vector2();

        if (moveDir == Vector2.zero) return;

        dir += moveDir;

        motion = dir.normalized * speed;
        Vector2 temp = CarToIso(motion);
        rb.velocity = temp;

        Destroy(gameObject, 10f);
    }

    Vector2 CarToIso(Vector2 car)
    {
        Vector2 pos = new Vector2();

        pos.x = car.x - car.y;
        pos.y = (car.x + car.y) / 2;
        return pos;
    }

    public void SetDir(Vector2 dir)
    {
        moveDir = dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SickChar sickChar = other.GetComponent<SickChar>();
        if(sickChar != null)
        {
            Debug.Log("heal cancel");
            sickChar.CancelHealing();
        }
    }
}
