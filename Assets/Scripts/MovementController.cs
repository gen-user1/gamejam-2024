using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private GameObject canvas;
    [SerializeField] private new Camera camera;
    [SerializeField] private float speed = 3;
    [SerializeField] private float maxHeight = -1f;

    public GameObject seafloor;

    private SubmarineShop submarineShop;

    private Rigidbody _rb;

    private bool _isRotatingLeft;
    private bool _isRotatingRight;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        submarineShop = canvas.GetComponent<SubmarineShop>();
    }

    private void Update() {
        var fixButton = Input.GetKeyUp(KeyCode.F);
        var resistButton = Input.GetKeyUp(KeyCode.R);
        
        if (fixButton) {
            submarineShop.FixSubmarine();
        }
        if (resistButton) {
            submarineShop.IncreaseResistance();
        }
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

        submarineState.Depth = -(int)currPosition.y;

        if (_rb.position.y - seafloor.transform.position.y < 7)
        {
            SceneSwitcher.GameFinished();
        }
    }


    private void HandeCameraMovement(Vector3 pos)
    {
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;
        cameraTransform.position =
            new Vector3(pos.x, Math.Max(pos.y, seafloor.transform.position.y + 15), cameraPosition.z);
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
		Quaternion checkedValue = _rb.rotation * deltaRotation;
		checkedValue.y =  Mathf.Clamp(checkedValue.y, -90f, 90f);
		
        _rb.MoveRotation(checkedValue);
    }
}