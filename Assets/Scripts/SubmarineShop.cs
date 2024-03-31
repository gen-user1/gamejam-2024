using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineShop : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private Button fixButton;
    [SerializeField] private Button resistButton;
    [SerializeField] private int fixHealthIncrease = 30;
    [SerializeField] private int resistanceIncrease = 10;

    [SerializeField] private int fixPrice = 3;
    [SerializeField] private int resistancePrice = 1;

    [SerializeField] private TextMeshProUGUI fixCostText;
    [SerializeField] private TextMeshProUGUI resistanceCostText;

    private int modeMupliplier;

    private void Start()
    {
        fixCostText.text = fixPrice.ToString();
        resistanceCostText.text = resistancePrice.ToString();

        HandleFixButtonState(submarineState.Minerals);
        submarineState.OnMineralsChange += HandleFixButtonState;

        HandleResistButtonState(submarineState.Minerals1);
        submarineState.OnMinerals1Change += HandleResistButtonState;

        modeMupliplier = PlayerPrefs.GetInt("modeMultiplier", 1);
    }

    private void OnDestroy()
    {
        submarineState.OnMineralsChange -= HandleFixButtonState;
        submarineState.OnMinerals1Change -= HandleResistButtonState;
    }

    private void HandleFixButtonState(int value)
    {
        fixButton.interactable = value >= fixPrice;
    }

    private void HandleResistButtonState(int value)
    {
        resistButton.interactable = value >= resistancePrice;
    }

    public void FixSubmarine()
    {
        if (submarineState.Minerals < fixPrice)
        {
            return;
        }
        submarineState.Health += fixHealthIncrease * modeMupliplier;
        submarineState.Minerals -= fixPrice;
    }

    public void IncreaseResistance()
    {
        if (submarineState.Minerals1 < resistancePrice)
        {
            return;
        }
        submarineState.Resistance += resistanceIncrease * modeMupliplier;
        submarineState.Minerals1 -= resistancePrice;

    }
}