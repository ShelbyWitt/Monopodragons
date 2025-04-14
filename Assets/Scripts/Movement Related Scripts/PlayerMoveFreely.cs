//PlayerMoveFreely.cs
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveFreely : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2.5f;          // Walking speed.
    public float runSpeed = 8f;             // Running speed when Shift is held.
    [Tooltip("How fast the player accelerates to the target speed.")]
    public float acceleration = 10f;        // Acceleration rate.
    [Tooltip("How fast the player decelerates when no input is provided.")]
    public float deceleration = 20f;        // Deceleration rate (should be higher than acceleration).
    public float jumpHeight = 2.5f;         // Jump height.
    public float gravity = -25f;            // Gravity acceleration.
    [Tooltip("Additional gravity factor when falling (for a snappier descent).")]
    public float fallingGravityMultiplier = 1.5f;
    [Tooltip("Speed threshold (in units/second) that distinguishes walking from running.")]
    public float runThreshold = 3.0f;

    [Header("Mouse Rotation Settings")]
    [Tooltip("Base rotation sensitivity for keyboard rotation when RMB is not held.")]
    public float baseKeyboardRotationSensitivity = 100f;
    [Tooltip("Base rotation sensitivity for mouse rotation when RMB is held.")]
    public float baseMouseRotationSensitivity = 100f;
    [Tooltip("Multiplier to scale the maximum mouse rotation (applied after sensitivity and reduced by 20%).")]
    public float mouseRotationMaxMultiplier = 1.5f;
    [Tooltip("Maximum movement speed (used as a reference for scaling keyboard rotation sensitivity).")]
    public float maxMovementReference = 8f;
    [Tooltip("Speed (in degrees per second) at which the current horizontal velocity rotates to align with the player's facing.")]
    public float velocityTurnSpeed = 720f;
    [Tooltip("Percentage of screen width from center that is considered the deadzone (no rotation).")]
    public float mouseDeadzonePercent = 20f;

    [Header("Mouse Rotation Multipliers")]
    [Tooltip("Mouse sensitivity multiplier when idle (no movement).")]
    public float idleMouseSensitivityMultiplier = 1f;
    [Tooltip("Mouse sensitivity multiplier when running.")]
    public float runningMouseSensitivityMultiplier = 1.25f;

    [Header("Strafe Keys (when RMB is not held, A/D rotate; when RMB is held, A/D act as strafe keys)")]
    public KeyCode strafeLeftKey = KeyCode.Z;
    public KeyCode strafeRightKey = KeyCode.C;

    [Header("Animation Settings")]
    [Tooltip("Animation speed multiplier for walking state.")]
    public float walkAnimSpeed = 1f;
    [Tooltip("Animation speed multiplier for running state.")]
    public float runAnimSpeed = 1f;
    public Animator animator;

    // Debug settings
    [Header("Debug")]
    public bool showDebugInfo = true;

    // Private state
    private CharacterController controller;
    private Vector3 velocity; // Vertical velocity.
    private Vector3 currentHorizontalVelocity = Vector3.zero;
    private bool wasRightMouseDown = false;
    private Vector2 lastMousePosition;
    private Vector2 screenCenter;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("PlayerMoveFreely: CharacterController component not found on " + gameObject.name);
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("PlayerMoveFreely: Animator component not found on " + gameObject.name);
            }
        }

        // Calculate screen center
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // --- Handle Cursor Visibility ---
        HandleCursor();

        // --- Grounding & Gravity ---
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // --- Movement & Rotation Input ---
        Vector3 inputMovementDir = Vector3.zero;
        bool isRightMouseDown = Input.GetMouseButton(1);

        // --- Handle Forward/Backward Movement (W/S keys) ---
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.W)) verticalInput += 1f;
        if (Input.GetKey(KeyCode.S)) verticalInput -= 1f;

        // First component: Forward/backward movement
        inputMovementDir += transform.forward * verticalInput;

        // --- Second component: Handle strafing based on right mouse button state ---
        if (isRightMouseDown)
        {
            // COMPLETELY DIFFERENT APPROACH: Direct key detection for A/D strafing
            float horizontalInput = 0f;

            // Check A/D keys directly - do NOT use Input.GetAxis
            if (Input.GetKey(KeyCode.A)) horizontalInput -= 1f;
            if (Input.GetKey(KeyCode.D)) horizontalInput += 1f;

            // Debug info
            if (showDebugInfo && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                Debug.Log("RMB held + A/D pressed: horizontalInput = " + horizontalInput);
            }

            // Apply horizontal input directly to movement direction
            inputMovementDir += transform.right * horizontalInput;

            // Use actual mouse screen position for rotation
            float offsetX = Input.mousePosition.x - screenCenter.x;
            float normalizedOffset = offsetX / (Screen.width * 0.5f);

            // Apply deadzone
            float deadzone = mouseDeadzonePercent / 100f;
            if (Mathf.Abs(normalizedOffset) < deadzone)
            {
                normalizedOffset = 0f;
            }
            else
            {
                // Remap to full range from deadzone edge
                normalizedOffset = Mathf.Sign(normalizedOffset) *
                                  (Mathf.Abs(normalizedOffset) - deadzone) / (1f - deadzone);
            }

            // Clamp final value
            normalizedOffset = Mathf.Clamp(normalizedOffset, -1f, 1f);

            // Determine speed multiplier based on current movement - improved curve
            float moveMag = new Vector3(currentHorizontalVelocity.x, 0f, currentHorizontalVelocity.z).magnitude;
            float t = Mathf.Clamp01(moveMag / runSpeed);

            // Apply a better curve - slower rotation when running
            // Square the value to create a non-linear curve that reduces sensitivity more during fast movement
            float runningFactor = 1.0f - (t * t * 0.5f);
            float mouseMultiplier = Mathf.Lerp(idleMouseSensitivityMultiplier, runningMouseSensitivityMultiplier, t) * runningFactor;

            // Apply sensitivity with improved curve to make small movements less jerky
            float rotationSpeed = Mathf.Sign(normalizedOffset) * Mathf.Pow(Mathf.Abs(normalizedOffset), 1.5f) *
                                 baseMouseRotationSensitivity * mouseMultiplier * mouseRotationMaxMultiplier;

            // Debug info
            if (showDebugInfo && Mathf.Abs(normalizedOffset) > 0.01f)
            {
                Debug.Log("Mouse position: " + Input.mousePosition +
                          ", Offset from center: " + offsetX +
                          ", Normalized offset: " + normalizedOffset +
                          ", Rotation speed: " + rotationSpeed + " degrees/sec");
            }

            // Apply rotation
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f);
        }
        else
        {
            // Z/C strafing when RMB not held - use the original working implementation
            float strafeInput = 0f;
            if (Input.GetKey(strafeLeftKey))
                strafeInput -= 1f;
            if (Input.GetKey(strafeRightKey))
                strafeInput += 1f;

            // Debug info
            if (showDebugInfo && (Input.GetKey(strafeLeftKey) || Input.GetKey(strafeRightKey)))
            {
                Debug.Log("RMB not held + Z/C pressed: strafeInput = " + strafeInput);
            }

            // Apply strafing to movement direction
            inputMovementDir += transform.right * strafeInput;

            // Handle rotation with A/D keys
            float rotationInput = 0f;
            if (Input.GetKey(KeyCode.A))
                rotationInput = -1f;
            if (Input.GetKey(KeyCode.D))
                rotationInput = 1f;

            if (Mathf.Abs(rotationInput) > 0.01f)
            {
                // Keep the keyboard rotation sensitivity constant regardless of movement speed
                float rotationAngle = rotationInput * baseKeyboardRotationSensitivity * Time.deltaTime;
                transform.Rotate(0f, rotationAngle, 0f);

                // Also, rotate current horizontal velocity toward the new facing direction quickly.
                if (currentHorizontalVelocity.magnitude > 0.1f)
                {
                    float maxAngleChange = velocityTurnSpeed * Time.deltaTime;
                    currentHorizontalVelocity = Vector3.RotateTowards(currentHorizontalVelocity, transform.forward * currentHorizontalVelocity.magnitude, Mathf.Deg2Rad * maxAngleChange, currentHorizontalVelocity.magnitude);
                }
            }
        }

        // Debug the final movement direction
        if (showDebugInfo && inputMovementDir.magnitude > 0.1f)
        {
            Debug.Log("Final inputMovementDir: " + inputMovementDir);
        }

        // Normalize if length exceeds 1 (diagonal movement)
        if (inputMovementDir.magnitude > 1f)
            inputMovementDir.Normalize();

        // --- Determine Target Speed ---
        bool isRunningInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float targetSpeed = isRunningInput ? runSpeed : walkSpeed;
        Vector3 targetHorizontalVelocity = inputMovementDir * targetSpeed;

        // --- Acceleration / Deceleration ---
        if (inputMovementDir.magnitude > 0.1f)
        {
            // If we're changing direction (dot product is negative), use the deceleration rate instead
            // This makes direction changes feel snappier and less floaty
            float dot = Vector3.Dot(currentHorizontalVelocity.normalized, targetHorizontalVelocity.normalized);
            float accelerationToUse = (dot < 0) ? deceleration : acceleration;

            currentHorizontalVelocity = Vector3.MoveTowards(
                currentHorizontalVelocity,
                targetHorizontalVelocity,
                accelerationToUse * Time.deltaTime
            );
        }
        else
        {
            currentHorizontalVelocity = Vector3.MoveTowards(currentHorizontalVelocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // --- Apply Horizontal Movement ---
        controller.Move(currentHorizontalVelocity * Time.deltaTime);

        // --- Update Animator Parameters ---
        UpdateAnimatorParameters(isGrounded);

        // --- Jumping ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity ---
        float appliedGravity = (velocity.y < 0) ? gravity * fallingGravityMultiplier : gravity;
        velocity.y += appliedGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Update last mouse position
        lastMousePosition = Input.mousePosition;
    }

    private void HandleCursor()
    {
        bool isRightMouseDown = Input.GetMouseButton(1);

        // Just track the state without changing cursor visibility
        wasRightMouseDown = isRightMouseDown;

        // Keep cursor visible and unlocked at all times
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void UpdateAnimatorParameters(bool isGrounded)
    {
        if (animator != null)
        {
            float horizontalSpeed = new Vector3(currentHorizontalVelocity.x, 0f, currentHorizontalVelocity.z).magnitude;
            bool isWalking = horizontalSpeed > 0.1f && horizontalSpeed < runThreshold;
            bool isRunning = horizontalSpeed >= runThreshold;

            animator.SetBool("isWalking", isWalking && !isRunning);
            animator.SetBool("isRunning", isRunning);

            // Set animation speed based on movement state
            if (isWalking)
                animator.SetFloat("WalkSpeed", walkAnimSpeed);
            else if (isRunning)
                animator.SetFloat("WalkSpeed", runAnimSpeed);
            else
                animator.SetFloat("WalkSpeed", 1f);

            // Optional: Add jump animation trigger
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                animator.SetTrigger("Jump");
            }
        }
    }
}