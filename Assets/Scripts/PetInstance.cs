// PetInstance.cs
using UnityEngine;

[System.Serializable]
public class PetInstance
{
    public PetData petData;
    public int level;
    public PetStats currentStats;

    public PetInstance(PetData data, int initialLevel = 1)
    {
        petData = data;
        level = initialLevel;
        CalculateCurrentStats();
    }

    public void CalculateCurrentStats()
    {
        currentStats = new PetStats
        {
            MaxHealth = petData.baseStats.MaxHealth + (level - 1) * petData.growth.HealthGrowthPerLevel,
            Health = petData.baseStats.MaxHealth + (level - 1) * petData.growth.HealthGrowthPerLevel,
            MaxMana = petData.baseStats.MaxMana + (level - 1) * petData.growth.ManaGrowthPerLevel,
            Mana = petData.baseStats.MaxMana + (level - 1) * petData.growth.ManaGrowthPerLevel,
            Strength = petData.baseStats.Strength + (level - 1) * petData.growth.StrengthGrowthPerLevel
        };
    }

    public void LevelUp()
    {
        level++;
        CalculateCurrentStats();
    }
}