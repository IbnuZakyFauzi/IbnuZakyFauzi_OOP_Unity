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

    private float xLimitRight = 8.7f;   
    private float xLimitLeft = -8.7f;   
    private float yLimitTop = 4.49f;    
    private float yLimitBottom = -5f;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = moveDirection * maxSpeed;

        // Membatasi posisi pemain agar tetap dalam area yang diinginkan
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xLimitLeft, xLimitRight);  // Membatasi posisi kiri dan kanan
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yLimitBottom, yLimitTop);  // Membatasi posisi atas dan bawah

        rb.position = clampedPosition;
    }

    private Vector2 GetFriction(){
        return rb.velocity.magnitude > 0 ? stopFriction : Vector2.zero;
    }

    public bool IsMoving(){
        return rb.velocity.magnitude > 0.1f;
    }
}
