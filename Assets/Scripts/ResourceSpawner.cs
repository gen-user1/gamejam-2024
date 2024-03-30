using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ResourceSpawner : MonoBehaviour
{
    private readonly Random _random = new();
    [SerializeField] private List<CollectableResource> resources;

    private void Start()
    {
        var resource = ChooseRandomResource();
        resource.gameObject.SetActive(true);
    }

    private CollectableResource ChooseRandomResource()
    {
        var weights = new List<double>();
        double totalWeight = 0;
        for (var i = resources.Count - 1; i >= 0; i--)
        {
            double weight = i + 1;
            weights.Add(weight);
            totalWeight += weight;
        }

        var randomNumber = _random.NextDouble() * totalWeight;
        double cumulativeWeight = 0;

        for (var i = 0; i < resources.Count; i++)
        {
            cumulativeWeight += weights[i];
            if (randomNumber < cumulativeWeight)
            {
                return resources[i];
            }
        }

        return resources.Count > 0 ? resources[0] : null;
    }
}