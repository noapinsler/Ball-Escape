using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject GameElements;   // Reference to all game elements (ball, obstacles)
    public GameObject MainMenu;       // Reference to the main menu UI
    public GameObject GameOverUI;     // Reference to the Game Over UI (text and button)
    public GameObject GameWinnerUI;

    void Awake()
    {
        // Implement Singleton pattern to ensure there's only one GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Show Game Over UI and handle restarting or quitting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the game
    }
    
    public void ReturnToMenu()
    {
        // Unpause the game
        Time.timeScale = 1f;

        // Hide the game elements and the Game Over UI
        GameElements.SetActive(false);
        GameOverUI.SetActive(false);
        GameWinnerUI.SetActive(false);

        // Show the main menu
        MainMenu.SetActive(true);
    }
}
