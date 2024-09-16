using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Reference to the prefab (must be set in the Inspector)
    public float spawnInterval = 2.0f;  // Time between spawns
    public float spawnXRange = 5.0f;    // Range for X position for spawning
    public float spawnYPosition = 10.0f;  // Y position to spawn obstacles at

    private float timer = 0;

    void Start()
    {
        Debug.Log("Initial obstaclePrefab reference: " + (obstaclePrefab != null ? obstaclePrefab.name : "None"));
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle prefab is missing or has been destroyed!");
            return;  // Exit early to avoid errors
        }

        Debug.Log("Spawning obstacle from prefab: " + obstaclePrefab.name);  // Debug line

        // Calculate a random position within the X range
        float spawnX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPosition = new Vector3(spawnX, spawnYPosition, 0);


        // Instantiate the prefab at the calculated position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
