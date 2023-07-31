using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public float minDisappearTime = 3f;
    public float maxDisappearTime = 10f;

    private Renderer objectRenderer;
    private Collider[] colliders;
    private bool isDisappeared;
    private float timer;
    private float currentDisappearTime;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        StartDisappearTimer();
    }

    private void Update()
    {
        if (isDisappeared)
        {
            timer += Time.deltaTime;
            if (timer >= currentDisappearTime)
            {
                Reappear();
                StartDisappearTimer();
            }
        }
    }

    private void StartDisappearTimer()
    {
        currentDisappearTime = Random.Range(minDisappearTime, maxDisappearTime);
        Invoke("Disappear", currentDisappearTime);
    }

    private void Disappear()
    {
        isDisappeared = true;
        timer = 0f;

        // Disable the renderer
        objectRenderer.enabled = false;

        // Disable all colliders
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }

    private void Reappear()
    {
        isDisappeared = false;

        // Enable the renderer
        objectRenderer.enabled = true;

        // Enable all colliders
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
    
}
