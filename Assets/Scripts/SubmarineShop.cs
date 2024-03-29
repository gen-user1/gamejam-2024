using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineShop : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;

    
    
    [SerializeField] private Button fixButton;


    
    [SerializeField] private int fixHealthIncrease = 10;
    
    public void FixSubmarine()
    {
        submarineState.Health += fixHealthIncrease;
    }

    public void IncreaseResistance()
    {
        submarineState.Resistance += 1;
    }
}