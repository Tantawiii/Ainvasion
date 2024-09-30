using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player’s transform
    public Vector3 offset;   // Offset from the player’s position
    public float smoothSpeed = 0.125f; // Smoothness factor

    public float rotationSpeed = 5f; // Speed of camera rotation
    private float yaw; // Yaw angle for horizontal rotation
    private float pitch; // Pitch angle for vertical rotation

    void LateUpdate()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Update yaw and pitch
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -20f, 60f); // Limit the vertical rotation

        // Calculate the desired rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Set the camera position based on the player's position and the offset
        Vector3 desiredPosition = player.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(player);
    }
}
