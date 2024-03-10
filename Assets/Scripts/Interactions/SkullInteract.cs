using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkullInteract : MonoBehaviour
{
    public GameObject SkullShadow;

    public GameObject ObjectMusic;
    private AudioSource AudioSource;



    // Update is called once per frame

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectMusic = GameObject.FindWithTag("IntroMusic");
            AudioSource = ObjectMusic.GetComponent<AudioSource>();
            if(AudioSource.isPlaying)
                AudioSource.Pause();
            else 
                AudioSource.Play();



            //OpenPage.gameObject.SetActive(true);


            //Instantiate(OpenPage, new Vector3(0, 0, 0), Quaternion.identity);

            //Debug.Log("merge");

        }
    }

    private void OnMouseOver()
    {
        SkullShadow.SetActive(true);
    }
    private void OnMouseExit()
    {
        SkullShadow.SetActive(false);
    }


}
