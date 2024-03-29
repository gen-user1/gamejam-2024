using System.Collections.Generic;
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
        currentWallL = Instantiate(wallsL[0], wallsLContainer);
        currentWallR = Instantiate(wallsR[0], wallsRContainer);
    }

    void Update()
    {
        if (transform.position.y < currentWallL.transform.position.y)
        {
            var newWallL = Instantiate(wallsL[0], wallsLContainer);
            var newWallR = Instantiate(wallsR[0], wallsRContainer);

            newWallL.transform.position = currentWallL.transform.position - new Vector3(0, 10, 0);
            newWallR.transform.position = currentWallR.transform.position - new Vector3(0, 10, 0);

            currentWallL = newWallL;
            currentWallR = newWallR;
        }
    }
}