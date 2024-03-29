using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResistanceDisplay : MonoBehaviour
    {
        [SerializeField] private SubmarineState submarineState;
        [SerializeField] private TextMeshProUGUI textValue;

        private void Start()
        {
            SetResistance(submarineState.Resistance);
            submarineState.OnResistanceChange += SetResistance;
        }

        private void OnDestroy()
        {
            submarineState.OnResistanceChange -= SetResistance;
        }

        private void SetResistance(int value)
        {
            textValue.text = value.ToString();
        }
    }
}