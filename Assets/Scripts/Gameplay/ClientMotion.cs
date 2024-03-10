using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;



public class ClientMotion : MonoBehaviour
{
    ClientManager clientManager;
    public GameObject MyClient;
    public float speed = 2;
    public int phase = 0;

    // Reference to the TextMeshPro component
    public GameObject orderDisplayPrefab;
    private GameObject currentOrderDisplay;
    public int lastKnownNumberOfOrders;


    void Start()
    {
        clientManager = FindObjectOfType<ClientManager>(); // Adjust as needed

        // Instantiate the order display prefab
        currentOrderDisplay = Instantiate(orderDisplayPrefab);

        // Parent the OrderBox to MyClient
        currentOrderDisplay.transform.SetParent(MyClient.transform);

        // Set the local position of the OrderBox after parenting
        currentOrderDisplay.transform.localPosition = new Vector3(-7.46999979f, 2.98000026f, 0);

        // Set the position of the TextMeshPro component within OrderBox
        TextMeshProUGUI orderText = currentOrderDisplay.GetComponentInChildren<TextMeshProUGUI>();
        orderText.rectTransform.localPosition = new Vector3(-678.1f, 123f, 0);

        currentOrderDisplay.SetActive(false);
    }




    void Update()
    {
        // TO DO : cand phase e -1 sau cv de genul, trb sa sa updatateze orderul clientului curent


        // phase 0: Clientul intra in magazin si se opreste ca sa comande

        if (phase == 0 && MyClient.transform.position.x < 1.49)
        {
            MyClient.transform.position += transform.right * speed * Time.deltaTime;
        }



        if (phase == 0 && MyClient.transform.position.x > 1.49)
        {
            phase = 1;

        }



        //phase 1: Clientul comanda
        if (phase == 1)
        {
            // TO DO:
            //
            // if (! "ClientOrderIsComplete")  *sau un nume similar* = trb facuta conexiunea cu o functie de genul din scriptul ClientManager
            //
            // { apelez "functia care face sa apara prefabul cu dialog box(order) si actualizeaza textul sa coincida cu titlul comenzii }
            //
            //else { adaugam efectele de la potiune, se adauga experienta si sfx + (phase == 2) -> trb facut si schimbarea de asset-uri in functia din celalalt script - acolo unde asset ul trb sa primeasca fundita/barba/masca }
            //



            if (lastKnownNumberOfOrders == clientManager.nrOfSuccesfulOrders)
            {
                // Display the order text above the client's head
                DisplayOrderText(clientManager.currentOrder.requestName);
            }
            else
            {
                lastKnownNumberOfOrders = clientManager.nrOfSuccesfulOrders;
                clientManager.GetRandomOrder();
                // Call a function to hide the order display.
                HideOrderDisplay();
                phase = 3;
            }



        }


        // phase 2: Clientul se indreapta spre iesirea din magazin (SI TRANSFORMAREA (fundita, barba,masca) CARE I S-A ADAUGAT DEVINE CHILD IN IERARHIE ADICA IL URMARESTE PE CLIENT PANA IESE DIN MAGAZIN // si apoi se teleporteaza la pozitia de spawn
        if (phase == 2 && MyClient.transform.position.x < 18.2)
        {
            MyClient.transform.position += transform.right * speed * Time.deltaTime;
        }
        if (phase == 2 && MyClient.transform.position.x > 18.2)
        {
            MyClient.transform.position = new Vector3(-5.5f, MyClient.transform.position.y, MyClient.transform.position.z);
            phase = 0;

            //TO DO: trb adaugat o functie Invoke care sa astepte 5sec sau cv de genul, apoi phase == 0;

        }

        // TO DO: sistem de experienta sau cv de genu,

        // Function to display the order text above the client's head
        void DisplayOrderText(string orderTextContent)
        {

            TextMeshProUGUI orderText = currentOrderDisplay.GetComponentInChildren<TextMeshProUGUI>();

            orderText.text = orderTextContent;
            currentOrderDisplay.SetActive(true);
        }

        // Function to hide the order display
        void HideOrderDisplay()
        {
            currentOrderDisplay.SetActive(false);
        }

    }
}

