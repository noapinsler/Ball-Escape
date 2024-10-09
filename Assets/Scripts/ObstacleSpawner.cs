using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject regularObstaclePrefab;  // Reference to the regular obstacle prefab
    public GameObject diagonalObstaclePrefab; // Reference to the diagonal obstacle prefab
    public float spawnInterval = 2.0f;  // Time between spawns
    public float spawnXRange = 5.0f;    // Range for X position for spawning
    public float spawnYPosition = 10.0f;  // Y position to spawn obstacles at
    public float diagonalSpawnChance = 0.2f; // Chance (0 to 1) that a diagonal obstacle will spawn

    private float timer = 0;

    void Start()
    {
        Debug.Log("Initial obstaclePrefab reference: " + (regularObstaclePrefab != null ? regularObstaclePrefab.name : "None"));
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
        GameObject selectedPrefab;

        // Determine whether to spawn a diagonal obstacle or a regular one
        if (Random.value < diagonalSpawnChance)
        {
            // Spawn diagonal obstacle
            selectedPrefab = diagonalObstaclePrefab;
            Debug.Log("Spawning diagonal obstacle.");
        }
        else
        {
            // Spawn regular obstacle
            selectedPrefab = regularObstaclePrefab;
            Debug.Log("Spawning regular obstacle.");
        }

        if (selectedPrefab == null)
        {
            Debug.LogError("Selected obstacle prefab is missing!");
            return;  // Exit early to avoid errors
        }

        // Calculate a random position within the X range
        float spawnX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPosition = new Vector3(spawnX, spawnYPosition, 0);

        // Instantiate the selected prefab at the calculated position
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
    
    public void SetSpawnInterval(float newSpawnInterval)
    {
        spawnInterval = newSpawnInterval;
    }
}
