using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInputHandler : MonoBehaviour
{
    public InputField nameInputField;

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    public void OnSaveButtonClick()
    {
        SavePlayerName();
        SceneManager.LoadScene(2);
    }
}
