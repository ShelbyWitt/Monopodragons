//PetManager.cs



using UnityEngine;
using System.Collections.Generic;

public class PetManager : MonoBehaviour
{
    [SerializeField]
    private PetData petData; // Reference to the PetData ScriptableObject

    private StateManager theStateManager;
    private Player player; // Retained, assuming it’s used elsewhere

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        if (petData == null)
        {
            Debug.LogError("PetData is not assigned in PetManager! Please assign it in the Inspector.");
        }
    }

    public PetProperties GetPetProperties(string petName)
    {
        if (petData == null || petData.pets == null)
        {
            Debug.LogError("PetData is null or not properly initialized!");
            return null;
        }

        foreach (var petProp in petData.pets)
        {
            if (petProp.petName == petName)
            {
                return petProp.properties;
            }
        }

        Debug.LogWarning($"Pet '{petName}' not found in PetData. Returning ____ properties as default.");
        foreach (var petProp in petData.pets)
        {
            if (petProp.petName == "Warrior")
            {
                return petProp.properties;
            }
        }

        Debug.LogError("Warrior class not found in PetData as a fallback!");
        return null;
    }

    public List<string> GetPetNames()
    {
        if (petData == null || petData.pets == null)
        {
            Debug.LogError("PetData is null or not properly initialized!");
            return new List<string>();
        }

        List<string> petNames = new List<string>();
        foreach (var petProp in petData.pets)
        {
            petNames.Add(petProp.petName);
        }
        return petNames;
    }

    void Update()
    {
        // Empty, retained for consistency with original code
    }
}