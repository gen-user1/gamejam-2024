using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(_camera.transform.forward);
    }
}