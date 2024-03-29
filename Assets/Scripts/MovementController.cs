using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;
    private bool downWasPressed;
    private bool upWasPressed;
    private bool leftWasPressed;
    private bool rightWasPressed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position = new Vector3(cameraPosition.x, rigidbodyComponent.position.y, cameraPosition.z);
    }
    
    private void FixedUpdate()
    {
        var vertialAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");
        rigidbodyComponent.velocity = new Vector3(horizontalAxis * speed, vertialAxis * speed, 0);
    }
}