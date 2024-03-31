using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "SubmarineState", menuName = "ScriptableObjects/SubmarineState", order = 1)]
public class SubmarineState : ScriptableObject
{
    [SerializeField] private int maxHealth;
    public Action<int> OnMaxHealthChange;

    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            OnHealthChange?.Invoke(value);
        }
    }


    [SerializeField] private int health;
    public Action<int> OnHealthChange;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            OnHealthChange?.Invoke(value);
        }
    }

    [SerializeField] private int depth;

    public Action<int> OnDepthChange;

    public int Depth
    {
        get => depth;
        set
        {
            depth = value;
            OnDepthChange?.Invoke(value);
        }
    }

    [SerializeField] private int safeDepthLevel = -50;
    public Action<int> OnSafeDepthLevelChange;

    public int SafeDepthLevel
    {
        get => safeDepthLevel;
        set
        {
            safeDepthLevel = value;
            OnSafeDepthLevelChange?.Invoke(value);
        }
    }

    [SerializeField] private int resistance;
    public Action<int> OnResistanceChange;

    public int Resistance
    {
        get => resistance;
        set
        {
            resistance = value;
            OnResistanceChange?.Invoke(value);
        }
    }

    [SerializeField] private int minerals;
    public Action<int> OnMineralsChange;

    public int Minerals
    {
        get => minerals;
        set
        {
            minerals = value;
            OnMineralsChange?.Invoke(value);
        }
    }

    [SerializeField] private int minerals1;
    public Action<int> OnMinerals1Change;

    public int Minerals1
    {
        get => minerals1;
        set
        {
            minerals1 = value;
            OnMinerals1Change?.Invoke(value);
        }
    }
}