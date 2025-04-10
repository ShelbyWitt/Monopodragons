//MasteryDataEditor.cs


using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(MasteryData))]
public class MasteryDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector (shows all fields)
        DrawDefaultInspector();

        // Add the "Auto-Populate Subcategories" button
        if (GUILayout.Button("Auto-Populate Subcategories"))
        {
            AutoPopulateSubcategories();
        }
    }

    private void AutoPopulateSubcategories()
    {
        MasteryData masteryData = (MasteryData)target;

        // Populate Race subcategories
        if (masteryData.raceData != null && masteryData.raceData.races != null)
        {
            foreach (var race in masteryData.raceData.races)
            {
                if (!masteryData.raceSubcategories.Any(sc => sc.subcategoryName == race.raceName))
                {
                    masteryData.raceSubcategories.Add(new MasterySubcategory { subcategoryName = race.raceName });
                    Debug.Log($"Added Race subcategory: {race.raceName}");
                }
            }
        }
        else
        {
            Debug.LogWarning("RaceData is not assigned or has no races defined.");
        }

        // Populate Class subcategories
        if (masteryData.classData != null && masteryData.classData.classes != null)
        {
            foreach (var classProp in masteryData.classData.classes)
            {
                if (!masteryData.classSubcategories.Any(sc => sc.subcategoryName == classProp.className))
                {
                    masteryData.classSubcategories.Add(new MasterySubcategory { subcategoryName = classProp.className });
                    Debug.Log($"Added Class subcategory: {classProp.className}");
                }
            }
        }
        else
        {
            Debug.LogWarning("ClassData is not assigned or has no classes defined.");
        }

        // Populate Pet subcategories
        if (masteryData.petDatabase != null && masteryData.petDatabase.pets != null)
        {
            foreach (var pet in masteryData.petDatabase.pets)
            {
                if (!masteryData.petSubcategories.Any(sc => sc.subcategoryName == pet.petName))
                {
                    masteryData.petSubcategories.Add(new MasterySubcategory { subcategoryName = pet.petName });
                    Debug.Log($"Added Pet subcategory: {pet.petName}");
                }
            }
        }
        else
        {
            Debug.LogWarning("PetDatabase is not assigned or has no pets defined.");
        }

        // Populate Gear subcategories (assuming GearTypes as subcategories)
        // In MasteryDataEditor.cs, within AutoPopulateSubcategories method
        //    if (masteryData.gearData != null && masteryData.gearData.gears != null)
        //    {
        //        var gearTypes = masteryData.gearData.gears
        //            .Where(g => g.gearTypes != Gear.GearTypes.) // Exclude weapons
        //            .Select(g => g.gearTypes.ToString())
        //            .Distinct();
        //        foreach (var gearType in gearTypes)
        //        {
        //            if (!masteryData.gearSubcategories.Any(sc => sc.subcategoryName == gearType))
        //            {
        //                masteryData.gearSubcategories.Add(new MasterySubcategory { subcategoryName = gearType });
        //                Debug.Log($"Added Gear subcategory: {gearType}");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogWarning("GearData is not assigned or has no gears defined.");
        //    }

        //    // For Weapon and Mastery, define subcategories as needed
        //    // Example: Weapon subcategories could be "Sword", "Bow", etc., if you create a WeaponData
        //    // For now, leave them empty or add manually in the Inspector

        //    if (masteryData.masteryCategoryData != null && masteryData.masteryCategoryData.categories != null)
        //    {
        //        foreach (var category in masteryData.masteryCategoryData.categories)
        //        {
        //            if (!masteryData.masterySubcategories.Any(sc => sc.subcategoryName == category.categoryName))
        //            {
        //                masteryData.masterySubcategories.Add(new MasterySubcategory { subcategoryName = category.categoryName });
        //                Debug.Log($"Added Mastery subcategory: {category.categoryName}");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogWarning("MasteryCategoryData is not assigned or has no categories defined.");
        //    }

        //    // Mark the asset as dirty to save changes
        //    EditorUtility.SetDirty(masteryData);
        //    Debug.Log("Auto-population of subcategories completed.");
        //}
    }
}