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
        
        //Depth damage logic here:
        if (y >= 0 || y < submarineState.SafeDepthLevel)
        {
            return;
        }

        var damage = (y-submarineState.SafeDepthLevel) - submarineState.Resistance;
        if (damage < 0)
        {
            damage = 0;
        }
        submarineState.Health -= (int)damage;
    }
}