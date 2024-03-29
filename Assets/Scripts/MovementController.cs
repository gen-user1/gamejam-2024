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
        // rigidbodyComponent = GetComponent<Rigidbody>();
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


/**
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Transform groundCheckTransform = null;
    [SerializeField] public LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }
}
**/