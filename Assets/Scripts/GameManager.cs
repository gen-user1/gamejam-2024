using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;


    [SerializeField] private int defaultMaxHp;
    [SerializeField] private int defaultHp;
    [SerializeField] private int defaultResistance;
    [SerializeField] private int defaultMinerals;

    void Start()
    {
        submarineState.MaxHealth = defaultMaxHp;
        submarineState.Health = defaultHp;
        submarineState.Resistance = defaultResistance;
        submarineState.Minerals = defaultMinerals;
    }
}