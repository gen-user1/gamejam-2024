using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineShop : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private Button fixButton;
    [SerializeField] private Button resistButton;
    [SerializeField] private int fixHealthIncrease = 30;

    private int FIX_PRICE = 3;
    private int RESISTANCE_PRICE = 1;

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
        fixButton.interactable = value >= FIX_PRICE;
    }
    
    private void HandleResistButtonState(int value)
    {
        resistButton.interactable = value >= RESISTANCE_PRICE;
    }

    public void FixSubmarine()
    {
        submarineState.Health += fixHealthIncrease;
        submarineState.Minerals -= FIX_PRICE;
    }

    public void IncreaseResistance()
    {
        submarineState.Resistance += 10;
        submarineState.Minerals1 -= RESISTANCE_PRICE;
    }
}