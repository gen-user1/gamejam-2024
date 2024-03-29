using System;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    [CreateAssetMenu(fileName = "ResourcesState", menuName = "ScriptableObjects/ResourcesState", order = 1)]
    public class ResourcesState : ScriptableObject
    {
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
    }
}