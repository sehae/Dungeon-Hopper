using UnityEngine;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's X coordinate and adjusts the Y offset based on the player's height.
/// </summary>
[SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class CameraLockX : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    public float m_XPosition = 0;

    [Tooltip("Offset to keep the player centered in Y direction")]
    public float yOffset = 0;

    [Tooltip("Height at which the Y offset should start resetting")]
    public float heightThreshold = 10f;

    [Tooltip("Speed at which the Y offset resets to 0")]
    public float offsetResetSpeed = 0.05f;

    private float initialYOffset;

    protected override void OnEnable()
    {
        base.OnEnable();
        initialYOffset = yOffset;
    }

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            var pos = state.RawPosition;
            pos.x = m_XPosition;

            // Adjust the Y position based on player's height and the threshold
            if (vcam.Follow != null)
            {
                Transform player = vcam.Follow;
                if (player != null)
                {
                    if (player.position.y > heightThreshold)
                    {
                        yOffset = Mathf.Lerp(yOffset, 0, offsetResetSpeed);
                    }
                    else
                    {
                        yOffset = Mathf.Lerp(yOffset, initialYOffset, offsetResetSpeed);
                    }
                    pos.y = player.position.y + yOffset;
                }
            }

            state.RawPosition = pos;
        }
    }
}
