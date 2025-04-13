// CameraFollow.cs


using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private StateManager theStateManager;
    private Vector3 lastTilePosition;
    private Vector3 currentPlayerForward = Vector3.forward; // Default forward direction
    public float height = 10f;
    public float distance = 8f;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        // Force a consistent initial camera orientation
        currentPlayerForward = Vector3.forward;
        transform.rotation = Quaternion.Euler(30f, 0f, 0f); // Set a fixed initial angle

        // Find the initial player position
        PlayerMove[] players = GameObject.FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        foreach (PlayerMove player in players)
        {
            if (player.PlayerId == 0) // Player 1
            {
                lastTilePosition = player.transform.position;
                break;
            }
        }

        Debug.Log($"Camera initialized looking {currentPlayerForward} from position {transform.position}");
    }

    void LateUpdate()
    {
        if (theStateManager == null)
        {
            theStateManager = GameObject.FindFirstObjectByType<StateManager>();
            if (theStateManager == null) return; // Exit if we still can't find it
        }

        // Find active players
        PlayerMove[] players = GameObject.FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        PlayerMove currentPlayer = null;

        // Find the current active player
        foreach (PlayerMove player in players)
        {
            if (player.PlayerId == theStateManager.CurrentPlayerId && player.gameObject.activeInHierarchy)
            {
                currentPlayer = player;
                break;
            }
        }

        // If we found the current player
        if (currentPlayer != null)
        {
            Transform playerTransform = currentPlayer.transform;
            Vector3 playerPosition = playerTransform.position;

            // Check if the player has a valid current tile
            if (currentPlayer.currentTile != null)
            {
                Vector3 currentTilePosition = currentPlayer.currentTile.transform.position;

                // Only update direction if we've moved significantly
                if (Vector3.Distance(currentTilePosition, lastTilePosition) > 0.1f)
                {
                    Vector3 movement = currentTilePosition - lastTilePosition;
                    if (movement.magnitude > 0.1f)
                    {
                        currentPlayerForward = movement.normalized;
                    }
                }

                lastTilePosition = currentTilePosition;
            }

            // Use the player position directly even if the tile is null
            Vector3 desiredPosition = playerPosition - currentPlayerForward * distance + Vector3.up * height;

            // Smoothly move camera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Look at player position
            transform.LookAt(playerPosition);
        }
        else
        {
            Debug.LogWarning("CameraFollow: Current player not found. Player ID: " + theStateManager.CurrentPlayerId);
        }
    }
}