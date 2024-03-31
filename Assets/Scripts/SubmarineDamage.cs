using UnityEngine;
using System;

public class SubmarineDamage : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    
    private FlashDamageIndicator flashDamageIndicator;

    private void Start()
    {
        InvokeRepeating(nameof(ProcessDamage), 0, 1.0f);
        submarineState.OnHealthChange += HandleDeath;
        flashDamageIndicator = GetComponent<FlashDamageIndicator>();
    }

    private void OnDestroy()
    {
        submarineState.OnHealthChange -= HandleDeath;
    }

    private void ProcessDamage()
    {
        var y = transform.position.y;

        //Depth damage logic here:
        if (y >= 0 || y > submarineState.SafeDepthLevel)
        {
            return;
        }



        var damage = (Math.Abs(y) - submarineState.SafeDepthLevel) - submarineState.Resistance;
        if (damage > 0)
        {
            flashDamageIndicator.Flash();
            submarineState.Health -= (int)damage;
        } 
    }

    private void HandleDeath(int health)
    {
        if (health <= 0)
        {
            SceneSwitcher.GameOver();
        }
    }
}