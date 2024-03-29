using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
     private Rigidbody rigidbodyComponent;
     private bool downWasPressed;
     private bool upWasPressed;
     private bool leftWasPressed;
     private bool rightWasPressed;

    // Start is called before the first frame update
    void Start()
    {
         rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            downWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            upWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rightWasPressed = true;
        }

    }


    private void FixedUpdate() 
    {
        if (downWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.down * 2, ForceMode.VelocityChange);
            downWasPressed = false;
        }

        if (upWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
            upWasPressed = false;
        }

        if (leftWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.left * 2, ForceMode.VelocityChange);
            leftWasPressed = false;
        }

        if (rightWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.right * 2, ForceMode.VelocityChange);
            rightWasPressed = false;
        }
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