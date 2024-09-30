using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed at which the player rotates
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the target direction based on input
        Vector3 targetDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Rotate the player if there is movement input
        if (targetDirection.magnitude > 0)
        {
            // Create a rotation based on the target direction
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // Smoothly rotate the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
