using UnityEngine;

public class Laser : MonoBehaviour
{
  public float lifetime = 2f; // Time before the laser is destroyed
  public float laserSpeed = 10f; // Speed of the laser

  private Rigidbody2D rb;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(0, laserSpeed); // Move the laser upwards immediately
    Destroy(gameObject, lifetime); // Destroy the laser after its lifetime
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    // Check for collision with obstacles
    if ((other.CompareTag("Obstacle")) || (other.CompareTag("DiagonalObstacle")))
    {
      Debug.Log("Laser hit an obstacle, dest  roying both.");
      Destroy(other.gameObject); // Destroy the obstacle
      Destroy(gameObject); // Destroy the laser
    }
  }
}
