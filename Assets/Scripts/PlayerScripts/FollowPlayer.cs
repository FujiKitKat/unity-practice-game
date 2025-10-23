using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private readonly float _mouseSensitivity = 50f; 
    public Transform playerBody; 
    private float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -40f, 40f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

       
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
