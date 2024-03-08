using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetector : MonoBehaviour
{
    public bool isMouseDetected(Vector3 originalPosition, float treshold)
    {
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position from screen space to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f; // Assuming the objects are on the same z-plane
        float distance = Vector3.Distance(worldMousePosition, originalPosition);

        return distance < treshold;
    }
}
