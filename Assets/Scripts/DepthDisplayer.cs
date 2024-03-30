using TMPro;
using UnityEngine;

public class DepthDisplayer : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private TextMeshProUGUI depthValue;


    private void Start()
    {
        SetDepth(submarineState.Depth);
        submarineState.OnDepthChange += SetDepth;
    }

    private void OnDestroy()
    {
        submarineState.OnDepthChange -= SetDepth;
    }

    private void SetDepth(int value)
    {
        depthValue.text = value.ToString();
    }
}