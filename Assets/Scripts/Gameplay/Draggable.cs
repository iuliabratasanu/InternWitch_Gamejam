using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 mousePositionOffset;
    private Vector3 initialPosition;
    private bool potionAdded = false;

    // Add a reference to the GameManager or another manager script to handle game logic
    public GameManager gameManager;

    private void Start()
    {
        // Initialize the initial position
        initialPosition = transform.position;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        // Update the offset when the potion is picked up
        mousePositionOffset = transform.position - GetMouseWorldPosition();
        potionAdded = false; // Reset the flag when the potion is picked up

        // Check if the player clicked the story page
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Page"))
            {
                //Vlad -> sa se deschida un UI cu o poza si sa aibe in colt dreapta sus o posibilitate sa se inchida
            }

            //if (collider.CompareTag("Book"))
           // {
            //    //Vlad -> sa se deschida un UI cu o poza si sa aibe in colt dreapta sus o posibilitate sa se inchida
           // }
        }
    }

    private void OnMouseDrag()
        {
            // Update the position to follow the cursor with the initial offset
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }

        private void OnMouseUp() {
            {
                // Check if the potion is over the pot
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Pot"))
                    {
                        // Potion is over the pot
                        potionAdded = true;

                        // Retrieve the potion's tag and notify the GameManager
                        if (gameObject.CompareTag("B") || gameObject.CompareTag("Y") || gameObject.CompareTag("R"))
                        {
                            // Retrieve the potion's tag
                            string potionTag = gameObject.tag;

                            // Notify the GameManager about the added potion
                            if (gameManager != null)
                            {
                                gameManager.AddPotion(potionTag);
                            }

                            // Reset its position if the potion was added
                            transform.position = initialPosition;
                        }

                        break; // Exit the loop since we found the pot
                    }
                }

                // If the potion was not added, reset its position
                if (!potionAdded)
                {
                    transform.position = initialPosition;
                }
            }

        }
    }