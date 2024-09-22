using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 10f; // 1 minute = 60 seconds
    public GameObject gameWinnerUI;  // Reference to the Game Over UI
    private bool gameWon = false;
    private bool timerIsRunning = false;
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component


    void Update()
    {
        if (timerIsRunning && !gameWon)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 0)
            {
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                gameWon = true;
                WinGame();
            }
        }
    }

    public void StartTimer()
    {
        timeRemaining = 10f;
        timerIsRunning = true;  // Start the countdown
        UpdateTimerDisplay(); // Ensure timer display is updated immediately
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 10);
        int seconds = Mathf.FloorToInt(timeRemaining % 10);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void WinGame()
    {
        Time.timeScale = 0f;  // Freeze the game
        Debug.Log("stop");
        gameWinnerUI.SetActive(true);  // Show the Game winner UI
       
    }
}