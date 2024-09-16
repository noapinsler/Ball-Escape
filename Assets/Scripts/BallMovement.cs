using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball movement

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();

        // Optional: Set gravity scale to 0 if you don't want gravity to affect the ball
        rb.gravityScale = 0;
    }

    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Apply movement to the ball only when there is input
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            // If no input, stop horizontal movement
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
