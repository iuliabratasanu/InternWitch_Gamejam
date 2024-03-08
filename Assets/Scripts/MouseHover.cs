using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public MouseDetector mouseDetector;
    public MouseClick mouseClick;
    public float targetHeight = 0.001f, treshold = 1.0f;
    private Vector3 destination, originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        destination = new Vector3(originalPosition.x, targetHeight, originalPosition.z);
    }

    void Update()
    {
        // // Compare the mouse position with the object position
        // if (mouseDetector.isMouseDetected(originalPosition, treshold))
        // {
        //     //RiseObject();
        //     if (!mouseClick.isClicked)
        //     {
        //         Debug.Log("Nu ridic");
        //     //     ReturnObject();
        //     }
        //     else
        //     {
        //         Debug.Log("Ridic");
        //     }
        // }
        // else
        // {
        //     if (!mouseClick.isClicked)
        //     {
        //         Debug.Log("Nu mut inapoi");
        //     //     ReturnObject();
        //     }
        //     else
        //     {
        //         Debug.Log("Mut inapoi");
        //     }
        // }
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