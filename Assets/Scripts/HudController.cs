using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private RectTransform bar;
    [SerializeField] private TextMeshProUGUI resistanceValue;
    [SerializeField] private TextMeshProUGUI mineralsValue;
    [SerializeField] private TextMeshProUGUI minerals1Value;

    [SerializeField] private GameObject tutorial;

    private void Start()
    {
        SetHpBarWidth(submarineState.Health);
        submarineState.OnHealthChange += SetHpBarWidth;

        SetResistance(submarineState.Resistance);
        submarineState.OnResistanceChange += SetResistance;

        SetMinerals(submarineState.Minerals);
        submarineState.OnMineralsChange += SetMinerals;

        SetMinerals(submarineState.Minerals1);
        submarineState.OnMinerals1Change += SetMinerals1;
        submarineState.OnDepthChange += HandleDepthChange;
    }

    private void OnDestroy()
    {
        submarineState.OnHealthChange -= SetHpBarWidth;
        submarineState.OnResistanceChange -= SetResistance;
        submarineState.OnMineralsChange -= SetMinerals;
        submarineState.OnMinerals1Change -= SetMinerals1;
        submarineState.OnDepthChange -= HandleDepthChange;
    }

    private void SetHpBarWidth(int value)
    {
        var prevScale = bar.localScale;
        var newXScale = (float)value / submarineState.MaxHealth;
        if (newXScale < 0)
        {
            newXScale = 0;
        }

        bar.localScale = new Vector3(newXScale, prevScale.y, prevScale.z);
    }

    private void HandleDepthChange(int value)
    {
        tutorial.SetActive(value < 10);
    }

    private void SetResistance(int value)
    {
        resistanceValue.text = value.ToString();
    }

    private void SetMinerals(int value)
    {
        mineralsValue.text = value.ToString();
    }

    private void SetMinerals1(int value)
    {
        minerals1Value.text = value.ToString();
    }
}