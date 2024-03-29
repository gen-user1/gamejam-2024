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
    }
}