using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 2; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        Dash();
        Teleport();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            Debug.Log("Jumped! Jump Count: " + jumpCount);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // 触地后重置跳跃次数
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float dashSpeed = 10f;
            rb.linearVelocity = new Vector2(transform.localScale.x * dashSpeed, rb.linearVelocity.y);
            Debug.Log("Dashed!");
        }
    }

    void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            float teleportDistance = 3f;
            transform.position += new Vector3(teleportDistance, 0, 0);
            Debug.Log("Teleported!");
        }
    }
}
