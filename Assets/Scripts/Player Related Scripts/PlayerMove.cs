//PlayerMove.cs
using Unity.Mathematics.Geometry;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    // Fields
    bool debugMode = false;
    StateManager theStateManager;
    bool isAnimating = false;
    Tiles[] moveQueue;
    int moveQueueIndex = 9999;
    public Tiles StartingTiles;
    public Tiles currentTile;
    public int PlayerId;
    Vector3 targetPosition;
    Vector3 velocity;
    float smoothTime = .25f;
    float smoothDistance = 0.01f;
    private Tiles previousTile;
    private bool isInCombat = false;

    //stores previous position
    private Vector3 lastValidMovementDirection = Vector3.forward;
    private bool isFirstTileInSequence = true;
    private Vector3 boardMovementDirection = Vector3.forward;
    private Tiles previousProcessedTile;

    //variables for rotation
    private Quaternion targetRotation;
    private float rotationSpeed = 10f;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        animator = GetComponent<Animator>();
        targetPosition = this.transform.position;
        currentTile = StartingTiles;

        // Always initialize with a consistent forward direction
        targetRotation = Quaternion.identity; // Default rotation (looking forward)
        lastValidMovementDirection = Vector3.forward;
        boardMovementDirection = Vector3.forward;

        // Force the player to face forward initially
        transform.rotation = Quaternion.identity;

        Debug.Log($"Player {PlayerId} initialized at position {transform.position} with starting tile {StartingTiles?.name ?? "null"}");
    }

    void Update()
    {
        // Handle animation based on movement state
        if (!isAnimating)
        {
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
                // Optionally, reset WalkSpeed to a base value when idle.
                animator.SetFloat("WalkSpeed", 0.5f);
            }
            return;
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("isWalking", true);

                // Use the new linear mapping:
                // WalkSpeed = 0.1818 * DiceTotal + 0.3182
                float newWalkSpeed = 0.1973f * theStateManager.DiceTotal + 0.1327f;
                animator.SetFloat("WalkSpeed", newWalkSpeed);
            }
        }

        // The rest of your movement code follows...
        float speedMultiplier = Mathf.Max(1f, theStateManager.DiceTotal * 0.5f);
        float currentSmoothTime = smoothTime / speedMultiplier;

        // Rotate the transform smoothly towards targetRotation.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Calculate distance to target ignoring the y-axis.
        float distanceToTarget = Vector3.Distance(
            new Vector3(transform.position.x, 0, transform.position.z),
            new Vector3(targetPosition.x, 0, targetPosition.z)
        );

        if (distanceToTarget < smoothDistance)
        {
            if (moveQueue != null && moveQueueIndex < moveQueue.Length)
            {
                AdvanceMoveQueue();
            }
            else
            {
                isAnimating = false;
                theStateManager.IsDoneAnimating = true;
                Debug.Log($"Player {PlayerId}: Movement complete");
            }
        }
        else
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                new Vector3(targetPosition.x, transform.position.y, targetPosition.z),
                ref velocity,
                currentSmoothTime
            );
        }
    }




    void AdvanceMoveQueue()
    {
        if (moveQueue != null && moveQueueIndex < moveQueue.Length)
        {
            Tiles nextTile = moveQueue[moveQueueIndex];
            if (nextTile == null)
            {
                Debug.LogError($"Player {PlayerId}: Next tile is null at index {moveQueueIndex}");
                // Skip this step
                moveQueueIndex++;
                return;
            }

            bool isFinalMove = (moveQueueIndex == moveQueue.Length - 1);

            if (isFinalMove && !nextTile.CanOccupy())
            {
                nextTile = currentTile;
                Debug.Log($"Player {PlayerId}: Tile is full! Staying at current tile.");
            }

            // Remove player from current tile
            if (currentTile != null)
            {
                currentTile.RemovePlayer(this);
            }

            // Calculate world space positions for reliable direction
            Vector3 currentPosition = transform.position;
            Vector3 nextPosition = nextTile.transform.position;
            Vector3 movementDirection = nextPosition - currentPosition;
            movementDirection.y = 0; // Keep movement flat on the board

            // Only set rotation if we have a significant direction
            if (movementDirection.magnitude > 0.1f)
            {
                targetRotation = Quaternion.LookRotation(movementDirection.normalized);
                lastValidMovementDirection = movementDirection.normalized;
                Debug.Log($"Player {PlayerId}: Moving from {currentTile?.name ?? "null"} to {nextTile.name} " +
                         $"in direction {movementDirection.normalized}");
            }
            else
            {
                // Use the last valid direction if current calculation is too small
                targetRotation = Quaternion.LookRotation(lastValidMovementDirection);
                Debug.Log($"Player {PlayerId}: Using last valid direction {lastValidMovementDirection}");
            }

            // Store the previous tile before updating current
            previousProcessedTile = currentTile;

            // Calculate new position based on tile and offset
            Vector3 tilePos = nextTile.transform.position;
            Vector3 offset = nextTile.GetOffsetPosition();
            Vector3 newTargetPos = tilePos + offset;

            // Set target position (this should trigger the smoothed movement in Update)
            SetNewTargetPosition(newTargetPos);
            Debug.Log($"Player {PlayerId}: Setting target position to {newTargetPos}, offset={offset}");

            // Update player's current tile reference
            nextTile.AddPlayer(this);
            currentTile = nextTile;

            // Trigger tile effects on final move
            if (isFinalMove)
            {
                TileType tileType = nextTile.GetComponentInChildren<TileType>();
                if (tileType != null)
                {
                    tileType.OnPlayerLand(GetComponent<Player>());
                }
            }

            moveQueueIndex++;
        }
        else
        {
            // End of movement
            if (currentTile != null)
            {
                currentTile.RemovePlayer(this);
            }
            isAnimating = false;
            theStateManager.IsDoneAnimating = true;
            Debug.Log($"Player {PlayerId}: Movement complete");
        }
    }

    private void AttemptInitiateCombat(PlayerMove defender)
    {
        if (isInCombat) return;

        Debug.Log($"Attempting combat between Player {PlayerId} and Player {defender.PlayerId}");

        CombatManager combatManager = GameObject.FindFirstObjectByType<CombatManager>();
        if (combatManager != null)
        {
            Player attackingPlayer = GetComponent<Player>();
            Player defendingPlayer = defender.GetComponent<Player>();

            if (attackingPlayer != null && defendingPlayer != null)
            {
                isInCombat = true;
                isAnimating = false;
                Debug.Log($"Initiating combat between Player {PlayerId} and Player {defender.PlayerId}");
                combatManager.InitiateCombat(attackingPlayer, defendingPlayer);
            }
        }
        else
        {
            Debug.LogError("CombatManager not found in scene!");
            isAnimating = false;
            theStateManager.IsDoneAnimating = true;
        }
    }

    public void EndCombat()
    {
        isInCombat = false;
        isAnimating = false;
        theStateManager.IsDoneAnimating = true;
    }

    void SetNewTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        velocity = Vector3.zero;
    }

    public void OnMouseUp()
    {
        if (debugMode) { Debug.Log("Player " + PlayerId + " attempting to move"); }

        //is this the correct player?
        if (theStateManager.CurrentPlayerId != PlayerId)
        {
            if (debugMode) { Debug.Log("Wrong player's turn. Current Player: " + theStateManager.CurrentPlayerId + ", This Player: " + PlayerId); }
            return;
        }

        //Have we rolled Dice?
        if (theStateManager.IsDoneRolling == false)
        {
            if (debugMode) { Debug.Log("Player " + PlayerId + " tried to move before rolling"); }
            return;
        }

        if (theStateManager.IsDoneClicking == true)
        {
            if (debugMode) { Debug.Log("Player " + PlayerId + " already moved this turn"); }
            return;
        }

        int spacesToMove = theStateManager.DiceTotal;
        if (debugMode) { Debug.Log("Player " + PlayerId + " attempting to move " + spacesToMove + " spaces"); }

        if (spacesToMove == 0)
        {
            if (debugMode) { Debug.Log("No spaces to move!"); }
            return;
        }

        moveQueue = new Tiles[spacesToMove];
        Tiles finalTile = currentTile;

        for (int i = 0; i < spacesToMove; i++)
        {
            if (finalTile == null)
            {
                finalTile = StartingTiles;
            }
            else
            {
                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    finalTile = null;
                }
                else if (finalTile.NextTiles.Length > 1)
                {
                    finalTile = finalTile.NextTiles[0];
                }
                else
                {
                    finalTile = finalTile.NextTiles[0];
                }
            }
            moveQueue[i] = finalTile;
        }

        moveQueueIndex = 0;
        currentTile = finalTile;
        theStateManager.IsDoneClicking = true;
        isAnimating = true;
    }

    public void StartMove(int spacesToMove)
    {
        if (theStateManager.CurrentPlayerId != PlayerId) return;
        if (theStateManager.IsDoneClicking) return;

        Debug.Log($"Player {PlayerId}: Starting move of {spacesToMove} spaces from tile {currentTile?.name ?? "null"}");

        // Initialize the move queue with the proper size
        moveQueue = new Tiles[spacesToMove];
        Tiles finalTile = currentTile;
        previousTile = currentTile;
        previousProcessedTile = currentTile;  // Start with current tile as the previous

        // Build the path one tile at a time
        for (int i = 0; i < spacesToMove; i++)
        {
            if (finalTile == null)
            {
                Debug.LogWarning($"Player {PlayerId}: finalTile is null at step {i}, using StartingTiles");
                finalTile = StartingTiles;
            }
            else
            {
                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    Debug.LogError($"Player {PlayerId}: finalTile has no NextTiles at step {i}");
                    finalTile = null;
                }
                else if (finalTile.NextTiles.Length > 1)
                {
                    // When there are multiple paths, always take the first for now
                    Debug.Log($"Player {PlayerId}: Multiple paths available at step {i}, taking first path");
                    finalTile = finalTile.NextTiles[0];
                }
                else
                {
                    finalTile = finalTile.NextTiles[0];
                }
            }

            moveQueue[i] = finalTile;
            Debug.Log($"Player {PlayerId}: Step {i} - Moving to tile {finalTile?.name ?? "null"}");
        }

        // Reset movement queue tracking
        moveQueueIndex = 0;
        theStateManager.IsDoneClicking = true;
        isAnimating = true;

        // Don't update currentTile here - wait until we actually move
    }
}