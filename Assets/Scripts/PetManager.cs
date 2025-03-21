// PetManager.cs
using UnityEngine;
using System.Collections.Generic;

public class PetManager : MonoBehaviour
{
    [SerializeField]
    private PetDatabase petDatabase; // Changed from PetData to PetDatabase

    private StateManager theStateManager;

    void Start()
    {
        theStateManager = FindObjectOfType<StateManager>();
        if (petDatabase == null)
        {
            Debug.LogError("PetDatabase is not assigned in PetManager! Please assign it in the Inspector.");
        }
    }

    public PetData GetPetData(string petName)
    {
        if (petDatabase == null || petDatabase.pets == null)
        {
            Debug.LogError("PetDatabase is null or not properly initialized!");
            return null;
        }

        foreach (var pet in petDatabase.pets)
        {
            if (pet.petName == petName)
            {
                return pet;
            }
        }

        Debug.LogWarning($"Pet '{petName}' not found in PetDatabase. Returning first pet as default.");
        if (petDatabase.pets.Length > 0)
        {
            return petDatabase.pets[0];
        }

        Debug.LogError("No pets found in PetDatabase!");
        return null;
    }

    public List<string> GetPetNames()
    {
        if (petDatabase == null || petDatabase.pets == null)
        {
            Debug.LogError("PetDatabase is null or not properly initialized!");
            return new List<string>();
        }

        List<string> petNames = new List<string>();
        foreach (var pet in petDatabase.pets)
        {
            petNames.Add(pet.petName);
        }
        return petNames;
    }

    void Update()
    {
        // Empty for now; add logic if needed
    }
}