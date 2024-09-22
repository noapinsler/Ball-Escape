using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;     // The GameObject holding the menu UI
    public GameObject gameElements; // The GameObject holding all the game objects
    public GameTimer gameTimer;
    public GameObject levelMenu;

    public void StartGame()
    {
        // Hide the main menu UI
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);

    }

    public void ExitGame()
    {
        // Exit the game
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}