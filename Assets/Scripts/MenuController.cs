using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text modeLabel;

    private void Start()
    {
        modeLabel = GameObject.Find("Mode Label").GetComponent<Text>();
        UpdateButtonText();
    }
    public void ToggleMode()
    {
        var value = PlayerPrefs.GetInt("modeMultiplier", 1);
        if (value == 1)
        {   
            PlayerPrefs.SetInt("modeMultiplier", 2);
        }
        else
        {
            PlayerPrefs.SetInt("modeMultiplier", 1);
        }
        UpdateButtonText();
    }
    
    void UpdateButtonText()
    {
        var value = PlayerPrefs.GetInt("modeMultiplier", 1);
        if (value == 1)
        {
            modeLabel.text = "Mode: HARD";
        } else {
            modeLabel.text = "Mode: EASY";
        }

    }
}
