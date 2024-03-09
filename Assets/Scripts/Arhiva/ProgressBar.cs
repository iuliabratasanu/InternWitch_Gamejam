using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;

    void Start()
    {

    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float fillAmmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmmount;
    }
}
