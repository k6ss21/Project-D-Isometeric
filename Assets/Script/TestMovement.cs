using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            HandleDash();
        }
    }

    [SerializeField] float startDashTime = 1f;
    [SerializeField] float dashSpeed = 1f;

    public float currentDashTime;

    void HandleDash()
    {

        StartCoroutine(Dash(Vector2.up));

    }
    IEnumerator Dash(Vector2 direction)
    {
        Debug.Log("Dash");
        currentDashTime = startDashTime;
        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime;
            rb.velocity = direction * dashSpeed;
            yield return null;
        }
        rb.velocity = Vector2.zero;
    }
}
