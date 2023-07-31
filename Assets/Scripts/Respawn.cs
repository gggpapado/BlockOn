using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject objectToRespawn; // The object to respawn
    public float respawnTime = 7f; // The duration before respawning

    private Vector3 startingPosition; // The starting position of the object
    private bool isRespawning; // Flag to check if the object is respawning

    private void Start()
    {
        startingPosition = transform.position; // Store the starting position of the object
        isRespawning = false; // Set the respawning flag to false
    }

    private void Update()
    {
        if (!isRespawning)
        {
            respawnTime -= Time.deltaTime; // Decrease the respawn time by the elapsed time
            if (respawnTime <= 0)
            {
                RespawnObject(); // Call the method to respawn the object
            }
        }
    }

    private void RespawnObject()
    {
        transform.position = startingPosition; // Reset the position of the object to the starting position
        respawnTime = 7f; // Reset the respawn time to its initial value
        isRespawning = true; // Set the respawning flag to true

        // Start a coroutine to wait for a moment before resetting the respawning flag
        StartCoroutine(ResetRespawningFlag());
    }

    private IEnumerator ResetRespawningFlag()
    {
        yield return new WaitForSeconds(0.1f); // Wait for a short duration before resetting the flag
        isRespawning = false; // Reset the respawning flag
    }
    
}
