//NormalTile.cs
using UnityEngine;

public class NormalTile : TileType
{
    void Awake()
    {
        tileColor = Color.white; // Default white color
    }

    public override void OnPlayerLand(Player player)
    {
        // No effect
    }
}