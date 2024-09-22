using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public GameObject mainMenu;     // The GameObject holding the menu UI
    public GameObject gameElements; // The GameObject holding all the game objects
    public GameTimer gameTimer;
    public Obstacle obstacleSpeed;
    public GameObject levelMenu;

    public ObstacleSpawner obstcaleSpawner;

    public void Easy()
    {
        obstacleSpeed.setObstacleSpeed(10);
        obstcaleSpawner.SetSpawnInterval(2f);
        Startgame();
    }

    public void Medium()
    {
        obstacleSpeed.setObstacleSpeed(20);
        obstcaleSpawner.SetSpawnInterval(1f);
        Startgame();
    }

    public void Hard()
    {
        obstacleSpeed.setObstacleSpeed(30);
        obstcaleSpawner.SetSpawnInterval(0.5f);

        Startgame();
    }

    public void Startgame()
    {
        levelMenu.SetActive(false);
        // Show the game elements
        gameElements.SetActive(true);
        // Optionally reset game time if you paused it before
        Time.timeScale = 1f;
        gameTimer.StartTimer();
    }
}