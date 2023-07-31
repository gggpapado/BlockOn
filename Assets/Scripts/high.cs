using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class high : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Reference to the UI Text component for displaying the high score

    private float currentTime; // Current time in seconds
    private float highScore; // Current high score in seconds

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f); // Load the high score from PlayerPrefs
        UpdateHighScoreText(); // Update the high score text initially
    }

    private void Update()
    {
        currentTime += Time.deltaTime; // Increase the current time by the time passed since the last frame

        // Check if the current time surpasses the high score
        if (currentTime > highScore)
        {
            highScore = currentTime; // Update the high score
            PlayerPrefs.SetFloat("HighScore", highScore); // Save the high score to PlayerPrefs
            UpdateHighScoreText(); // Update the high score text
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + FormatTime(highScore); // Display the high score in the UI Text component
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}

