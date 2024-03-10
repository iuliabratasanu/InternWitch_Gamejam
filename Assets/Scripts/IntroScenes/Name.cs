using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    private void Awake()
    {
        display_player_name.text = IntroductionScript.scene1.player_name;

    }
}
