//MedalDataEditor.cs


using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
using MedalSystem;

[CustomEditor(typeof(MedalData))]
public class MedalDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default Inspector fields (data sources and subcategory lists)
        DrawDefaultInspector();

        // Add the "Auto-Populate Subcategories" button
        if (GUILayout.Button("Auto-Populate Subcategories"))
        {
            AutoPopulateSubcategories();
        }

        // Add the new "Auto-Populate Medals" button
        if (GUILayout.Button("Auto-Populate Medals From Templates"))
        {
            AutoPopulateMedalsFromTemplates();
        }
    }

    private void AutoPopulateSubcategories()
    {
        MedalData medalData = (MedalData)target;

        // Clear existing subcategories (optional, remove if you want to append instead)
        medalData.raceSubcategories.Clear();
        medalData.classSubcategories.Clear();
        medalData.gearSubcategories.Clear();
        medalData.weaponSubcategories.Clear();
        medalData.petSubcategories.Clear();
        medalData.masterySubcategories.Clear();

        // Populate Race subcategories
        if (medalData.raceData != null && medalData.raceData.races != null)
        {
            foreach (var race in medalData.raceData.races)
            {
                medalData.raceSubcategories.Add(new MedalSubcategory { subcategoryName = race.raceName });
                Debug.Log($"Added Race subcategory: {race.raceName}");
            }
        }
        else
        {
            Debug.LogWarning("RaceData is not assigned or has no races defined.");
        }

        // Populate Class subcategories
        if (medalData.classData != null && medalData.classData.classes != null)
        {
            foreach (var classProp in medalData.classData.classes)
            {
                medalData.classSubcategories.Add(new MedalSubcategory { subcategoryName = classProp.className });
                Debug.Log($"Added Class subcategory: {classProp.className}");
            }
        }
        else
        {
            Debug.LogWarning("ClassData is not assigned or has no classes defined.");
        }

        // Populate Pet subcategories
        if (medalData.petDatabase != null && medalData.petDatabase.pets != null)
        {
            foreach (var pet in medalData.petDatabase.pets)
            {
                medalData.petSubcategories.Add(new MedalSubcategory { subcategoryName = pet.petName });
                Debug.Log($"Added Pet subcategory: {pet.petName}");
            }
        }
        else
        {
            Debug.LogWarning("PetDatabase is not assigned or has no pets defined.");
        }

        // Populate Gear subcategories (non-weapon gear types)
        if (medalData.gearData != null && medalData.gearData.gears != null)
        {
            var gearTypes = medalData.gearData.gears
             //   .Where(g => g.gearTypes != Gear.GearTypes.HeldItem)
                .Select(g => g.gearTypes.ToString())
                .Distinct();
            foreach (var gearType in gearTypes)
            {
                medalData.gearSubcategories.Add(new MedalSubcategory { subcategoryName = gearType });
                Debug.Log($"Added Gear subcategory: {gearType}");
            }
        }
        else
        {
            Debug.LogWarning("GearData is not assigned or has no gears defined.");
        }

        // Populate Weapon subcategories (individual held items)
        if (medalData.gearData != null && medalData.gearData.gears != null)
        {
            var heldItems = medalData.gearData.gears
          //      .Where(g => g.gearTypes == Gear.GearTypes.HeldItem)
                .Select(g => g.gearName);
            foreach (var heldItemName in heldItems)
            {
                medalData.weaponSubcategories.Add(new MedalSubcategory { subcategoryName = heldItemName });
                Debug.Log($"Added Weapon subcategory: {heldItemName}");
            }
        }
        else
        {
            Debug.LogWarning("GearData is not assigned or has no gears defined for weapons.");
        }

        // Optional: Populate Mastery subcategories
        // Add your MasteryData source here if applicable
        // Example:
        // if (medalData.masteryData != null && medalData.masteryData.categories != null)
        // {
        //     foreach (var category in medalData.masteryData.categories)
        //     {
        //         medalData.masterySubcategories.Add(new MedalSubcategory { subcategoryName = category.categoryName });
        //         Debug.Log($"Added Mastery subcategory: {category.categoryName}");
        //     }
        // }
        // else
        // {
        //     Debug.LogWarning("MasteryData is not assigned or has no categories defined.");
        // }

        // Mark the asset as dirty to save changes
        EditorUtility.SetDirty(medalData);
        Debug.Log("Auto-population of subcategories completed.");
    }

    private void AutoPopulateMedalsFromTemplates()
    {
        MedalData medalData = (MedalData)target;

        // Process race medals using Human as template
        if (medalData.raceSubcategories != null && medalData.raceSubcategories.Count > 0)
        {
            PopulateCategoryFromTemplate(medalData.raceSubcategories, "Human");
        }
        else
        {
            Debug.LogWarning("No race subcategories found to populate medals.");
        }

        // Process class medals using Mage as template
        if (medalData.classSubcategories != null && medalData.classSubcategories.Count > 0)
        {
            PopulateCategoryFromTemplate(medalData.classSubcategories, "Mage");
        }
        else
        {
            Debug.LogWarning("No class subcategories found to populate medals.");
        }

        // Process pet medals using first pet as template
        if (medalData.petSubcategories != null && medalData.petSubcategories.Count > 0)
        {
            string templatePet = medalData.petSubcategories[0].subcategoryName;
            PopulateCategoryFromTemplate(medalData.petSubcategories, templatePet);
        }
        else
        {
            Debug.LogWarning("No pet subcategories found to populate medals.");
        }

        // Process weapon medals using first weapon as template
        if (medalData.weaponSubcategories != null && medalData.weaponSubcategories.Count > 0)
        {
            string templateWeapon = medalData.weaponSubcategories[0].subcategoryName;
            PopulateCategoryFromTemplate(medalData.weaponSubcategories, templateWeapon);
        }
        else
        {
            Debug.LogWarning("No weapon subcategories found to populate medals.");
        }

        // Process gear medals using first gear type as template
        if (medalData.gearSubcategories != null && medalData.gearSubcategories.Count > 0)
        {
            string templateGear = medalData.gearSubcategories[0].subcategoryName;
            PopulateCategoryFromTemplate(medalData.gearSubcategories, templateGear);
        }
        else
        {
            Debug.LogWarning("No gear subcategories found to populate medals.");
        }

        // Process mastery medals using first mastery as template
        if (medalData.masterySubcategories != null && medalData.masterySubcategories.Count > 0)
        {
            string templateMastery = medalData.masterySubcategories[0].subcategoryName;
            PopulateCategoryFromTemplate(medalData.masterySubcategories, templateMastery);
        }
        else
        {
            Debug.LogWarning("No mastery subcategories found to populate medals.");
        }

        // Mark the asset as dirty to save changes
        EditorUtility.SetDirty(medalData);
        Debug.Log("Auto-population of medals from templates completed.");
    }

    private void PopulateCategoryFromTemplate(List<MedalSubcategory> subcategories, string templateName)
    {
        // Find the template subcategory (Human, Mage, etc.)
        MedalSubcategory templateSubcategory = subcategories.FirstOrDefault(s => s.subcategoryName == templateName);

        if (templateSubcategory == null || templateSubcategory.medals == null || templateSubcategory.medals.Count == 0)
        {
            Debug.LogWarning($"No template medals found for {templateName}. Please create medals for {templateName} first.");
            return;
        }

        // Apply template medals to all other subcategories
        foreach (var subcategory in subcategories)
        {
            // Skip the template subcategory
            if (subcategory.subcategoryName == templateName)
                continue;

            // Clear existing medals if any (optional - remove if you want to preserve existing)
            subcategory.medals.Clear();

            // Clone and modify each medal from the template
            foreach (var templateMedal in templateSubcategory.medals)
            {
                Medal newMedal = CloneMedalWithNameReplaced(templateMedal, templateName, subcategory.subcategoryName);
                subcategory.medals.Add(newMedal);
            }

            Debug.Log($"Created {subcategory.medals.Count} medals for {subcategory.subcategoryName} based on {templateName} template.");
        }
    }

    private Medal CloneMedalWithNameReplaced(Medal templateMedal, string templateName, string newName)
    {
        Medal newMedal = new Medal();

        // Copy basic properties
        newMedal.medalName = ReplaceNameInString(templateMedal.medalName, templateName, newName);
        newMedal.medalReqDescription = ReplaceNameInString(templateMedal.medalReqDescription, templateName, newName);
        newMedal.medalTagline = ReplaceNameInString(templateMedal.medalTagline, templateName, newName);
        newMedal.hasUnlocked = templateMedal.hasUnlocked;
        newMedal.isHiddenMedal = templateMedal.isHiddenMedal;
        newMedal.unlockPercentage = templateMedal.unlockPercentage;
        newMedal.XPUnlocked = templateMedal.XPUnlocked;

        // Clone requirements
        foreach (var req in templateMedal.medalRequirements)
        {
            MedalRequirement newReq = new MedalRequirement(
                req.requirementType,
                req.amount,
                req.gameLimit,
                req.turnLimit,
                ReplaceNameInString(req.type, templateName, newName)
            );
            newMedal.medalRequirements.Add(newReq);
        }

        return newMedal;
    }

    private string ReplaceNameInString(string input, string oldName, string newName)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Replace the name in all possible combinations (case sensitive)
        return input
            .Replace(oldName, newName)                          // Direct replacement
            .Replace(oldName.ToLower(), newName.ToLower())      // All lowercase
            .Replace(oldName.ToUpper(), newName.ToUpper());     // All uppercase
    }
}

