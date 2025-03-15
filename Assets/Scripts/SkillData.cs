//SkillData.cs

using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillData", menuName = "Game/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    // This field must exist so that our SkillManager can read the categories.
    public List<SkillCategory> categories;
}

[System.Serializable]
public class SkillCategory
{
    public string categoryName;
    public List<Skill> skills;
}