using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;  // Smooth movement speed
    public Vector3 offset;  // Offset to keep the player centered
    public float heightThreshold = 10f;  // The height at which the offset should start resetting
    public float offsetResetSpeed = 0.05f;  // Speed at which the offset resets to 0

    void LateUpdate()
    {
        // Check if the player has reached the height threshold
        if (player.position.y > heightThreshold)
        {
            // Gradually reset the offset to 0 smoothly
            offset.y = Mathf.Lerp(offset.y, 0, offsetResetSpeed);
        }

        // Target position for the camera
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
