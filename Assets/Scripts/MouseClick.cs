using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public MouseDetector mouseDetector;
    public float treshold = 1.0f;
    public bool isClicked = false;
    private Vector3 originalPosition;
    //private float elapsedTime = 0.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Compare the mouse position with the object position
        if (!isClicked && mouseDetector.isMouseDetected(transform.position, treshold))
        {
            //Debug.Log("Mouse detected!");
            HandleMouseClick();
        }
    }

    void HandleMouseClick()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked!");
            isClicked = true;
            PotionAnimation();
        }
    }

    void PotionAnimation()
    {
        // Implement your potion animation logic here
    }

    // void PointToPointAnimation(Vector3 startPosition, Vector3 endPosition, float duration)
    // {
    //     elapsedTime += Time.deltaTime;

    //     // Calculate the interpolation factor based on the elapsed time and duration
    //     float t = Mathf.Clamp01(elapsedTime / duration);

    //     // Interpolate between the start and end positions
    //     transform.position = Vector3.Lerp(startPosition, endPosition, t);

    //     // If the interpolation is complete, reset the elapsed time
    //     if (t >= 1.0f)
    //     {
    //         elapsedTime = 0.0f;
    //     }        
    // }

    // void PotionAnimation()
    // {
    //     Vector3 newPosition = transform.position;
    //     Vector3 targetPosition = new Vector3(9.0f, -0.6f, newPosition.z);
    //     PointToPointAnimation(newPosition, targetPosition, 5.0f);
    //     // // Debug.Log(newPosition + " vs " + targetPosition);

    //     // // // Perform the animation only once after a single click
    //     // // transform.position = Vector3.Lerp(newPosition, targetPosition, Time.deltaTime);

    //     // // Define a speed for the animation
    //     // float speed = 0.5f; // Adjust this value as needed

    //     // // Increase the interpolation factor over time
    //     // float t = Mathf.Clamp01(speed * Time.deltaTime);

    //     // // Perform the animation from newPosition to targetPosition
    //     // transform.position = Vector3.Lerp(newPosition, targetPosition, t);
    // }
}
