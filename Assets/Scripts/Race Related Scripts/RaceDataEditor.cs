// RaceDataEditor.cs
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

[CustomEditor(typeof(RaceData))]
public class RaceDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Add a button for auto-populating
        if (GUILayout.Button("Auto-Populate Races"))
        {
            AutoPopulateRaces();
        }
    }

    private void AutoPopulateRaces()
    {
        // Find an instance of RaceProperties in the scene.
        RaceProperties cp = Object.FindFirstObjectByType<RaceProperties>();
        if (cp == null)
        {
            Debug.LogError("No RaceProperties instance found in the scene! Please add one.");
            return;
        }

        // Use reflection to get all public instance fields of type PlayerProperties.
        FieldInfo[] fields = typeof(RaceProperties)
            .GetFields(BindingFlags.Instance | BindingFlags.Public);

        // Filter and create RaceProperty entries.
        var raceList = fields
            .Where(f => f.FieldType == typeof(PlayerProperties))
            .Select(f =>
            {
                // Derive a race name from the field name.
                string name = f.Name;
                if (name.EndsWith("Properties"))
                    name = name.Substring(0, name.Length - "Properties".Length);
                // Insert a space before capital letters (except the first letter)
                name = Regex.Replace(name, "(?<!^)([A-Z])", " $1");

                PlayerProperties props = f.GetValue(cp) as PlayerProperties;
                return new RaceProperty { raceName = name, properties = props };
            })
            .ToArray();

        // Assign the array to your RaceData asset.
        RaceData raceData = (RaceData)target;
        raceData.races = raceList;
        EditorUtility.SetDirty(raceData);
        Debug.Log("Auto-populated RaceData with " + raceList.Length + " races.");
    }
}