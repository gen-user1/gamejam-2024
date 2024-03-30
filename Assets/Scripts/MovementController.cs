using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;
    [SerializeField] private float maxHeight = -1f;

    private Rigidbody _rb;

    private bool _isRotatingLeft;
    private bool _isRotatingRight;


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
        HandeCameraMovement(currPosition);
        RotateSubmarine(horizontalAxis);
    }


    private void HandeCameraMovement(Vector3 pos)
    {
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position = new Vector3(pos.x, pos.y, cameraPosition.z);
    }


    private void RotateSubmarine(float horizontalAxis)
    {
        var submarineRotationVelocity = new Vector3(0, 0, 0);
        if (horizontalAxis > 0)
        {
            _isRotatingRight = true;
            _isRotatingLeft = false;
        }

        if (_rb.rotation.y < 0.75 && _isRotatingRight)
        {
            submarineRotationVelocity = new Vector3(0, 100, 0);
        }
        else
        {
            _isRotatingRight = false;
        }


        if (horizontalAxis < 0)
        {
            _isRotatingRight = false;
            _isRotatingLeft = true;
        }

        if (_rb.rotation.y > -0.75 && _isRotatingLeft)
        {
            submarineRotationVelocity = new Vector3(0, -100, 0);
        }
        else
        {
            _isRotatingLeft = false;
        }


        Quaternion deltaRotation = Quaternion.Euler(submarineRotationVelocity * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }
}