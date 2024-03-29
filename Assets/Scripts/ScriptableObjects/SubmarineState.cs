using System;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    [CreateAssetMenu(fileName = "SubmarineState", menuName = "ScriptableObjects/SubmarineState", order = 1)]
    public class SubmarineState : ScriptableObject
    {
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