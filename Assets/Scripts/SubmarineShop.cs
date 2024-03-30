using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineShop : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private Button fixButton;
    [SerializeField] private Button resistButton;
    [SerializeField] private int fixHealthIncrease = 10;

    private void Start()
    {
        HandleFixButtonState(submarineState.Minerals);
        submarineState.OnMineralsChange += HandleFixButtonState;
        
        HandleResistButtonState(submarineState.Minerals1);
        submarineState.OnMinerals1Change += HandleResistButtonState;
    }

    private void OnDestroy()
    {
        submarineState.OnMineralsChange -= HandleFixButtonState;
        submarineState.OnMinerals1Change -= HandleResistButtonState;
    }

    private void HandleFixButtonState(int value)
    {
        fixButton.interactable = value >= 5;
    }
    
    private void HandleResistButtonState(int value)
    {
        resistButton.interactable = value >= 5;
    }

    public void FixSubmarine()
    {
        submarineState.Health += fixHealthIncrease;
    }

    public void IncreaseResistance()
    {
        submarineState.Resistance += 1;
    }
}