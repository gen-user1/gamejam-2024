using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var vertialAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");

        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position = new Vector3(cameraPosition.x, rigidbodyComponent.position.y, cameraPosition.z);
        RotateSubmarine(horizontalAxis);
    }
    
    private void FixedUpdate()
    {
        var vertialAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");
        rigidbodyComponent.velocity = new Vector3(horizontalAxis * speed, vertialAxis * speed, 0);
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

        Quaternion deltaRotation = Quaternion.Euler(submarineRotationVelocity * Time.fixedDeltaTime);
        rigidbodyComponent.MoveRotation(rigidbodyComponent.rotation * deltaRotation);
    }
}