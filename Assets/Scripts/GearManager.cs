//GearManager.cs

using UnityEngine;
using System.Collections.Generic;

public class GearManager : MonoBehaviour
{
    // Dictionary to hold equipped gear by slot
    private Dictionary<string, Gear> equippedGear = new Dictionary<string, Gear>();

    // Method to equip gear
    public void EquipGear(Gear gear)
    {
        if (equippedGear.ContainsKey(gear.slotType))
        {
            // Unequip existing gear in the slot (optional swapping logic can be added)
            Debug.Log($"Unequipping {equippedGear[gear.slotType].gearName} from {gear.slotType} slot.");
        }
        equippedGear[gear.slotType] = gear;
        Debug.Log($"Equipped {gear.gearName} to {gear.slotType} slot.");
    }

    // Method to get stats of equipped gear in a specific slot
    public HeldItemStats GetEquippedGearStats(string slot)
    {
        if (equippedGear.TryGetValue(slot, out Gear gear))
        {
            return gear.stats;
        }
        return null; // No gear in this slot
    }

    // Method to get total stats from all equipped gear
    public HeldItemStats GetTotalEquippedStats()
    {
        HeldItemStats totalStats = new HeldItemStats();
        foreach (var gear in equippedGear.Values)
        {
            // Add up all stats (assuming additive effects)
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

            // Status effects could be handled differently (e.g., any true value sets it true)
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