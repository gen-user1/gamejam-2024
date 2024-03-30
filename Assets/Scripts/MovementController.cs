using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;
    
    private Rigidbody rigidbodyComponent;


    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position = new Vector3(cameraPosition.x, rigidbodyComponent.position.y, cameraPosition.z);
        RotateSubmarine(horizontalAxis);

        if (transform.position.y > 0.4F) {
            transform.position = new Vector3(transform.position.x, 0.4F, 0);
        }
    }

    private void FixedUpdate()
    {
        var verticalAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");
        rigidbodyComponent.AddForce(Vector3.up * (verticalAxis * speed));
        rigidbodyComponent.AddForce(Vector3.right * (horizontalAxis * speed));
    }

    private void RotateSubmarine(float horizontalAxis)
    {
        Vector3 submarineRotationVelocity = new Vector3(0, 0, 0);
        if (horizontalAxis > 0 && rigidbodyComponent.rotation.y < 0.8)
        {
            submarineRotationVelocity = new Vector3(0, 100, 0);
        }

        if (horizontalAxis < 0 && rigidbodyComponent.rotation.y > -0.8)
        {
            submarineRotationVelocity = new Vector3(0, -100, 0);
        }

        Quaternion deltaRotation = Quaternion.Euler(submarineRotationVelocity * Time.deltaTime);
        rigidbodyComponent.MoveRotation(rigidbodyComponent.rotation * deltaRotation);
    }
}