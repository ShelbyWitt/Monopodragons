//Tiles.cs
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Tiles[] NextTiles;

    bool debugMode = false;

    private List<PlayerMove> occupyingPlayers = new List<PlayerMove>();
    public const int MAX_OCCUPANTS = 4;

    // Returns true if the player can occupy this tile
    public bool CanOccupy()
    {
        return occupyingPlayers.Count < MAX_OCCUPANTS;
    }

    // Returns position offset based on current occupants and rotation
    public Vector3 GetOffsetPosition()
    {
        float yRotation = transform.rotation.eulerAngles.y;
        int position = occupyingPlayers.Count;

        // For 0 rotation (pieces spread along X axis)
        if (Mathf.Approximately(yRotation, 0))
        {
            switch (position)
            {
                case 0: return Vector3.zero;
                case 1: return new Vector3(1f, 0, 0);
                case 2: return new Vector3(-1f, 0, 0);
                case 3: return new Vector3(2f, 0, 0);
                default: return Vector3.zero;
            }
        }
        // For 90 rotation (pieces spread along Z axis)
        else if (Mathf.Approximately(yRotation, 90))
        {
            switch (position)
            {
                case 0: return Vector3.zero;
                case 1: return new Vector3(0, 0, 1f);
                case 2: return new Vector3(0, 0, -1f);
                case 3: return new Vector3(0, 0, -2f);
                default: return Vector3.zero;
            }
        }
        // For 180 rotation (pieces spread along negative X axis)
        else if (Mathf.Approximately(yRotation, 180))
        {
            switch (position)
            {
                case 0: return Vector3.zero;
                case 1: return new Vector3(-1f, 0, 0);
                case 2: return new Vector3(1f, 0, 0);
                case 3: return new Vector3(-2f, 0, 0);
                default: return Vector3.zero;
            }
        }
        // For 270 rotation (pieces spread along negative Z axis)
        else if (Mathf.Approximately(yRotation, 270))
        {
            switch (position)
            {
                case 0: return Vector3.zero;
                case 1: return new Vector3(0, 0, -1f);
                case 2: return new Vector3(0, 0, 1f);
                case 3: return new Vector3(0, 0, 1f);
                default: return Vector3.zero;
            }
        }

        return Vector3.zero; // Default return if no rotation matches
    }


    public int GetOccupantCount()
    {
        return occupyingPlayers.Count;
    }

    public void RemovePlayer(PlayerMove player)
    {
        if (occupyingPlayers.Contains(player))
        {
            occupyingPlayers.Remove(player);
            if (debugMode)
            {
                Debug.Log($"Player {player.PlayerId} removed from tile. Remaining occupants: {occupyingPlayers.Count}");
            }
        }
    }

    public void AddPlayer(PlayerMove player)
    {
        if (!occupyingPlayers.Contains(player))
        {
            occupyingPlayers.Add(player);
            if (debugMode)
            {
                Debug.Log($"Player {player.PlayerId} added to tile. Total occupants: {occupyingPlayers.Count}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
