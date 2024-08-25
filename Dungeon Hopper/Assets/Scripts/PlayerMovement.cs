using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 5f;
    private float jumpingPower = 21f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isMovementEnabled = true;  // Flag to control movement

    private void Start()
    {
        // Set collision detection to Continuous and interpolation to Interpolate
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        // Start the coroutine to disable movement
        StartCoroutine(DisableMovementDuringCutscene(4.5f));  // Adjust the duration as needed
    }

    void Update()
    {
        if (!isMovementEnabled) return;  // Skip movement if it's disabled

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (!isMovementEnabled) return;  // Skip movement if it's disabled

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Player has touched the lava!");
            gameObject.SetActive(false);

            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private IEnumerator DisableMovementDuringCutscene(float duration)
    {
        isMovementEnabled = false;  // Disable movement
        yield return new WaitForSeconds(duration);  // Wait for the specified duration
        isMovementEnabled = true;   // Re-enable movement
    }
}
