using System;
using UnityEngine;

[Serializable]
public enum ResourceType
{
    Mineral,
    Mineral1
}


public class CollectableResource : MonoBehaviour
{
    [SerializeField] public ResourceType type;
    [SerializeField] public int amount = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("submarine"))
        {
            Destroy(gameObject);
        }
    }
}