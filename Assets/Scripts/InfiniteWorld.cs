using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWorld : MonoBehaviour
{
    public GameObject sub;

    public GameObject wallR;

    public GameObject wallL;

    public GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        
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


        if (sub.transform.position.y < wallL.transform.position.y - 10) {
            wallR.transform.position = wallL.transform.position - new Vector3(0, 10, 0);
        }
    }
}
