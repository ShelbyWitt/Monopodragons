//Pet.cs

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public PetData petData;
    public int level = 1;
    public PetStats currentStats;

    void Start()
    {
        LoadPetData();
        CalculateCurrentStats();
    }

    void CalculateCurrentStats()
    {
        currentStats = new PetStats();
        // Copy base stats and apply level growth
        currentStats.MaxHealth = petData.baseStats.MaxHealth + (level - 1) * petData.growth.HealthGrowthPerLevel;
        currentStats.Health = currentStats.MaxHealth; // Start with full health
        currentStats.MaxMana = petData.baseStats.MaxMana + (level - 1) * petData.growth.ManaGrowthPerLevel;
        currentStats.Mana = currentStats.MaxMana; // Start with full mana
        // Copy other stats and apply growth as needed
        currentStats.Strength = petData.baseStats.Strength + (level - 1) * petData.growth.StrengthGrowthPerLevel;
        // ... similarly for other stats
    }

    public void LevelUp()
    {
        level++;
        CalculateCurrentStats();
    }

    public void SavePetData()
    {
        string json = JsonUtility.ToJson(currentStats);
        PlayerPrefs.SetString("Pet_" + gameObject.name + "_Stats", json);
        PlayerPrefs.SetInt("Pet_" + gameObject.name + "_Level", level);
        PlayerPrefs.Save();
    }

    public void LoadPetData()
    {
        string json = PlayerPrefs.GetString("Pet_" + gameObject.name + "_Stats", "");
        if (!string.IsNullOrEmpty(json))
        {
            currentStats = JsonUtility.FromJson<PetStats>(json);
        }
        else
        {
            CalculateCurrentStats();
        }
        level = PlayerPrefs.GetInt("Pet_" + gameObject.name + "_Level", 1);
    }
}