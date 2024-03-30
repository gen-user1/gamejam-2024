using System;
using UnityEngine;

public class DimmingLight : MonoBehaviour
{
    public GameObject sub;

    private new Light light;

    private new Camera camera;

    private Color originalColor = new Color(0.1921f, 0.3019f, 0.4745f);

    private void Start()
    {
        light = GetComponent<Light>();
        camera = Camera.main;
    }

    private void Update()
    {
        var position = sub.transform.position;
        light.intensity = 1 - (Math.Abs(position.y) / 20);
        var colorStep = Math.Abs(position.y) / 20;
        camera.backgroundColor = originalColor - new Color(0.1f * colorStep, 0.1f * colorStep, 0.1f * colorStep);
        Debug.Log("Intencity " + light.intensity);
        Debug.Log("Sub transform " + position.y);
    }
}