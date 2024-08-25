using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float heightThreshold = 10f;
    public float offsetResetSpeed = 0.05f;

    private Vector3 initialOffset;

    void Start()
    {
        // Store the initial offset
        initialOffset = offset;
    }

    void LateUpdate()
    {
        // Check if the player has reached the height threshold
        if (player.position.y > heightThreshold)
        {
            // Gradually reset the offset to its initial value
            offset.y = Mathf.Lerp(offset.y, initialOffset.y, offsetResetSpeed);
        }
        else
        {
            // Restore the initial offset if below the threshold
            offset.y = Mathf.Lerp(offset.y, initialOffset.y, offsetResetSpeed);
        }

        // Target position for the camera
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
