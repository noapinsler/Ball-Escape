using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    public TextMeshProUGUI scoreText; // Reference to the UI Text component
    private int score = 0; // Score variable

    void Awake()
    {
        // Ensure there's only one instance of the ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize the score
        score = 0;
        UpdateScoreText();
    }

    // Method to increase the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the UI text to display the current score
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void ResetScore()
    {
        score = 0; // Reset the score
        UpdateScoreText(); // Update the UI to reflect the reset score
    }

}

