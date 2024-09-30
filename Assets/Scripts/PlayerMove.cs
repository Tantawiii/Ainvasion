using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float rotationSpeed = 10f; // Speed at which the player rotates
    private CharacterController characterController;
    public Camera playerCamera; // Reference to the camera

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // If the camera is not assigned, find it in the scene
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera's rotation
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0; // Ignore the y component for ground movement
        cameraForward.Normalize();

        Vector3 cameraRight = playerCamera.transform.right;

        // Calculate the move direction relative to the camera
        Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

        // Apply movement
        if (moveDirection.magnitude > 0)
        {
            // Move the player
            Vector3 move = moveDirection * speed;
            characterController.Move(move * Time.deltaTime);

            // Create a rotation based on the target direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // Smoothly rotate the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
