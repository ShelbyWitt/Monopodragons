//MedalManager.cs

using UnityEngine;
using System.Collections.Generic;

public enum medalType { Race, Class, Gear, Weapon, Pet, Mastery }

public class MedalManager : MonoBehaviour
{
    [SerializeField] private MedalData medalData; // Assign in Inspector

    private Dictionary<medalType, List<Medal>> medalsByType = new Dictionary<medalType, List<Medal>>();
    private Dictionary<Medal.RequirementType, int> stats = new Dictionary<Medal.RequirementType, int>();

    private void Start()
    {
        if (medalData != null)
        {
            // Populate the dictionary from MedalData
            medalsByType[medalType.Race] = medalData.raceMedals;
            medalsByType[medalType.Class] = medalData.classMedals;
            medalsByType[medalType.Gear] = medalData.gearMedals;
            medalsByType[medalType.Weapon] = medalData.weaponMedals;
            medalsByType[medalType.Pet] = medalData.petMedals;
            medalsByType[medalType.Mastery] = medalData.masteryMedals;
        }
        else
        {
            Debug.LogWarning("MedalData not assigned in MedalManager.");
        }

        // Simulate some stats for testing
        stats[Medal.RequirementType.Kill_Enemy] = 5;
        stats[Medal.RequirementType.Win_With] = 2;

        UpdateMedalStatuses();
    }

    public void UpdateMedalStatuses()
    {
        foreach (var category in medalsByType)
        {
            foreach (var medal in category.Value)
            {
                float progress = GetMedalProgress(medal);
                medal.unlockPercentage = progress;
                if (progress >= 1f && !medal.hasUnlocked)
                {
                    medal.hasUnlocked = true;
                    Debug.Log($"{medal.medalName} unlocked!");
                }
            }
        }
    }

    public float GetMedalProgress(Medal medal)
    {
        if (medal.medalRequirements.Count == 0)
            return 1f;

        float minProgress = 1f;
        foreach (var req in medal.medalRequirements)
        {
            int current = GetStat(req.requirementType);
            float progress = (float)current / req.amount;
            if (progress < minProgress)
                minProgress = progress;
        }
        return Mathf.Clamp01(minProgress);
    }

    private int GetStat(Medal.RequirementType reqType)
    {
        return stats.ContainsKey(reqType) ? stats[reqType] : 0;
    }

    // Example method to display medals
    public void DisplayMedals()
    {
        foreach (var category in medalsByType)
        {
            Debug.Log($"Category: {category.Key}");
            foreach (var medal in category.Value)
            {
                Debug.Log($"- {medal.medalName}: {medal.unlockPercentage * 100}% ({(medal.hasUnlocked ? "Unlocked" : "Locked")})");
            }
        }
    }
}