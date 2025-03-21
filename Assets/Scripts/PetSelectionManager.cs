// PetSelectionManager.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PetSelectionManager : MonoBehaviour
{
    public TMP_Dropdown petDropdown;
    public TextMeshProUGUI petStatsText; // Change to match the component
    public PetDatabase petDatabase;

    private List<PetInstance> savedPets = new List<PetInstance>();

    void Start()
    {
        LoadSavedPets();
        PopulateDropdown();
    }

    void LoadSavedPets()
    {
        // For this example, we'll simulate some saved pets
        // In a real game, load from PlayerPrefs or a save file
        if (petDatabase != null && petDatabase.pets.Length > 0)
        {
            savedPets.Add(new PetInstance(petDatabase.pets[0], 1));
            if (petDatabase.pets.Length > 1)
            {
                savedPets.Add(new PetInstance(petDatabase.pets[1], 2));
            }
        }
        else
        {
            Debug.LogError("PetDatabase is not assigned or empty!");
        }
    }

    void PopulateDropdown()
    {
        petDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (var pet in savedPets)
        {
            options.Add($"{pet.petData.petName} (Level {pet.level})");
        }
        petDropdown.AddOptions(options);
        petDropdown.onValueChanged.AddListener(OnPetSelected);
        if (savedPets.Count > 0)
        {
            OnPetSelected(0); // Show stats for the first pet by default
        }
    }

    public void OnPetSelected(int index)
    {
        if (index < 0 || index >= savedPets.Count) return;
        PetInstance selectedPet = savedPets[index];
        petStatsText.text = GetPetStatsText(selectedPet);
    }

    string GetPetStatsText(PetInstance pet)
    {
        return $"Name: {pet.petData.petName}\n" +
               $"Level: {pet.level}\n" +
               $"Health: {pet.currentStats.Health}/{pet.currentStats.MaxHealth}\n" +
               $"Mana: {pet.currentStats.Mana}/{pet.currentStats.MaxMana}\n" +
               $"Strength: {pet.currentStats.Strength}";
    }
}