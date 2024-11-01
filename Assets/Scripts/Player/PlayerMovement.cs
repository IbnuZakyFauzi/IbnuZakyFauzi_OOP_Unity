using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (Mathf.Pow(timeToFullSpeed.magnitude, 2));
        stopFriction = -2 * maxSpeed / (Mathf.Pow(timeToStop.magnitude, 2));
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveDirection != Vector2.zero)
        {
            Vector2 targetVelocity = moveDirection * maxSpeed;
            rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, moveVelocity.magnitude * Time.deltaTime);
        }
        else
        {
            Vector2 frictionForce = GetFriction();
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, frictionForce.magnitude * Time.deltaTime);

            if (rb.velocity.magnitude < stopClamp.magnitude)
            {
                rb.velocity = Vector2.zero;
            }
        }

        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );
    }

    public Vector2 GetFriction()
    {
        if (moveDirection != Vector2.zero)
        {
            return new Vector2(
                moveDirection.x != 0 ? moveFriction.x : 0,
                moveDirection.y != 0 ? moveFriction.y : 0
            );
        }
        else
        {
            return new Vector2(
                rb.velocity.x != 0 ? stopFriction.x : 0,
                rb.velocity.y != 0 ? stopFriction.y : 0
            );
        }
    }

    public void MoveBound()
    {
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }
}