using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;   // Starting point of the platform
    public Transform endPoint;     // Ending point of the platform
    public float speed = 1f;       // Speed at which the platform moves
    public float delay = 2f;       // Delay before platform starts moving at the end point

    private bool movingToEndPoint = true;

    private void Start()
    {
        transform.position = startPoint.position;
    }

    private void Update()
    {
        if (movingToEndPoint)
        {
            // Move towards the end point
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

            // Check if reached the end point
            if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
            {
                movingToEndPoint = false;
                Invoke("SwitchDirection", delay);
            }
        }
        else
        {
            // Move towards the start point
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);

            // Check if reached the start point
            if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
            {
                movingToEndPoint = true;
                Invoke("SwitchDirection", delay);
            }
        }
    }

    private void SwitchDirection()
    {
        // Switch the moving direction of the platform
        movingToEndPoint = !movingToEndPoint;
    }
}
