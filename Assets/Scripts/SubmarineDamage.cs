using ScriptableObjects;
using UnityEngine;

public class SubmarineDamage : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;


    private void Start()
    {
        InvokeRepeating(nameof(ProcessDamage), 0, 1.0f);
    }

    private void ProcessDamage()
    {
        var y = transform.position.y;

        if (y >= 0)
        {
            return;
        }

        var damage = -y;
        submarineState.Health -= (int)damage;
    }
}