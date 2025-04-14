//CharacterMovement.cs


using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component not found on " + gameObject.name);
        }
        else
        {
            Debug.Log("CharacterController component successfully initialized.");
        }
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        Debug.Log("Controller.isGrounded: " + isGrounded);

        // Reset vertical velocity if grounded.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get movement input.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("Input received - Horizontal: " + horizontal + ", Vertical: " + vertical);

        // Calculate and log the movement direction.
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        Debug.Log("Calculated movement vector: " + move);

        // Move the character.
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump if spacebar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed. isGrounded: " + isGrounded);
            if (isGrounded)
            {
                // Calculate jump velocity.
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Debug.Log("Jump initiated with velocity: " + velocity.y);
            }
            else
            {
                Debug.Log("Jump attempted but CharacterController is not grounded.");
            }
        }

        // Apply gravity and log the velocity.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        Debug.Log("Final velocity after applying gravity: " + velocity);
    }
}
