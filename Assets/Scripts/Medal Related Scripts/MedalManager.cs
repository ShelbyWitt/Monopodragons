//MedalManager.cs

using UnityEngine;
using System.Collections.Generic;
using MedalSystem;

public class MedalManager
{
    private MedalData medalData;

    public MedalManager(MedalData data)
    {
        medalData = data;
    }

    public void UpdateMedalStatuses()
    {
        if (medalData == null) return;

        foreach (var subcategory in medalData.raceSubcategories)
        {
            foreach (var medal in subcategory.medals) // MedalSystem.Medal
            {
              //  if (!medal.hasUnlocked && AreMedalRequirementsMet(medal, subcategory.subcategoryName))
              //  {
                    medal.hasUnlocked = true;
                    Debug.Log($"{medal.medalName} unlocked for {subcategory.subcategoryName}!");
              //  }
            }
        }
    }

    //private bool AreMedalRequirementsMet(Medal medal, string subcategory)
    //{
    //    foreach (var req in medal.requirements) // Accesses MedalSystem.Medal.requirements
    //    {
    //        if (!CheckRequirement(req, subcategory))
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    //private bool CheckRequirement(MedalRequirement req, string subcategory)
    //{
    //    switch (req.requirementType) // MedalSystem.RequirementType
    //    {
    //        case RequirementType.Play_With:
    //            int playCount = GetPlayCountForSubcategory(subcategory);
    //            return playCount >= req.amount;
    //        default:
    //            return false;
    //    }
    //}

    private int GetPlayCountForSubcategory(string subcategory)
    {
        return PlayerStats.Instance?.GetPlayCount(subcategory) ?? 0; // Adjust based on your PlayerStats implementation
    }
}