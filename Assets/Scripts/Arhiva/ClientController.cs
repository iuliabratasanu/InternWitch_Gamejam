using System.Collections;
using UnityEngine;
using TMPro;

public class ClientController : MonoBehaviour
{
    public GameObject OrderBox; // Assign your prefab in Unity Editor

    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMoving = false; // Flag to control movement
    private bool orderDelivered = false; // Flag to track order delivery

    private ClientManager clientManager;

    private void Start()
    {
        clientManager = FindObjectOfType<ClientManager>();
        if (clientManager == null)
        {
            Debug.LogError("ClientManager script not found.");
            return;
        }

        waypoints = new Vector3[]
        {
            new Vector3(-12.21f, -3.16f, 0),
            new Vector3(-1.83f, -3.16f, 0),
            new Vector3(12.49f, -3.16f, 0)
        };

        StartCoroutine(MoveToWaypointCoroutine(waypoints[currentWaypointIndex]));
    }

    private void Update()
    {
        if (isMoving && Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.01f)
        {
            if (currentWaypointIndex == 1)
            {
                string requestName = clientManager.currentOrder.requestName;
                ShowBubbleText(requestName);
            }

            MoveToNextWaypoint();
        }

        if (orderDelivered && currentWaypointIndex == waypoints.Length - 1)
        {
            orderDelivered = false;
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        if (!isMoving && currentWaypointIndex < waypoints.Length - 1)
        {
            currentWaypointIndex++;
            StartCoroutine(MoveToWaypointCoroutine(waypoints[currentWaypointIndex]));
        }
        else if (currentWaypointIndex == waypoints.Length - 1)
        {
            currentWaypointIndex = 0;
            StartCoroutine(SpawnNextClient());
        }
    }

    private IEnumerator MoveToWaypointCoroutine(Vector3 destination)
    {
        float speed = 2f;
        isMoving = true;

        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }

    private IEnumerator SpawnNextClient()
    {
        yield return new WaitForSeconds(5f);

        transform.position = waypoints[0];
        MoveToNextWaypoint();
    }

    private void ShowBubbleText(string text)
    {
        if (OrderBox == null)
        {
            Debug.LogError("OrderBox prefab is not assigned.");
            return;
        }

        GameObject bubbleTextObject = Instantiate(OrderBox, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        TextMeshProUGUI textMeshPro = bubbleTextObject.transform.Find("Canvas/OrderText").GetComponent<TextMeshProUGUI>();

        if (textMeshPro != null)
        {
            textMeshPro.text = text;
            Destroy(bubbleTextObject, 3f);
        }
        else
        {
            Debug.LogError("TextMeshPro component not found in OrderBox prefab.");
        }
    }

    public void DeliverOrder(bool isGood)
    {
        orderDelivered = true;
    }
}
