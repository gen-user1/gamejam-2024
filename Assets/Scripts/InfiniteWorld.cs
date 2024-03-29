using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InfiniteWorld : MonoBehaviour
{
    [SerializeField] private Transform wallsLContainer;
    [SerializeField] private Transform wallsRContainer;

    public List<GameObject> wallsR = new();

    public List<GameObject> wallsL = new();

    private GameObject currentWallL;

    private GameObject currentWallR;

    private int wallPointer = 0;

    void Start()
    {
        wallPointer++;
        currentWallL = Instantiate(wallsL[wallPointer % wallsL.Count], wallsLContainer);
        currentWallR = Instantiate(wallsR[wallPointer % wallsR.Count], wallsRContainer);
    }

    void Update()
    {
        if (transform.position.y < currentWallL.transform.position.y)
        {
            wallPointer++;
            var newWallL = Instantiate(wallsL[wallPointer % wallsL.Count], wallsLContainer);
            var newWallR = Instantiate(wallsR[wallPointer % wallsR.Count], wallsRContainer);

            newWallL.transform.position = currentWallL.transform.position - new Vector3(0, 10, 0);
            newWallR.transform.position = currentWallR.transform.position - new Vector3(0, 10, 0);

            currentWallL = newWallL;
            currentWallR = newWallR;
        }
    }
}