using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball movement

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Apply movement to the ball
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
