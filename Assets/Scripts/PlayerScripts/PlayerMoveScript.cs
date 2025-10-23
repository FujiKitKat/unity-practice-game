using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 3f;
    public float runSpeed = 5f;
    private float _forwardInput;
    private float _horizontalInput;
    
    private readonly float _jumpForce = 10f;
    public bool isGrounded;
    private Rigidbody _rb;

    private Animator _animator;
    public Transform cameraTransform;
    
    private readonly float _yRotation = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        MoveWithCameraDirection();
        Jump();
        PlayerTeleport();
    }

    private void MoveWithCameraDirection()
    {
        _forwardInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 moveDirection = (camForward * _forwardInput + camRight * _horizontalInput).normalized;

        //Player walk script
        if (moveDirection.magnitude > 0.1f)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

            _animator.SetFloat("WalkForward", moveDirection.magnitude);
        }

        else
        {
            _animator.SetFloat("WalkForward", 0f);
        }

        //Player run script
        if (moveDirection.magnitude > 0.1f && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(moveDirection * runSpeed * Time.deltaTime, Space.World);

            transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

            _animator.SetFloat("RunForward", moveDirection.magnitude);
        }

        else
        {
            _animator.SetFloat("RunForward", 0f);
        }

    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(0, _jumpForce, 0);
            _rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("isOnGround"))
        {
            isGrounded = true;
        }
    }
    
    private void PlayerTeleport()
    {
        if (gameObject.transform.position.y < -_yRotation)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        } 
    }

}
