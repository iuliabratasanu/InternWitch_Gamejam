using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickTest : MonoBehaviour
{
    public MouseDetector mouseDetector;
    public float treshold = 1.0f;
    private Vector3 originalPosition;
    //private bool isRising = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Compare the mouse position with the object position
        if (mouseDetector.isMouseDetected(originalPosition, treshold)
            && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Am dat click stanga pe obiect");
        }
    }
}
