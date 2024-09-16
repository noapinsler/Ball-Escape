using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! Ball hit an obstacle.");

            // Stop the ball's movement
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;  // Stop any rotation

            // Call the GameOver method from the GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                Debug.LogError("GameManager instance not found!");
            }
        }
    }
}
