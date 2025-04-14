using UnityEngine;

public class CameraFollowFreely : MonoBehaviour
{
    [Header("Follow Settings")]
    [Tooltip("The target (usually the player) the camera should follow.")]
    public Transform target;
    [Tooltip("Vertical offset from the target.")]
    public float height = 2.5f; // Lowered default height
    [Tooltip("Default distance behind the target.")]
    public float distance = 8f;
    [Tooltip("How quickly the camera moves to the target position.")]
    public float smoothSpeed = 0.125f;

    [Header("Orbit & Zoom Settings")]
    [Tooltip("Horizontal orbit sensitivity when holding CTRL + mouse movement.")]
    public float orbitHorizontalSpeed = 5f;
    [Tooltip("Vertical orbit sensitivity when holding CTRL + mouse movement.")]
    public float orbitVerticalSpeed = 0.1f; // Dramatically reduced for much less sensitive vertical movement
    [Tooltip("Zoom sensitivity using the mouse scroll wheel.")]
    public float zoomSpeed = 2f;
    [Tooltip("Minimum allowed camera distance.")]
    public float minDistance = 1.5f; // Reduced to allow closer zoom
    [Tooltip("Maximum allowed camera distance.")]
    public float maxDistance = 15f;
    [Tooltip("Minimum vertical orbit angle (negative = looking up).")]
    public float minVerticalAngle = -20f; // More negative to look up more
    [Tooltip("Maximum vertical orbit angle (positive = looking down).")]
    public float maxVerticalAngle = 50f; // Reduced to prevent extreme top-down view
    [Tooltip("Minimum height offset for the camera.")]
    public float minHeight = 0.25f; // Lower minimum for crouching view
    [Tooltip("Maximum height offset for the camera.")]
    public float maxHeight = 8f;

    [Header("Movement Detection")]
    [Tooltip("Threshold to detect player movement")]
    public float movementThreshold = 0.001f; // Very small threshold for sensitive movement detection
    [Tooltip("Threshold to detect player rotation")]
    public float rotationThreshold = 0.5f; // How many degrees the player needs to rotate to be considered "rotating"

    [Header("Collision Settings")]
    [Tooltip("Layers that the camera should avoid clipping through.")]
    public LayerMask collisionLayers = 1; // Default layer
    [Tooltip("Radius of the camera collision sphere.")]
    public float cameraRadius = 0.5f; // Increased from 0.2f for better collision detection
    [Tooltip("How quickly the camera adjusts when a collision is detected.")]
    public float collisionDampening = 0.2f;

    // Private state variables
    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 10f; // Lower default angle for more forward view
    private float desiredDistance;
    private float currentHeight;
    private Vector3 currentVelocity = Vector3.zero;
    private float actualDistance; // Used for collision detection
    private bool wasControlHeld = false; // For tracking Control key state
    private bool isControlHeld = false; // Accessible throughout the script
    private Vector2 lastMousePosition; // For tracking mouse movement
    private Vector3 lastTargetPosition; // For detecting player movement
    private Quaternion lastTargetRotation; // For detecting player rotation
    private bool isPlayerMoving = false; // Flag to track if player is moving
    private bool isPlayerRotating = false; // Flag to track if player is rotating

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollowFreely: No target assigned! Please assign a target in the Inspector.");
        }

        // Initialize values
        desiredDistance = distance;
        actualDistance = distance;
        currentHeight = height;

        // Initialize orbit angle to match the target's current Y rotation
        currentHorizontalAngle = target ? target.eulerAngles.y : 0f;

        // Make sure cursor is visible at start
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Initialize mouse position
        lastMousePosition = Input.mousePosition;

        // Initialize target position tracking
        if (target)
        {
            lastTargetPosition = target.position;
            lastTargetRotation = target.rotation;
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // ----- Check if player is moving or rotating -----
        if (target)
        {
            // Check movement
            float distanceMoved = Vector3.Distance(lastTargetPosition, target.position);
            isPlayerMoving = distanceMoved > movementThreshold;

            // Check rotation - using Quaternion.Angle to get the angle between current and previous rotation
            float rotationDelta = Quaternion.Angle(lastTargetRotation, target.rotation);
            isPlayerRotating = rotationDelta > rotationThreshold;

            // Debug movement and rotation
            // Debug.Log($"Distance moved: {distanceMoved}, Rotation delta: {rotationDelta}, Moving: {isPlayerMoving}, Rotating: {isPlayerRotating}");

            // Update last position and rotation AFTER checking
            lastTargetPosition = target.position;
            lastTargetRotation = target.rotation;
        }

        // ----- Handle Zoom with Mouse Wheel -----
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scrollDelta) > 0.001f)
        {
            desiredDistance -= scrollDelta * zoomSpeed;
            desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);

            // Adjust vertical angle based on zoom level - more forward-facing when zoomed in
            float zoomFactor = Mathf.InverseLerp(minDistance, maxDistance, desiredDistance);
            // When zoomed in (close to minDistance), use a more horizontal angle
            // When zoomed out (close to maxDistance), use a more downward angle
            if (!isControlHeld) // Only auto-adjust when not manually controlling
            {
                currentVerticalAngle = Mathf.Lerp(-10f, 30f, zoomFactor);
            }

            // Also adjust height based on zoom
            if (!isControlHeld) // Only auto-adjust when not manually controlling
            {
                currentHeight = Mathf.Lerp(1.0f, 5.0f, zoomFactor);
            }
        }

        // Update control state
        isControlHeld = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // Handle cursor visibility on state change
        if (isControlHeld != wasControlHeld)
        {
            if (isControlHeld)
            {
                // Save mouse position before locking
                lastMousePosition = Input.mousePosition;

                // Hide and lock cursor when control is pressed
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                // Restore cursor when control is released
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                // We can't directly set the cursor position in older Unity versions without Input System
                // Instead, move the cursor to the center of the screen
                // The user will need to move the mouse slightly to see it
            }
            wasControlHeld = isControlHeld;
        }

        if (isControlHeld)
        {
            // Use raw mouse delta instead of screen position
            float mouseXInput = Input.GetAxis("Mouse X");
            float mouseYInput = Input.GetAxis("Mouse Y");

            // Horizontal orbit (left/right)
            currentHorizontalAngle += mouseXInput * orbitHorizontalSpeed;

            // Vertical orbit (up/down) - MORE DIRECT height control
            float mouseY = Input.GetAxis("Mouse Y");

            // Direct height adjustment - move camera up and down more explicitly
            currentHeight -= mouseYInput * orbitVerticalSpeed; // Invert for natural feel (up = higher camera)
            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            // Enhanced vertical angle control - better low position
            // Adjust vertical angle more dramatically based on height
            if (currentHeight < 1.0f)
            {
                // When very low, look more upward for ground-level views
                currentVerticalAngle = Mathf.Lerp(minVerticalAngle, 0f, currentHeight / 1.0f);
            }
            else
            {
                // Normal mapping for typical heights
                currentVerticalAngle = Mathf.Lerp(0f, maxVerticalAngle,
                                               (currentHeight - 1.0f) / (maxHeight - 1.0f));
            }
        }
        else
        {
            float targetYRotation = target.eulerAngles.y;

            // Handle different realignment speeds based on whether the player is moving or just rotating
            if (isPlayerMoving)
            {
                // Fast realignment when player is moving
                float movementRealignSpeed = orbitHorizontalSpeed * 2.0f;
                currentHorizontalAngle = Mathf.LerpAngle(currentHorizontalAngle, targetYRotation, Time.deltaTime * movementRealignSpeed);
            }
            else if (isPlayerRotating)
            {
                // Slower realignment (half speed) when player is only rotating but not moving
                float rotationRealignSpeed = orbitHorizontalSpeed * 1.0f; // Half as fast as movement realignment
                currentHorizontalAngle = Mathf.LerpAngle(currentHorizontalAngle, targetYRotation, Time.deltaTime * rotationRealignSpeed);
            }
            // When completely stationary (no movement or rotation), keep the current camera angle
        }

        // ----- Compute Desired Camera Position -----
        // Create rotation based on current orbit angles
        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);

        // Calculate the desired position (before collision check)
        Vector3 desiredPosition = CalculateDesiredPosition(rotation);

        // ----- Handle Collision Detection -----
        actualDistance = HandleCameraCollision(desiredPosition);

        // Recalculate position with collision-adjusted distance
        desiredPosition = CalculateAdjustedPosition(rotation, actualDistance);

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

        // ----- Always Look at the Target -----
        // Add a small offset for better framing
        Vector3 lookAtPoint = target.position + Vector3.up * 1.5f;
        transform.LookAt(lookAtPoint);
    }

    private Vector3 CalculateDesiredPosition(Quaternion rotation)
    {
        // Calculate offset based on current orbit angle
        Vector3 direction = rotation * Vector3.back;

        // Adjust height offset based on zoom distance to create better close-up views
        float zoomFactor = Mathf.InverseLerp(minDistance, maxDistance, desiredDistance);
        float heightAdjustment = currentHeight;

        // When zoomed in, reduce height offset slightly to get a more direct view
        if (desiredDistance < 4.0f)
        {
            heightAdjustment *= 0.8f;
        }

        Vector3 heightOffset = Vector3.up * heightAdjustment;

        // Calculate desired position
        return target.position + heightOffset + direction * desiredDistance;
    }

    private Vector3 CalculateAdjustedPosition(Quaternion rotation, float adjustedDistance)
    {
        // Calculate offset based on current orbit angle but with adjusted distance
        Vector3 direction = rotation * Vector3.back;

        // Use the same height adjustment logic as in CalculateDesiredPosition
        float zoomFactor = Mathf.InverseLerp(minDistance, maxDistance, adjustedDistance);
        float heightAdjustment = currentHeight;

        // When zoomed in, reduce height offset slightly to get a more direct view
        if (adjustedDistance < 4.0f)
        {
            heightAdjustment *= 0.8f;
        }

        Vector3 heightOffset = Vector3.up * heightAdjustment;

        // Calculate adjusted position
        return target.position + heightOffset + direction * adjustedDistance;
    }

    private float HandleCameraCollision(Vector3 desiredPosition)
    {
        // Direction from target (with height offset) to desired camera position
        Vector3 targetWithOffset = target.position + Vector3.up * currentHeight;
        Vector3 direction = (desiredPosition - targetWithOffset).normalized;
        float targetDistance = Vector3.Distance(targetWithOffset, desiredPosition);

        // Cast a ray from the target towards the desired camera position
        RaycastHit hit;
        if (Physics.SphereCast(targetWithOffset, cameraRadius, direction, out hit, desiredDistance, collisionLayers))
        {
            // If we hit something, adjust the distance
            float adjustedDistance = hit.distance * 0.85f; // Increased buffer space (0.9f to 0.85f)
            return Mathf.Lerp(actualDistance, adjustedDistance, Time.deltaTime / collisionDampening);
        }

        // If no collision, smoothly return to the desired distance
        return Mathf.Lerp(actualDistance, desiredDistance, Time.deltaTime / collisionDampening);
    }
}