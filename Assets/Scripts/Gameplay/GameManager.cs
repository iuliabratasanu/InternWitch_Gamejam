using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public ClientManager clientManager;
    private List<string> addedPotions = new List<string>();

    public TMP_Text experienceText;
    private int experience = 0;
    private int level = 1;

    // Define the fixed set of initial orders for the first level
    private string[] currentLevelOrders = { "orange order yellow red", "green order bnlue yellow ", "purple order red blue" };

    private void Start()
    {
        NextClient();
        UpdateExperienceText(); // Update the TMP text when the game starts
    }

    private void Update()
    {

    }
    private void NextClient()
    {
        clientManager.GetRandomOrder();
    }

    public void AddPotion(string potionTag)
    {

        addedPotions.Add(potionTag);

        if (addedPotions.Count >= 2)
        {
            MixPotions();
        }
    }

    public ClientManager.PotionType StringToPotionType(string tag)
    {
        if (tag == "RB" || tag == "BR")
            return ClientManager.PotionType.purplePotion;

        if (tag == "RY" || tag == "YR")
            return ClientManager.PotionType.orangePotion;

        if (tag == "YB" || tag == "BY")
            return ClientManager.PotionType.greenPotion;
        return ClientManager.PotionType.errorPotion;
    }

    public void CheckIfMixedPotionIsRequested(string mixedPotion)
    {
        if (StringToPotionType(mixedPotion) == clientManager.currentOrder.desiredPotion)
        {
            Debug.Log("bn");
            ApplyPotionEffects(mixedPotion);
            experience += 10;
            UpdateExperienceText(); // Update the TMP text when experience changes
        }
        else
        {
            Debug.Log("nuibn");
        }
    }

    private void MixPotions()
    {
        string first = addedPotions[addedPotions.Count - 1];
        string second = addedPotions[addedPotions.Count - 2];

        string mixedPotion = Mix(first, second);

        CheckIfMixedPotionIsRequested(mixedPotion);

        addedPotions.Clear();

        if (experience >= 50 && level == 1)
        {
            level = 2;
            Debug.Log("Level 2 unlocked!");
            // Add logic to unlock new features or potions for level 2
        }
        else if (experience >= 100 && level == 2)
        {
            level = 3;
            Debug.Log("Level 3 unlocked! Ending scene triggered.");
            SceneManager.LoadScene(3);
            // Add logic to transition to the ending scene or the next scene for level 3
        }

        NextClient();
    }

    private string Mix(string potion1, string potion2)
    {
        // Add your logic for mixing potions and determining the result
        // For simplicity, returning a combined string, modify this based on your game logic

        Debug.Log("Mixed Potion: " + potion1 + potion2);

        return potion1 + potion2;
    }

    private void ApplyPotionEffects(string mixedPotion)
    {

        clientManager.ReactToPotion();


    }

    private void UpdateExperienceText()
    {
        // Update the TMP text with the current experience value
        experienceText.text = "Experience: " + experience + "/100";
    }
}
