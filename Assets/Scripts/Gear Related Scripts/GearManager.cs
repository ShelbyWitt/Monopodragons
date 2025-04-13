//GearManager.cs

using UnityEngine;
using System.Collections.Generic;

public class GearManager : MonoBehaviour
{
    private Dictionary<string, Gear> equippedGear = new Dictionary<string, Gear>();

    //public void EquipGear(Gear gear)
    //{
    //    string slot = gear.gearTypes.ToString();
    //    if (equippedGear.ContainsKey(slot))
    //    {
    //        Debug.Log($"Unequipping {equippedGear[slot].gearName} from {slot} slot.");
    //    }
    //    equippedGear[slot] = gear;
    //    Debug.Log($"Equipped {gear.gearName} to {slot} slot.");
    //}

    public GearStats GetEquippedGearStats(string slot)
    {
        if (equippedGear.TryGetValue(slot, out Gear gear))
        {
            return gear.stats;
        }
        return null; // No gear in this slot
    }

    public GearStats GetTotalEquippedStats()
    {
        GearStats totalStats = new GearStats();
        foreach (var gear in equippedGear.Values)
        {
            // Add up all stats
            totalStats.HealthBuff += gear.stats.HealthBuff;
            totalStats.ManaBuff += gear.stats.ManaBuff;
            totalStats.ShieldBuff += gear.stats.ShieldBuff;
            totalStats.StrengthBuff += gear.stats.StrengthBuff;
            totalStats.MagicBuff += gear.stats.MagicBuff;
            totalStats.DefenseBuff += gear.stats.DefenseBuff;
            totalStats.DexterityBuff += gear.stats.DexterityBuff;
            totalStats.AgilityBuff += gear.stats.AgilityBuff;
            totalStats.LuckBuff += gear.stats.LuckBuff;
            totalStats.IntelligenceBuff += gear.stats.IntelligenceBuff;
            totalStats.AllStatsBuff += gear.stats.AllStatsBuff;
            totalStats.StaminaBuff += gear.stats.StaminaBuff;
            totalStats.AttackBuff += gear.stats.AttackBuff;
            totalStats.SpeedBuff += gear.stats.SpeedBuff;
            totalStats.CriticalChanceBuff += gear.stats.CriticalChanceBuff;
            totalStats.CriticalDamageBuff += gear.stats.CriticalDamageBuff;
            totalStats.DodgeChanceBuff += gear.stats.DodgeChanceBuff;
            totalStats.PierceBuff += gear.stats.PierceBuff;
            totalStats.AccuracyBuff += gear.stats.AccuracyBuff;
            totalStats.Gold += gear.stats.Gold;
            totalStats.ExtraDice += gear.stats.ExtraDice;

            // Add resistances
            totalStats.PoisonResistance += gear.stats.PoisonResistance;
            totalStats.FireResistance += gear.stats.FireResistance;
            totalStats.FreezeResistance += gear.stats.FreezeResistance;
            totalStats.ShockResistance += gear.stats.ShockResistance;
            totalStats.CursedResistance += gear.stats.CursedResistance;
            totalStats.BleedResistance += gear.stats.BleedResistance;

            // Status effects (true if any gear applies it)
            totalStats.isPoisoned |= gear.stats.isPoisoned;
            totalStats.isOnFire |= gear.stats.isOnFire;
            totalStats.isFrozen |= gear.stats.isFrozen;
            totalStats.isShocked |= gear.stats.isShocked;
            totalStats.isCursed |= gear.stats.isCursed;
            totalStats.isBleeding |= gear.stats.isBleeding;
            totalStats.PoisonedAmount += gear.stats.PoisonedAmount;
            totalStats.FireAmount += gear.stats.FireAmount;
            totalStats.FrozenAmount += gear.stats.FrozenAmount;
            totalStats.ShockedAmount += gear.stats.ShockedAmount;
            totalStats.CursedAmount += gear.stats.CursedAmount;
            totalStats.BleedAmount += gear.stats.BleedAmount;
        }
        return totalStats;
    }
}