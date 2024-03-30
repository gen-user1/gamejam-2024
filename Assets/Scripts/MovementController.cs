using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;
    [SerializeField] private float maxHeight = -1f;

    private Rigidbody _rb;

    private bool isRotatingLeft;
    private bool isRotatingRight;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var verticalAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");
        var currPosition = transform.position;
        if (currPosition.y > maxHeight)
        {
            transform.position = new Vector3(currPosition.x, maxHeight, currPosition.z);
        }

        _rb.AddForce(Vector3.up * (verticalAxis * speed));
        _rb.AddForce(Vector3.right * (horizontalAxis * speed));
        HandeCameraMovement(currPosition.y);
        RotateSubmarine(horizontalAxis);
    }


    private void HandeCameraMovement(float y)
    {
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position = new Vector3(cameraPosition.x, y, cameraPosition.z);
    }


    private void RotateSubmarine(float horizontalAxis)
    {
        var submarineRotationVelocity = new Vector3(0, 0, 0);
        if (horizontalAxis > 0)
        {
            isRotatingRight = true;
            isRotatingLeft = false;
        }

        if (_rb.rotation.y < 0.75 && isRotatingRight)
        {
            submarineRotationVelocity = new Vector3(0, 100, 0);
        }
        else
        {
            isRotatingRight = false;
        }


        if (horizontalAxis < 0)
        {
            isRotatingRight = false;
            isRotatingLeft = true;
        }

        if (_rb.rotation.y > -0.75 && isRotatingLeft)
        {
            submarineRotationVelocity = new Vector3(0, -100, 0);
        }
        else
        {
            isRotatingLeft = false;
        }


        Quaternion deltaRotation = Quaternion.Euler(submarineRotationVelocity * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }
}