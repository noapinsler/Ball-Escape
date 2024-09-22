using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball movement

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component
    private float screenHalfWidthInWorldUnits; // Half of the screen width in world units

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();

        // Optional: Set gravity scale to 0 if you don't want gravity to affect the ball
        rb.gravityScale = 0;

        // Calculate half of the screen width in world units
        float halfBallWidth = transform.localScale.x / 2f; // Assuming the ball is uniformly scaled
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfBallWidth;
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

        // Clamp the ball's position within the screen bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
        transform.position = clampedPosition;
    }
}