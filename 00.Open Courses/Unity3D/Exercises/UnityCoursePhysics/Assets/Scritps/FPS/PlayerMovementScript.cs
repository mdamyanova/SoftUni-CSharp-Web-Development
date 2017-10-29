using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    public float speedKoef = 0.5f;
    public float mouseSpeedX = 1f;
    public float mouseSpeedY = 1f;
    public float jumpForce = 1f;
    public float gravityInAir = 40f;
    public float normalGravity = 9.8f;
    public float maxMovingSpeed = 15;
    public float dampTime = 2;
    public bool isGrounded;
    private float mouseLookVertical;
    private float mouseLookHorizontal;
    private float dampVolumeX;
    private float dampVolumeZ;
    Camera playerCamera;
    private Vector2 movementVector;

    Rigidbody attachedRigidbody;

    private void Start()
    {
        playerCamera = Camera.main;
        Physics.gravity = -Vector3.up * normalGravity;
        attachedRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * speedKoef, 0f, Input.GetAxis("Vertical") * speedKoef);
        movementVector = new Vector2(attachedRigidbody.velocity.x, attachedRigidbody.velocity.z);

        if (movementVector.magnitude > maxMovingSpeed)
        {
            movementVector.Normalize();
            movementVector *= maxMovingSpeed;
        }

        attachedRigidbody.velocity = new Vector3(movementVector.x, attachedRigidbody.velocity.y, movementVector.y);

        attachedRigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * speedKoef, 0f, Input.GetAxis("Vertical") * speedKoef, ForceMode.Force);

        if (Input.GetAxis("Horizontal") == 0f && isGrounded)
        {
			attachedRigidbody.velocity = new Vector3(attachedRigidbody.velocity.x, attachedRigidbody.velocity.y, Mathf.SmoothDamp(attachedRigidbody.velocity.z, 0f, ref dampVolumeZ, dampTime));
        }

		if (Input.GetAxis("Vertical") == 0f && isGrounded)
		{
			attachedRigidbody.velocity = new Vector3(Mathf.SmoothDamp(attachedRigidbody.velocity.x, 0f, ref dampVolumeX, dampTime), attachedRigidbody.velocity.y, attachedRigidbody.velocity.z);
		}

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        mouseLookVertical = playerCamera.transform.localRotation.eulerAngles.x - (Input.GetAxis("Mouse Y") * mouseSpeedX);
        mouseLookHorizontal = transform.rotation.eulerAngles.y + (Input.GetAxis("Mouse X") * mouseSpeedY);

        if (mouseLookVertical <= 300 && mouseLookVertical >= 40)
            return;


        transform.localRotation = Quaternion.Euler(0f, mouseLookHorizontal, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(mouseLookVertical, 0f, 0f);
    }

    private void Jump()
    {
        Debug.Log("Jump");
        if (!isGrounded)
            return;

        attachedRigidbody.AddForce(Vector3.up * jumpForce);
        isGrounded = false;
        SetGravity(2);
    }

    /// <summary>
    /// type = 1 means normal gravity ; type = 2 means gravity in air
    /// </summary>
    /// <param name="type"></param>
    private void SetGravity(int type)
    {
        Physics.gravity = -Vector3.up * (type == 1 ? normalGravity : gravityInAir);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;

            if (Physics.gravity != Vector3.up * normalGravity)
            {
                SetGravity(1);
            }
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;
            SetGravity(1);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Floor" && isGrounded)
        {
            isGrounded = false;
            SetGravity(2);
        }
    }
}
