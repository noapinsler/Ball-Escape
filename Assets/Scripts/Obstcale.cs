using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f; // Speed at which the obstacle falls
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component if needed for movement
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the obstacle down the screen
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -speed);  // Move down at constant speed
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Destroy the obstacle if it falls off the screen
        if (transform.position.y < -6f)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! Obstacle hit the player.");

            Destroy(gameObject);

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