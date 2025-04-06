//MasteryManager.cs


using UnityEngine;
using System.Collections.Generic;

public enum masteryType { Race, Class, Gear, Weapon, Pet, Mastery }

public class MasteryManager : MonoBehaviour
{
    [SerializeField] private MasteryData masteryData;

    // Nested dictionary: masteryType -> subcategoryName -> List<Mastery>
    private Dictionary<masteryType, Dictionary<string, List<Mastery>>> masteryByTypeAndSubcategory = new Dictionary<masteryType, Dictionary<string, List<Mastery>>>();
    private Dictionary<Mastery.RequirementType, int> stats = new Dictionary<Mastery.RequirementType, int>();

    private void Start()
    {
        if (masteryData != null)
        {
            // Initialize the nested dictionary
            masteryByTypeAndSubcategory[masteryType.Race] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.raceSubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Race][subcategory.subcategoryName] = subcategory.masteries;
            }

            masteryByTypeAndSubcategory[masteryType.Class] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.classSubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Class][subcategory.subcategoryName] = subcategory.masteries;
            }

            masteryByTypeAndSubcategory[masteryType.Gear] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.gearSubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Gear][subcategory.subcategoryName] = subcategory.masteries;
            }

            masteryByTypeAndSubcategory[masteryType.Weapon] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.weaponSubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Weapon][subcategory.subcategoryName] = subcategory.masteries;
            }

            masteryByTypeAndSubcategory[masteryType.Pet] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.petSubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Pet][subcategory.subcategoryName] = subcategory.masteries;
            }

            masteryByTypeAndSubcategory[masteryType.Mastery] = new Dictionary<string, List<Mastery>>();
            foreach (var subcategory in masteryData.masterySubcategories)
            {
                masteryByTypeAndSubcategory[masteryType.Mastery][subcategory.subcategoryName] = subcategory.masteries;
            }
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
        foreach (var type in masteryByTypeAndSubcategory)
        {
            foreach (var subcategory in type.Value)
            {
                foreach (var mastery in subcategory.Value)
                {
                    float progress = GetMasteryProgress(mastery);
                    mastery.unlockPercentage = progress;
                    if (progress >= 1f && !mastery.hasUnlocked)
                    {
                        mastery.hasUnlocked = true;
                        Debug.Log($"{mastery.masteryName} unlocked in {type.Key}/{subcategory.Key}!");
                    }
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

    public void DisplayMasteries()
    {
        foreach (var type in masteryByTypeAndSubcategory)
        {
            Debug.Log($"Type: {type.Key}");
            foreach (var subcategory in type.Value)
            {
                Debug.Log($"  Subcategory: {subcategory.Key}");
                foreach (var mastery in subcategory.Value)
                {
                    Debug.Log($"    - {mastery.masteryName}: {mastery.unlockPercentage * 100}% ({(mastery.hasUnlocked ? "Unlocked" : "Locked")})");
                }
            }
        }
    }
}