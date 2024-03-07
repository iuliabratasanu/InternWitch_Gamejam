using UnityEngine;

public class Poison : MonoBehaviour
{
    public float targetHeight = 0.001f;
    private Vector3 destination, originalPosition;
    //private bool isRising = false;

    void Start()
    {
        originalPosition = transform.position;
        destination = new Vector3(originalPosition.x, targetHeight, originalPosition.z);
    }

    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position from screen space to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f; // Assuming the objects are on the same z-plane

        // Compare the mouse position with the object position
        if (Vector3.Distance(worldMousePosition, originalPosition) < 1.0f)
        {
            RiseObject();
        }
        else
        {
            ReturnObject();
        }
    }

    void RiseObject()
    {
        //transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
        if (transform.position.y < 2.5f)
        {
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        }
    }

    void ReturnObject()
    {
        //transform.position = originalPosition;
        transform.position = Vector3.Lerp(transform.position, originalPosition, 10 * Time.deltaTime);
    }
}