//MasteryManager.cs


using UnityEngine;
using System.Collections.Generic;

public enum masteryType { Race, Class, Gear, Weapon, Pet, Mastery }

public class MasteryManager : MonoBehaviour
{
    [SerializeField] private MasteryData masteryData; // Assign in Inspector

    private Dictionary<masteryType, List<Mastery>> masteryByType = new Dictionary<masteryType, List<Mastery>>();
    private Dictionary<Mastery.RequirementType, int> stats = new Dictionary<Mastery.RequirementType, int>();

    private void Start()
    {
        if (masteryData != null)
        {
            // Populate the dictionary from MedalData
            masteryByType[masteryType.Race] = masteryData.raceMasteries;
            masteryByType[masteryType.Class] = masteryData.classMasteries;
            masteryByType[masteryType.Gear] = masteryData.gearMasteries;
            masteryByType[masteryType.Weapon] = masteryData.weaponMasteries;
            masteryByType[masteryType.Pet] = masteryData.petMasteries;
            masteryByType[masteryType.Mastery] = masteryData.masteryMasteries;
        }
        else
        {
            Debug.LogWarning("MasteryData not assigned in MasteryManager.");
        }

        // Simulate some stats for testing
        stats[Mastery.RequirementType.Kill_Enemy] = 5;
        stats[Mastery.RequirementType.Win_With] = 2;

        UpdateMasteryStatuses();
    }

    public void UpdateMasteryStatuses()
    {
        foreach (var category in masteryByType)
        {
            foreach (var mastery in category.Value)
            {
                float progress = GetMasteryProgress(mastery);
                mastery.unlockPercentage = progress;
                if (progress >= 1f && !mastery.hasUnlocked)
                {
                    mastery.hasUnlocked = true;
                    Debug.Log($"{mastery.masteryName} unlocked!");
                }
            }
        }
    }

    public float GetMasteryProgress(Mastery mastery)
    {
        if (mastery.masteryRequirements.Count == 0)
            return 1f;

        float minProgress = 1f;
        foreach (var req in mastery.masteryRequirements)
        {
            int current = GetStat(req.requirementType);
            float progress = (float)current / req.amount;
            if (progress < minProgress)
                minProgress = progress;
        }
        return Mathf.Clamp01(minProgress);
    }

    private int GetStat(Mastery.RequirementType reqType)
    {
        return stats.ContainsKey(reqType) ? stats[reqType] : 0;
    }

    // Example method to display medals
    public void DisplayMasteries()
    {
        foreach (var category in masteryByType)
        {
            Debug.Log($"Category: {category.Key}");
            foreach (var mastery in category.Value)
            {
                Debug.Log($"- {mastery.masteryName}: {mastery.unlockPercentage * 100}% ({(mastery.hasUnlocked ? "Unlocked" : "Locked")})");
            }
        }
    }
}