using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class ButtonActivationWithCountdown : MonoBehaviour
{
    public TMP_Text timeRemainingText;
    public GameObject buttonToActivate;

    private const float targetTimeInSeconds = 86400f; // 24 hours in seconds
    private bool buttonActivated = false;

    private void Start()
    {
        // Load the last saved activation time from PlayerPrefs
        float lastActivationTime = PlayerPrefs.GetFloat("LastActivationTime", 0f);
        float currentTime = GetUnixTime();
        float elapsedTimeInSeconds = currentTime - lastActivationTime;

        if (elapsedTimeInSeconds >= targetTimeInSeconds)
        {
            // 24 hours have passed, activate the button immediately
            ActivateButton();
        }
        else
        {
            // Set the remaining time to the TextMeshPro text
            float remainingTimeInSeconds = targetTimeInSeconds - elapsedTimeInSeconds;
            UpdateTimeRemainingText(remainingTimeInSeconds);

            // Start a coroutine to update the time remaining text
            StartCoroutine(CountdownTime(lastActivationTime));
        }
    }

    private void ActivateButton()
    {
        buttonToActivate.SetActive(true);
        buttonActivated = true;
    }

    private void UpdateTimeRemainingText(float remainingTimeInSeconds)
    {
        int hours = Mathf.FloorToInt(remainingTimeInSeconds / 3600f);
        int minutes = Mathf.FloorToInt((remainingTimeInSeconds % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(remainingTimeInSeconds % 60f);
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        timeRemainingText.text = timeText;
    }

    private IEnumerator CountdownTime(float activationTime)
    {
        while (!buttonActivated)
        {
            float currentTime = GetUnixTime();
            float elapsedTimeInSeconds = currentTime - activationTime;
            float remainingTimeInSeconds = targetTimeInSeconds - elapsedTimeInSeconds;

            if (remainingTimeInSeconds <= 0f)
            {
                ActivateButton();
                yield break;
            }

            UpdateTimeRemainingText(remainingTimeInSeconds);

            yield return null;
        }
    }

    private void OnApplicationQuit()
    {
        // Save the current time as a Unix timestamp when the application is closed
        PlayerPrefs.SetFloat("LastActivationTime", GetUnixTime());
    }

    private float GetUnixTime()
    {
        return (float)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds;
    }
}




