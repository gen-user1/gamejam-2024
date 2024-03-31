using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI modeLabel;

    private void Start()
    {
        UpdateButtonText();
    }

    public void ToggleMode()
    {
        var value = PlayerPrefs.GetInt("modeMultiplier", 1);
        PlayerPrefs.SetInt("modeMultiplier", value == 1 ? 2 : 1);
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        var value = PlayerPrefs.GetInt("modeMultiplier", 1);
        modeLabel.text = value == 1 ? "Mode: HARD" : "Mode: EASY";
    }
}