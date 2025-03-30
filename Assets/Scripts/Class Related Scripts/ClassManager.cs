//ClassManager.cs


using UnityEngine;
using System.Collections.Generic;

public class ClassManager : MonoBehaviour
{
    [SerializeField]
    private ClassData classData; // Reference to the ClassData ScriptableObject

    private StateManager theStateManager;
    private Player player; // Retained, assuming it’s used elsewhere

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        if (classData == null)
        {
            Debug.LogError("ClassData is not assigned in ClassManager! Please assign it in the Inspector.");
        }
    }

    public PlayerProperties GetClassProperties(string className)
    {
        if (classData == null || classData.classes == null)
        {
            Debug.LogError("ClassData is null or not properly initialized!");
            return null;
        }

        foreach (var classProp in classData.classes)
        {
            if (classProp.className == className)
            {
                return classProp.properties;
            }
        }

        Debug.LogWarning($"Class '{className}' not found in ClassData. Returning Warrior properties as default.");
        foreach (var classProp in classData.classes)
        {
            if (classProp.className == "Warrior")
            {
                return classProp.properties;
            }
        }

        Debug.LogError("Warrior class not found in ClassData as a fallback!");
        return null;
    }

    public List<string> GetClassNames()
    {
        if (classData == null || classData.classes == null)
        {
            Debug.LogError("ClassData is null or not properly initialized!");
            return new List<string>();
        }

        List<string> classNames = new List<string>();
        foreach (var classProp in classData.classes)
        {
            classNames.Add(classProp.className);
        }
        return classNames;
    }

    void Update()
    {
        // Empty, retained for consistency with original code
    }
}