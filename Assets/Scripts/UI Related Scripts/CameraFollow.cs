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

        // Try to find the player's CameraPivot.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transform pivot = player.transform.Find("CameraPivot");
            if (pivot != null)
            {
                // Use the pivot as the follow target.
                lastTilePosition = pivot.position;
                currentPlayerForward = Vector3.forward;
                Debug.Log("CameraFollow: Using CameraPivot as follow target.");
            }
            else
            {
                // If no pivot exists, fall back to the player.
                lastTilePosition = player.transform.position;
                currentPlayerForward = Vector3.forward;
                Debug.LogWarning("CameraPivot not found; using player transform as follow target.");
            }
        }
        // Otherwise, fallback if nothing is found
        else
        {
            Debug.LogWarning("Player object not found in CameraFollow.");
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