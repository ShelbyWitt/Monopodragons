// GoldTile.cs
using UnityEngine;

public class GoldTile : TileType
{
    void Awake()
    {
        tileColor = new Color(0.8f, 0.8f, 0.2f); // Yellow
    }

    public int maxGoldAmount = 50;

    public override void OnPlayerLand(Player player)
    {
        int goldAmount = Random.Range(1, maxGoldAmount + 1);
        player.ModifyGold(goldAmount);
    }
}