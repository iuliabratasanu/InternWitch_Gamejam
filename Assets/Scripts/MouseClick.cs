using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public MouseDetector mouseDetector;
    public float treshold = 1.0f;
    private bool isClicked = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Compare the mouse position with the object position
        if (!isClicked && mouseDetector.isMouseDetected(originalPosition, treshold) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Am dat click stanga pe obiect");
            isClicked = true;
            PotionAnimation();
        }
    }

    void PotionAnimation()
    {
        Vector3 newPosition = transform.position;
        Vector3 targetPosition = new Vector3(9.0f, -0.6f, newPosition.z);

        // Debug.Log(newPosition + " vs " + targetPosition);

        // // Perform the animation only once after a single click
        // transform.position = Vector3.Lerp(newPosition, targetPosition, Time.deltaTime);

        // Define a speed for the animation
        float speed = 0.5f; // Adjust this value as needed

        // Increase the interpolation factor over time
        float t = Mathf.Clamp01(speed * Time.deltaTime);

        // Perform the animation from newPosition to targetPosition
        transform.position = Vector3.Lerp(newPosition, targetPosition, t);
    }
}
