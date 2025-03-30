//ManaModifierTile.cs
using UnityEngine;

public class ManaModifierTile : TileType
{
    void Awake()
    {
        tileColor = new Color(0.2f, 0.2f, 0.8f); // Blue
    }

    public int manaAmount = -20; // Can be positive for gain or negative for loss

    public override void OnPlayerLand(Player player)
    {
        player.ModifyMana(manaAmount);
        Debug.Log($"Player {(manaAmount > 0 ? "gained" : "lost")} {Mathf.Abs(manaAmount)} mana");
    }
}

