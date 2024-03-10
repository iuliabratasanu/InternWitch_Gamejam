using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StoryPage : MonoBehaviour
{
    public int pagesOpened = 0;
    public GameObject PageShadow;
    public GameObject OpenPage;



    // Update is called once per frame

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            OpenPage.gameObject.SetActive(true);


                Instantiate(OpenPage, new Vector3(0, 0, 0), Quaternion.identity);

                //Debug.Log("merge");

        }
    }

    private void OnMouseOver()
    {
        PageShadow.SetActive(true);
    }
    private void OnMouseExit()
    {
        PageShadow.SetActive(false);
    }


}
