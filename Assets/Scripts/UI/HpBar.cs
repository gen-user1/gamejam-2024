using ScriptableObjects;
using UnityEngine;

namespace UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private SubmarineState submarineState;
        [SerializeField] private RectTransform bar;


        private void Start()
        {
            SetBarWidth(submarineState.Health);
            submarineState.OnHealthChange += SetBarWidth;
        }

        private void OnDestroy()
        {
            submarineState.OnHealthChange -= SetBarWidth;
        }

        private void SetBarWidth(int value)
        {
            var prevScale = bar.localScale;
            var newXScale = (float)value / submarineState.MaxHealth;
            if (newXScale < 0)
            {
                newXScale = 0;
            }

            bar.localScale = new Vector3(newXScale, prevScale.y, prevScale.z);
        }
    }
}