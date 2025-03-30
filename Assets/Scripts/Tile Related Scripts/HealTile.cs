// HealTile.cs
using UnityEngine;
public class HealTile : TileType
{

    void Awake()
    {
        tileColor = new Color(0.2f, 0.8f, 0.2f); // Green
    }


    public int healAmount = 20;

    public override void OnPlayerLand(Player player)
    {
        player.ModifyHealth(healAmount);
    }
}
