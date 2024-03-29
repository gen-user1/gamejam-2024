using ScriptableObjects;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private ResourcesState resourcesState;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("resource"))
        {
            return;
        }

        var resource = other.gameObject.GetComponent<CollectableResource>();
        if (!resource)
        {
            return;
        }

        HandleResourceCollection(resource.type, resource.amount);
    }


    private void HandleResourceCollection(ResourceType type, int amount)
    {
        switch (type)
        {
            case ResourceType.Mineral:
                resourcesState.Minerals += amount;
                break;
            default:
                Debug.Log("Unknown resource type");
                break;
        }
    }
}