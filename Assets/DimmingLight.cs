using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmingLight : MonoBehaviour
{
    public GameObject sub;

    public GameObject camera;

    private Light light;

    private Camera cam;

    private Color originalColor = new Color(0.1921f, 0.3019f, 0.4745f);

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        cam = camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = 1 - (Math.Abs(sub.transform.position.y) / 20);
        var colorStep = Math.Abs(sub.transform.position.y) / 20;
        cam.backgroundColor = originalColor - new Color(0.1f * colorStep, 0.1f * colorStep, 0.1f * colorStep);
        Debug.Log("Intencity " + light.intensity);
        Debug.Log("Sub transform " + sub.transform.position.y);
    }
}
