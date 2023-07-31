using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonActivationAfterTime : MonoBehaviour
{
    public Button buttonToDeactivate;
    private float deactivationTime = 24f; // 24 seconds

    private void Start()
    {
        // Start the coroutine to deactivate and reactivate the button after the specified time
        StartCoroutine(DeactivateAndReactivateButton());
    }

    private IEnumerator DeactivateAndReactivateButton()
    {
        // Deactivate the button
        buttonToDeactivate.interactable = false;

        // Wait for the deactivation time
        yield return new WaitForSeconds(deactivationTime);

        // Reactivate the button
        buttonToDeactivate.interactable = true;
    }
}





