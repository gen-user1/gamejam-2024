using System;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    [CreateAssetMenu(fileName = "Integer", menuName = "ScriptableObjects/Integer", order = 1)]
    public class IntegerScriptableObject : ScriptableObject
    {
        private int val;

        public Action<int> OnChange;

        public int Value
        {
            get => val;
            set
            {
                val = value;
                OnChange?.Invoke(value);
            }
        }
    }
}