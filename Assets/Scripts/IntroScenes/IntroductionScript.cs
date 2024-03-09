using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScript : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
