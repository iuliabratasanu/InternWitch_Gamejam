using UnityEngine;

public class ClientReaction : MonoBehaviour
{
    private bool orderSatisfied = false;
    private string[] initialOrderMapping = { "green", "purple", "orange" };

    private string clientInitialOrder;

    // Function to set the initial order for the client
    public void SetInitialOrder(string initialOrder)
    {
        clientInitialOrder = initialOrder;
        Debug.Log("Initial Order: " + initialOrder);
    }

    // Function to check if the player's mixed potion matches the client's desired effect
    public bool CheckOrderSatisfaction(string mixedPotion)
    {
        // Find the index of the client's initial order in the mapping array
        int orderIndex = System.Array.IndexOf(initialOrderMapping, clientInitialOrder);

        if (orderIndex != -1)
        {
            // Check if the mixed potion matches the corresponding index in the mapping array
            orderSatisfied = mixedPotion == initialOrderMapping[orderIndex];
        }
        else
        {
            // Handle unknown initial order
            Debug.LogWarning("Unknown initial order: " + clientInitialOrder);
            orderSatisfied = false;
        }

        return orderSatisfied;
    }

    public void ReactToPotion(string mixedPotion)
    {
        if (CheckOrderSatisfaction(mixedPotion))
        {
            // Add logic for client reactions based on the mixed potion
            switch (mixedPotion)
            {
                case "green":
                    MakeClientOlder();
                    break;
                case "purple":
                    TransformToMonkey();
                    break;
                case "orange":
                    MakeClientPrettier();
                    break;
                default:
                    Debug.LogWarning("Unknown mixed potion: " + mixedPotion);
                    break;
            }
        }
        else
        {
            Debug.Log("Wrong order! Client is not satisfied.");
            // Handle unsatisfied client, e.g., deduct points or show negative feedback
        }
    }

    private void MakeClientOlder()
    {
        Debug.Log("Client is now older.");
    }

    private void TransformToMonkey()
    {
        Debug.Log("Client transformed into a monkey.");
    }

    private void MakeClientPrettier()
    {
        Debug.Log("Client is now prettier.");
    }
}