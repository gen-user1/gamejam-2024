using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rock1;
    [SerializeField] private GameObject rock2;
    [SerializeField] private GameObject rock3;

    private float lastTimeSpawn = 0;
    private List<GameObject> rocks = new();
    private int spawnTimeSeconds = 5;
    // Start is called before the first frame update
    void Start()
    {
       rocks.Add(rock1);
       rocks.Add(rock2);
       rocks.Add(rock3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeSpawn >= spawnTimeSeconds) 
        {
            SpawnNew();
        }
    }

    private void SpawnNew() 
    {
        int index = Random.Range(0, rocks.Count);
        int xPos = Random.Range(0, 10);
        Instantiate(rocks[index], new Vector3(xPos, 10, 0), Quaternion.identity);
        lastTimeSpawn = Time.time;
    }
}
