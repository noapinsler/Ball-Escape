using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab of the obstacle
    public float spawnInterval = 2f;  // Time interval between spawns
    public float spawnRangeX = 8f;    // Range of X-axis for spawning

    private float timer;

    void Update()
    {
        // Increment the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // Check if the timer exceeds the spawn interval
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnObstacle()
    {
        // Randomize the X position for spawning within the specified range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        // Instantiate the obstacle at the randomized position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
