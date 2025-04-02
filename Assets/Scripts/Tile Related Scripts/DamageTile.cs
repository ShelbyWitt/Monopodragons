// DamageTile.cs
using UnityEngine;

public class DamageTile : TileType
{ 
    void Awake()
    {
        tileColor = new Color(0.8f, 0.2f, 0.2f); // Red
    }

    [SerializeField]
    public int damageAmount;
    

    public override void OnPlayerLand(Player player)
    {
        int reducedDamage = Mathf.RoundToInt(player.CalculateDamageReduction(damageAmount));
        player.ModifyHealth(-reducedDamage);
        Debug.Log($"Player took {reducedDamage} damage (reduced from {damageAmount})");
    }
}