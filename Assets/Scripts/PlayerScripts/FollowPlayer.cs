using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Controls how responsive the camera is to mouse movement
    private readonly float _mouseSensitivity = 50f; 
    // Reference to the player's body for horizontal rotation
    public Transform playerBody; 
    // Keeps track of the camera's vertical rotation (look up/down)
    private float _xRotation = 0f;

    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked; 
    }
    void Update()
    {
        // Get horizontal and vertical mouse input
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -40f, 40f);
        
        // Apply vertical rotation to the camera
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Rotate the player horizontally based on mouse X movement
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
