//SkillDataEditor.cs

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

[CustomEditor(typeof(SkillData))]
public class SkillDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Auto-Populate Skills"))
        {
            AutoPopulateSkills();
        }
    }

    private void AutoPopulateSkills()
    {
        SkillData skillData = (SkillData)target;

        // Find the SkillGenerator in the scene.
        SkillGenerator sg = GameObject.FindObjectOfType<SkillGenerator>();
        if (sg == null)
        {
            Debug.LogError("No SkillGenerator found in the scene! Please add one.");
            return;
        }

        List<SkillCategory> categories = new List<SkillCategory>();

        // Process raceSignatureSkills
        if (sg.raceSignatureSkills != null)
        {
            foreach (KeyValuePair<string, List<Skill>> kvp in sg.raceSignatureSkills)
            {
                SkillCategory cat = new SkillCategory();
                cat.categoryName = FormatName(kvp.Key);
                cat.skills = kvp.Value;
                categories.Add(cat);
            }
        }

        // Process classSignatureSkills
        if (sg.classSignatureSkills != null)
        {
            foreach (KeyValuePair<string, List<Skill>> kvp in sg.classSignatureSkills)
            {
                SkillCategory cat = new SkillCategory();
                cat.categoryName = FormatName(kvp.Key);
                cat.skills = kvp.Value;
                categories.Add(cat);
            }
        }

        // Process raceAndClassSignatureSkills
        if (sg.raceAndClassSignatureSkills != null)
        {
            foreach (KeyValuePair<string, List<Skill>> kvp in sg.raceAndClassSignatureSkills)
            {
                SkillCategory cat = new SkillCategory();
                cat.categoryName = FormatName(kvp.Key);
                cat.skills = kvp.Value;
                categories.Add(cat);
            }
        }

        skillData.categories = categories;
        EditorUtility.SetDirty(skillData);
        Debug.Log("Auto-populated SkillData with " + categories.Count + " categories.");
    }

    // Helper method: Inserts spaces before capital letters and then title cases the string.
    private string FormatName(string rawName)
    {
        // Insert a space before every capital letter except the first.
        string spaced = Regex.Replace(rawName, "(?<!^)([A-Z])", " $1");
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(spaced);
    }
}