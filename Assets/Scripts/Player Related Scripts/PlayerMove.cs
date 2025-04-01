//PlayerMove.cs
using Unity.Mathematics.Geometry;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
        targetPosition = this.transform.position;
        currentTile = StartingTiles;
    }

    void Update()
    {
        if (!isAnimating) return;

        float currentSmoothTime = smoothTime / Mathf.Pow(theStateManager.DiceTotal - 1, .85f);

        // Handle rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Handle position - same as before
        if (Vector2.Distance(
            new Vector2(this.transform.position.x, this.transform.position.z),
            new Vector2(targetPosition.x, targetPosition.z)) < smoothDistance)
        {
            if (moveQueue != null && moveQueueIndex < moveQueue.Length)
            {
                AdvanceMoveQueue();
            }
            else
            {
                isAnimating = false;
                theStateManager.IsDoneAnimating = true;
            }
        }
        else
        {
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                new Vector3(targetPosition.x, this.transform.position.y, targetPosition.z),
                ref velocity,
                currentSmoothTime);
        }
    }

    void AdvanceMoveQueue()
    {
        if (moveQueue != null && moveQueueIndex < moveQueue.Length)
        {
            Tiles nextTile = moveQueue[moveQueueIndex];
            if (nextTile == null)
            {
                SetNewTargetPosition(this.transform.position + Vector3.right * 10f);
            }
            else
            {
                bool isFinalMove = (moveQueueIndex == moveQueue.Length - 1);

                if (isFinalMove && !nextTile.CanOccupy())
                {
                    nextTile = currentTile;
                    if (debugMode)
                    {
                        Debug.Log("Tile is full! Staying at current tile.");
                    }
                }

                if (currentTile != null)
                {
                    currentTile.RemovePlayer(this);

                    // Only handle rotation if we have a valid previous tile to compare with
                    if (previousProcessedTile != null && nextTile != null)
                    {
                        Vector3 movementDirection = nextTile.transform.position - previousProcessedTile.transform.position;
                        movementDirection.y = 0; // Flatten direction on y-axis

                        if (movementDirection.magnitude > 0.01f)
                        {
                            transform.rotation = Quaternion.LookRotation(movementDirection);
                        }
                    }

                    // Store this tile as previous for next iteration
                    previousProcessedTile = nextTile;
                }
                else
                {
                    // If there's no current tile, just store nextTile as previous
                    previousProcessedTile = nextTile;
                }

                Vector3 tilePos = nextTile.transform.position;
                Vector3 offset = nextTile.GetOffsetPosition();
                SetNewTargetPosition(tilePos + offset);

                nextTile.AddPlayer(this);
                currentTile = nextTile;

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
        }
        else
        {
            if (currentTile != null)
            {
                currentTile.RemovePlayer(this);
            }
            isAnimating = false;
            theStateManager.IsDoneAnimating = true;
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

        moveQueue = new Tiles[spacesToMove];
        Tiles finalTile = currentTile;
        previousTile = currentTile;

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
        previousProcessedTile = currentTile;
    }
}