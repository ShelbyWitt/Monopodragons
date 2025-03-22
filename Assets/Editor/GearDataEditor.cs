//GearDataEditor.cs

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(GearData))]
public class GearDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Add a button for auto-populating
        if (GUILayout.Button("Auto-Populate Gears"))
        {
            AutoPopulateGears();
        }
    }

    private void AutoPopulateGears()
    {
        // Find an instance of GearProperties in the scene
        GearProperties gp = Object.FindFirstObjectByType<GearProperties>();
        if (gp == null)
        {
            Debug.LogError("No GearProperties instance found in the scene! Please add one.");
            return;
        }

        // Use reflection to get all public instance fields of type Gear
        FieldInfo[] fields = typeof(GearProperties)
            .GetFields(BindingFlags.Instance | BindingFlags.Public);

        // Filter fields to only include those of type Gear and get their values
        var gears = fields
            .Where(f => f.FieldType == typeof(Gear))
            .Select(f => f.GetValue(gp) as Gear)
            .Where(g => g != null) // Exclude unassigned fields
            .ToArray();

        // Assign the array to the GearData asset
        GearData gearData = (GearData)target;
        gearData.gears = gears;
        EditorUtility.SetDirty(gearData); // Mark the asset as modified
        Debug.Log("Auto-populated GearData with " + gears.Length + " gears.");
    }
}