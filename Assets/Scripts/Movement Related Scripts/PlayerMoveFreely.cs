//PlayerMoveFreely.cs


using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveFreely : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2.5f;          // Walking speed
    public float runSpeed = 8f;             // Running speed (when holding Shift)
    public float jumpHeight = 2.5f;         // Jump height
    public float gravity = -25f;            // Gravity force
    public float fallingGravityMultiplier = 1.5f; // Multiply gravity when falling for a snappier feel

    [Header("Rotation Settings")]
    [Tooltip("Maximum rotation sensitivity when the player is stationary (degrees per mouse unit)")]
    public float maxMouseSensitivity = 10f;
    [Tooltip("Minimum rotation sensitivity when the player is moving at full input (degrees per mouse unit)")]
    public float minMouseSensitivity = 2.5f;
    [Tooltip("Multiplier to apply to the mouse X input")]
    public float mouseRotationMultiplier = 1f;

    [Header("Animation Settings")]
    public Animator animator;         // Reference to the Animator component (if your model uses animation)
    [Tooltip("Speed threshold above which the player is considered to be running")]
    public float runThreshold = 3.0f;

    // Private state
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        // Cache the CharacterController component.
        controller = GetComponent<CharacterController>();
        if (controller == null)
            Debug.LogError("PlayerMoveFreely: CharacterController component not found on " + gameObject.name);

        // Cache the Animator. (If you want animation; you may choose to remove these if not needed.)
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
                Debug.LogError("PlayerMoveFreely: Animator component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // --- Grounding & Gravity ---
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            // A small negative value helps keep you “stuck” to the ground.
            velocity.y = -2f;
        }

        // --- Movement Input ---
        // Get WASD or arrow key input (this is independent of the camera)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Build the input direction vector on the horizontal (XZ) plane.
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical);
        // If the magnitude is greater than 1, normalize it.
        if (inputDir.magnitude > 1f)
            inputDir.Normalize();

        // Determine speed: if Shift is held, use running speed; otherwise, walking speed.
        bool isRunningInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isRunningInput ? runSpeed : walkSpeed;
        // Compute movement relative to the character's current orientation.
        Vector3 movement = (transform.right * inputDir.x + transform.forward * inputDir.z) * currentSpeed;

        // --- Apply Horizontal Movement ---
        controller.Move(movement * Time.deltaTime);

        // --- Jumping ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Calculate jump velocity using: v = sqrt(2 * jumpHeight * -gravity)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity ---
        // If falling, amplify gravity.
        float appliedGravity = (velocity.y < 0) ? gravity * fallingGravityMultiplier : gravity;
        velocity.y += appliedGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // --- Animation Updates ---
        if (animator != null)
        {
            // Use the magnitude of horizontal movement as the basis for animation speed.
            float movementMagnitude = new Vector3(movement.x, 0, movement.z).magnitude;
            bool isWalking = movementMagnitude > 0.1f && movementMagnitude < runThreshold;
            bool isRunning = movementMagnitude >= runThreshold;
            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isRunning", isRunning);
            animator.SetFloat("WalkSpeed", movementMagnitude);
        }

        // --- Mouse-based Rotation ---
        // When right mouse button is not held (i.e. not dragging for camera orbit)
        if (!Input.GetMouseButton(1))
        {
            // Get the mouse X delta.
            float mouseX = Input.GetAxis("Mouse X");

            // Determine sensitivity based on how strong the WASD input is.
            // When the character is stationary (inputDir.magnitude near 0), use the maximum sensitivity.
            // When the character is moving at full input (magnitude 1), use the minimum sensitivity.
            float sensitivity = Mathf.Lerp(maxMouseSensitivity, minMouseSensitivity, Mathf.Clamp01(inputDir.magnitude));

            // Multiply by any additional factor and deltaTime
            float rotationY = mouseX * sensitivity * mouseRotationMultiplier;
            // Rotate the player around the Y-axis.
            transform.Rotate(0f, rotationY, 0f);
        }
    }
}
