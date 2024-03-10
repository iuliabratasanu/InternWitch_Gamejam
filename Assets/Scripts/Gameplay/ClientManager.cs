using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ClientManager : MonoBehaviour
{
    [SerializeField]
    [Serializable]
    public struct Order
    {
        public int spriteIndex;
        public string requestName;
        public PotionType desiredPotion;
    }

    public enum PotionType { purplePotion, greenPotion, orangePotion, errorPotion }

    public bool orderSatisfied = false;
    [SerializeField] public Order currentOrder;
    [SerializeField] public Order[] possibleOrders = new Order[3];
    public Sprite[] spriteList;

    private void Start()
    {
        possibleOrders = new Order[possibleOrders.Length];

        possibleOrders[0] = new Order();
        possibleOrders[0].spriteIndex = 0;
        possibleOrders[0].desiredPotion = PotionType.purplePotion;
        possibleOrders[0].requestName = "Help me hide. Fast.";

        possibleOrders[1] = new Order();
        possibleOrders[1].spriteIndex = 0;
        possibleOrders[1].desiredPotion = PotionType.orangePotion;
        possibleOrders[1].requestName = "Make me prettier, please!";

        possibleOrders[2] = new Order();
        possibleOrders[2].spriteIndex = 0;
        possibleOrders[2].desiredPotion = PotionType.greenPotion;
        possibleOrders[2].requestName = "Time travel would be nice.";
    }

    public void ReactToPotion()
    {
        if (currentOrder.desiredPotion == PotionType.purplePotion)
        {
            TransformToMonkey();
        }
        if (currentOrder.desiredPotion == PotionType.greenPotion)
        {
            MakeClientOlder();
        }
        if (currentOrder.desiredPotion == PotionType.orangePotion)
        {
            
            MakeClientPrettier();
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

    public void GetRandomOrder()
    {
        currentOrder = possibleOrders[UnityEngine.Random.Range(0, possibleOrders.Length)];
    }
}