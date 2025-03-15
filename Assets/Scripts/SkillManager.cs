//SkillManager.cs

using UnityEngine;
using System.Collections.Generic;

[ExecuteAlways]
public class SkillManager : MonoBehaviour
{
    [SerializeField]
    private SkillData skillData; // Assign your SkillData asset in the Inspector

    // Returns a list of all category names stored in SkillData.
    public List<string> GetCategoryNames()
    {
        List<string> categoryNames = new List<string>();
        if (skillData != null && skillData.categories != null)
        {
            foreach (var category in skillData.categories)
            {
                categoryNames.Add(category.categoryName);
            }
        }
        else
        {
            Debug.LogWarning("SkillData or its categories are not assigned.");
        }
        return categoryNames;
    }

    // Returns the list of skills for a given category name.
    public List<Skill> GetSkillsForCategory(string categoryName)
    {
        if (skillData != null && skillData.categories != null)
        {
            foreach (var category in skillData.categories)
            {
                if (category.categoryName == categoryName)
                {
                    return category.skills;
                }
            }
            Debug.LogWarning($"Category '{categoryName}' not found in SkillData.");
        }
        else
        {
            Debug.LogWarning("SkillData or its categories are not assigned.");
        }
        return new List<Skill>();
    }

    // Optionally, returns a list of all skills across all categories.
    public List<Skill> GetAllSkills()
    {
        List<Skill> allSkills = new List<Skill>();
        if (skillData != null && skillData.categories != null)
        {
            foreach (var category in skillData.categories)
            {
                allSkills.AddRange(category.skills);
            }
        }
        else
        {
            Debug.LogWarning("SkillData or its categories are not assigned.");
        }
        return allSkills;
    }
}