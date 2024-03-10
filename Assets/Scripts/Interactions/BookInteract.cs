using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BookInteract : MonoBehaviour
{
    public int pagesOpened = 0;
    public GameObject BookShadow;
    public GameObject OpenBook;



    // Update is called once per frame

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            OpenBook.gameObject.SetActive(true);


                Instantiate(OpenBook, new Vector3(0, 0, 0), Quaternion.identity);

                //Debug.Log("merge");

        }
    }

    private void OnMouseOver()
    {
        BookShadow.SetActive(true);
    }
    private void OnMouseExit()
    {
        BookShadow.SetActive(false);
    }


}
