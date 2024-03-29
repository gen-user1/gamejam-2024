using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineShop : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private int fixHealthIncrease = 10;
    [SerializeField] private Button fixButton;


    public void FixSubmarine()
    {
        submarineState.Health += fixHealthIncrease;
    }
}