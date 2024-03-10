using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public Canvas uiCanvas;

    void Start()
    {
        // Attach the method to the button click event
        GetComponent<Button>().onClick.AddListener(CloseUI);
    }

    void CloseUI()
    {
        // Disable the UI canvas when the button is clicked
        uiCanvas.gameObject.SetActive(false);
  
    }





}
