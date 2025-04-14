//PlayerController.cs


using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the Horizontal and Vertical axes.
        float horizontal = Input.GetAxis("Horizontal"); // Uses A/D or Left/Right arrow keys by default.
        float vertical = Input.GetAxis("Vertical");     // Uses W/S or Up/Down arrow keys by default.

        // Create a movement vector based on input.
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Normalize to avoid faster diagonal movement then scale by speed.
        movement = movement.normalized * moveSpeed;

        // Preserve the existing vertical velocity (important for gravity and jump physics).
        movement.y = rb.linearVelocity.y;

        // Apply the movement vector to the Rigidbody's velocity.
        rb.linearVelocity = movement;

        // Check for the spacebar press and ensure the player is on the ground before jumping.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Use AddForce with Impulse to make the jump more realistic.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Prevent multiple jumps until grounded again.
        }
    }

    // Simple ground detection using collision events.
    private void OnCollisionEnter(Collision collision)
    {
        // Verify if the player has collided with an object tagged as "Ground."
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
