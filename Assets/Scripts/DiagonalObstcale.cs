using UnityEngine;

public class DiagonalObstacle : MonoBehaviour
{
  public float speed = 5f; // Speed at which the obstacle moves
  public Vector2 direction = new Vector2(-1, -1); // Default diagonal direction (-1, -1 means down-left)

  private Rigidbody2D rb;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    // Move the obstacle diagonally
    if (rb != null)
    {
      rb.velocity = direction.normalized * speed; // Move in the specified diagonal direction
    }
    else
    {
      transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    // Destroy the obstacle if it falls off the screen
    if (transform.position.y < -9f)
    {
      Debug.Log("Destroying diagonal obstacle");
      Destroy(gameObject);
    }
  }

  public void SetDirection(Vector2 newDirection)
  {
    direction = newDirection.normalized;
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
