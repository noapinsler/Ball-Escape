using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameElements;   // Reference to all game elements (ball, obstacles)
    public GameObject MainMenu;       // Reference to the main menu UI
    public GameObject GameOverUI;     // Reference to the Game Over UI (text and button)
    public GameObject GameWinnerUI;

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


