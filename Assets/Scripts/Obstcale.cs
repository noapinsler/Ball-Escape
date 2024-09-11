using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f; // Speed at which the obstacle falls

    void Update()
    {
        // Move the obstacle down the screen
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destroy the obstacle if it falls off the screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the obstacle collides with the player, trigger game over logic
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // Additional code for game over
        }
    }
}