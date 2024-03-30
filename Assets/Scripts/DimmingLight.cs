using System;
using UnityEngine;

public class DimmingLight : MonoBehaviour
{
    public GameObject sub;

    private Light _light;

    private Camera _camera;

    private Color originalColor = new(0.1921f, 0.3019f, 0.4745f);

    private void Start()
    {
        _light = GetComponent<Light>();
        _camera = Camera.main;
    }

    private void Update()
    {
        var position = sub.transform.position;
        _light.intensity = 1 - (Math.Abs(position.y) / 20);
        var colorStep = Math.Abs(position.y) / 20;
        _camera.backgroundColor = originalColor - new Color(0.1f * colorStep, 0.1f * colorStep, 0.1f * colorStep);
    }
}