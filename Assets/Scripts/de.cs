using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class de : MonoBehaviour
{
    public Button clickableButton;

    private bool buttonClickedToday = false;

    private void Start()
    {
        // Load the last clicked time from PlayerPrefs
        string lastClickedTimeString = PlayerPrefs.GetString("LastClickedTime", "");
        if (!string.IsNullOrEmpty(lastClickedTimeString))
        {
            // Convert the saved time to DateTime
            DateTime lastClickedTime = DateTime.Parse(lastClickedTimeString);

            // Check if the button was already clicked today
            if (lastClickedTime.Date == DateTime.Today)
            {
                buttonClickedToday = true;
                clickableButton.interactable = false;
            }
        }
    }

    public void OnButtonClick()
    {
        if (!buttonClickedToday)
        {
            // Perform the button's action here.
            Debug.Log("Button clicked!");

            // Mark the button as clicked today
            buttonClickedToday = true;
            clickableButton.interactable = false;

            // Save the current time in PlayerPrefs
            DateTime currentTime = DateTime.Now;
            PlayerPrefs.SetString("LastClickedTime", currentTime.ToString());
        }
    }

    public void ResetButton()
    {
        // Call this function if you want to reset the button, allowing it to be clicked again the next day.
        buttonClickedToday = false;
        clickableButton.interactable = true;
        PlayerPrefs.DeleteKey("LastClickedTime");
    }
}

