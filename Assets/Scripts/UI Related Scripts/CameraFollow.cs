// CameraFollow.cs
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private StateManager theStateManager;
    private Vector3 lastTilePosition;
    private Vector3 currentPlayerForward;

    public float height = 10f;
    public float distance = 8f;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        // Fix initial camera direction for Player 1
        currentPlayerForward = Vector3.forward; // Adjust this if needed

        // Initialize the first tile position
        PlayerMove[] players = GameObject.FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        foreach (PlayerMove player in players)
        {
            if (player.PlayerId == 0) // First player
            {
                lastTilePosition = player.currentTile.transform.position;
                break;
            }
        }
    }

    void LateUpdate()
    {
        PlayerMove[] players = GameObject.FindObjectsByType<PlayerMove>(FindObjectsSortMode.None);
        foreach (PlayerMove player in players)
        {
            if (player.PlayerId == theStateManager.CurrentPlayerId)
            {
                Transform playerTransform = player.transform;
                Vector3 currentTilePosition = player.currentTile.transform.position;

                // Only use tile positions for determining direction
                if (Vector3.Distance(currentTilePosition, lastTilePosition) > 0.1f)
                {
                    Vector3 movement = currentTilePosition - lastTilePosition;
                    if (movement.magnitude > 0.1f)
                    {
                        currentPlayerForward = movement.normalized;
                    }
                }

                // Use actual player position for camera positioning
                Vector3 desiredPosition = playerTransform.position - currentPlayerForward * distance + Vector3.up * height;

                // Smoothly move camera
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;

                // Look at actual player position
                transform.LookAt(playerTransform.position);

                lastTilePosition = currentTilePosition;
                break;
            }
        }
    }
}