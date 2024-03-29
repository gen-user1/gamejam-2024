using System;
using UnityEngine;

namespace ScriptableObjects
{
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
        
        [SerializeField] private int depth = 100;

        public Action<int> onDepthlChange;

        public int Depth
        {
            get => depth;
            set
            {
                depth = value;
                onDepthlChange?.Invoke(value)
            }
        }

        [SerializeField] private int safeDepthLevel = 100;

        public Action<int> onSafeDepthLevelChange;

        public int SafeDepthLevel
        {
            get => safeDepthLevel;
            set
            {
                safeDepthLevel = value;
                onSafeDepthLevelChange?.Invoke(value)
            }
        }
        
        [SerializeField] private int resistance = 100;

        public Action<int> resistance;

        public int Resistance
        {
            get => resistance;
            set
            {
                resistance = value;
                resistance?.Invoke(value)
            }
        }
    }
}