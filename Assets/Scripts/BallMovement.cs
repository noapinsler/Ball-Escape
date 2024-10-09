using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball movement
    public GameObject laserPrefab; // Assign this in the Inspector
    public float laserSpeed = 10f; // Speed of the laser
    public float constantYPosition = -192f; // Set this to the desired constant Y position for the ball

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component
    private float screenHalfWidthInWorldUnits; // Half of the screen width in world units

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Prevent gravity from affecting the ball

        // Calculate half of the screen width in world units
        float halfBallWidth = transform.localScale.x / 2f; // Assuming the ball is uniformly scaled
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfBallWidth;
    }

    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Apply horizontal movement to the ball only when there is input
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
        
        // Keep the Y position constant
        clampedPosition.y = constantYPosition; // Set to your desired Y position
        transform.position = clampedPosition;


        // Shoot laser when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLaser(); // Call the method to shoot the laser
        }
    }

    void ShootLaser()
    {
        // Instantiate the laser prefab at the ball's position
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the laser and set its velocity
        Rigidbody2D laserRb = laser.GetComponent<Rigidbody2D>();
        laserRb.velocity = new Vector2(0, laserSpeed); // Move the laser upwards
    }
}

