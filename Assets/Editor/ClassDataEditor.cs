// ClassDataEditor.cs
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

[CustomEditor(typeof(ClassData))]
public class ClassDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Add a button for auto-populating
        if (GUILayout.Button("Auto-Populate Classes"))
        {
            AutoPopulateClasses();
        }
    }

    private void AutoPopulateClasses()
    {
        // Find an instance of ClassProperties in the scene.
        ClassProperties cp = Object.FindFirstObjectByType<ClassProperties>();
        if (cp == null)
        {
            Debug.LogError("No ClassProperties instance found in the scene! Please add one.");
            return;
        }

        // Use reflection to get all public instance fields of type PlayerProperties.
        FieldInfo[] fields = typeof(ClassProperties)
            .GetFields(BindingFlags.Instance | BindingFlags.Public);

        // Filter and create ClassProperty entries.
        var classList = fields
            .Where(f => f.FieldType == typeof(PlayerProperties))
            .Select(f =>
            {
                // Derive a class name from the field name.
                string name = f.Name;
                if (name.EndsWith("ClassProperties"))
                    name = name.Substring(0, name.Length - "ClassProperties".Length);
                PlayerProperties props = f.GetValue(cp) as PlayerProperties;
                return new ClassProperty { className = name, properties = props };
            })
            .ToArray();

        // Assign the array to your ClassData asset.
        ClassData classData = (ClassData)target;
        classData.classes = classList;
        EditorUtility.SetDirty(classData);
        Debug.Log("Auto-populated ClassData with " + classList.Length + " classes.");
    }
}