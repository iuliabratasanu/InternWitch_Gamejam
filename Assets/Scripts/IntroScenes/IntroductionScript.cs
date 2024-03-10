using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroductionScript : MonoBehaviour
{
    public static IntroductionScript scene1;
    public TMP_InputField inputField;

    public string player_name;

    private void Awake()
    {
        if (scene1 == null)
        {
            scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Continue()
    {
        player_name = inputField.text;

        SceneManager.LoadScene(3);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
