using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ClientReaction clientReaction;
    private List<string> addedPotions = new List<string>();
    private int experience = 0;
    private int level = 1;

    // Define the fixed set of initial orders for the first level
    private string[] currentLevelOrders = { "green", "purple", "orange" };

    private void Start()
    {
        NextClient();
    }

    private void NextClient()
    {
        string clientInitialOrder = GetRandomInitialOrder();
        if (clientReaction != null)
        {
            clientReaction.SetInitialOrder(clientInitialOrder);
        }
    }

    public void AddPotion(string potionTag)
    {
        addedPotions.Add(potionTag);

        if (addedPotions.Count >= 2)
        {
            MixPotions();
        }
    }

    private void MixPotions()
    {
        string lastPotion = addedPotions[addedPotions.Count - 1];
        string secondToLastPotion = addedPotions[addedPotions.Count - 2];

        string mixedPotion = Mix(lastPotion, secondToLastPotion);
        ApplyPotionEffects(mixedPotion);

        addedPotions.Clear();

        experience += 10;

        if (experience >= 20 && level == 1)
        {
            level = 2;
            Debug.Log("Level 2 unlocked!");
            // Add logic to unlock new features or potions for level 2
        }
        else if (experience >= 40 && level == 2)
        {
            level = 3;
            Debug.Log("Level 3 unlocked! Ending scene triggered.");
            // Add logic to transition to the ending scene or the next scene for level 3
        }

        NextClient();
    }

    private string Mix(string potion1, string potion2)
    {
        // Add your logic for mixing potions and determining the result
        // For simplicity, returning a combined string, modify this based on your game logic
        return potion1 + potion2;
    }

    private void ApplyPotionEffects(string mixedPotion)
    {
        Debug.Log("Mixed Potion: " + mixedPotion);

        if (clientReaction != null)
        {
            clientReaction.ReactToPotion(mixedPotion);
        }
    }

    private string GetRandomInitialOrder()
    {
        // Return a random initial order from the fixed set for the first level
        int randomIndex = Random.Range(0, currentLevelOrders.Length);
        return currentLevelOrders[randomIndex];
    }
}
