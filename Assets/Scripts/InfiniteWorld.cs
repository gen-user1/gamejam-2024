using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfiniteWorld : MonoBehaviour
{
    public GameObject sub;

    public GameObject bg;

    public List<GameObject> wallsR = new List<GameObject>();

    public List<GameObject> wallsL = new List<GameObject>();

    private GameObject currentWallL;

    private GameObject currentWallR;

    private int wallPointer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentWallL = wallsL[0];
        currentWallR = wallsR[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*
        sub.transform.position -= new Vector3(
            0,
            10 * Time.deltaTime,
            0
        );*/


        if (sub.transform.position.y < currentWallL.transform.position.y) {
            GameObject newWallL = GameObject.Instantiate(wallsL[0]);
            GameObject newWallR = GameObject.Instantiate(wallsR[0]);

            newWallL.transform.position = currentWallL.transform.position - new Vector3(0, 10, 0);
            newWallR.transform.position = currentWallR.transform.position - new Vector3(0, 10, 0);

            currentWallL = newWallL;
            currentWallR = newWallR;
        }    
    }
}
