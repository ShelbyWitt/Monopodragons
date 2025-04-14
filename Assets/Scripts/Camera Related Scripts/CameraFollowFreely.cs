//CameraFollowFreely.cs


using UnityEngine;

public class CameraFollowFreely : MonoBehaviour
{
    [Header("Target & Follow Settings")]
    public Transform target;             // The player object to follow. Set in the Inspector.
    public float defaultHeight = 3.0f;     // Vertical offset from the target.
    public float defaultDistance = 8.0f;   // Default distance from the target.

    [Header("Zoom Settings")]
    public float minDistance = 2.0f;       // Minimum zoom distance.
    public float maxDistance = 15.0f;      // Maximum zoom distance.
    public float zoomSensitivity = 2.0f;   // How fast the zoom responds to the scroll wheel.

    [Header("Orbit Settings")]
    public float orbitSensitivityX = 3.0f; // How fast the camera orbits horizontally.
    public float orbitSensitivityY = 2.0f; // How fast the camera orbits vertically.
    public float minVerticalAngle = -10.0f;// Minimum vertical (pitch) angle.
    public float maxVerticalAngle = 60.0f; // Maximum vertical (pitch) angle.
    public float smoothSpeed = 0.125f;     // Smooth damping for position updates.

    // Private state
    private float currentDistance;
    private float currentYaw;      // Horizontal angle around the target.
    private float currentPitch;    // Vertical angle (elevation) relative to the target.
    private bool isOrbiting;       // Whether player is actively orbiting via RMB.

    void Start()
    {
        // If target not set, try to find a GameObject tagged "Player"
        if (target == null)
        {
            GameObject t = GameObject.FindWithTag("Player");
            if (t != null)
            {
                target = t.transform;
            }
            else
            {
                Debug.LogError("CameraFollowFreely: No target assigned or found with tag 'Player'.");
            }
        }

        // Initialize our orbit values so that by default the camera is behind the target.
        currentDistance = defaultDistance;
        // Set the yaw so that the camera sits behind the target (target.forward gives facing direction,
        // so behind means opposite the forward)
        currentYaw = target.eulerAngles.y + 180f;
        // Set a default pitch (so the camera is slightly above)
        currentPitch = 20.0f;

        // Set the initial position of the camera
        UpdateCameraPosition(true);
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Handle zoom via mouse scroll
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scrollInput) > 0.001f)
        {
            currentDistance -= scrollInput * zoomSensitivity;
            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        }

        // If right mouse button is held down, allow orbiting.
        if (Input.GetMouseButton(1))
        {
            isOrbiting = true;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentYaw += mouseX * orbitSensitivityX;
            currentPitch -= mouseY * orbitSensitivityY;
            currentPitch = Mathf.Clamp(currentPitch, minVerticalAngle, maxVerticalAngle);
        }
        else
        {
            // Not orbiting; you might want to auto-align behind the target.
            // For example, smoothly set the yaw to follow the target’s back.
            isOrbiting = false;
            float desiredYaw = target.eulerAngles.y + 180f;
            currentYaw = Mathf.LerpAngle(currentYaw, desiredYaw, Time.deltaTime * 3f);
            // Optionally you can also clamp pitch to a default value if desired:
            currentPitch = Mathf.Lerp(currentPitch, 20f, Time.deltaTime * 3f);
        }

        UpdateCameraPosition(false);
    }

    // Updates the camera's position and rotation based on our current orbit parameters.
    void UpdateCameraPosition(bool instant)
    {
        // Convert spherical coordinates to Cartesian offset:
        // Note: angles in degrees
        float yawRad = currentYaw * Mathf.Deg2Rad;
        float pitchRad = currentPitch * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            currentDistance * Mathf.Cos(pitchRad) * Mathf.Sin(yawRad),
            currentDistance * Mathf.Sin(pitchRad),
            currentDistance * Mathf.Cos(pitchRad) * Mathf.Cos(yawRad)
        );

        Vector3 desiredPosition = target.position + offset + Vector3.up * defaultHeight;

        if (instant)
        {
            transform.position = desiredPosition;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }

        // The camera should look at the target's position offset upward if desired.
        Vector3 lookAtTarget = target.position + Vector3.up * (defaultHeight * 0.5f);
        transform.LookAt(lookAtTarget);
    }
}
