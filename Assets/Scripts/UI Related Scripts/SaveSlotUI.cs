//SaveSlotUI.cs


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SaveSlotUI : MonoBehaviour
{
    // Reference to the Dropdown UI element in the scene
    public TMP_Dropdown saveSlotDropdown;

    // Called when the script instance is being loaded
    void Start()
    {
        // Populate the dropdown with save slot options
        PopulateSaveSlots();

        // Add a listener to handle dropdown selection changes
        saveSlotDropdown.onValueChanged.AddListener(SelectSlot);
    }

    // Populates the dropdown with save slot options
    void PopulateSaveSlots()
    {
        // Example array of save slots; replace with your own logic if needed
        string[] slots = { "1", "2", "3" };

        // Create a list to hold the dropdown options
        List<string> options = new List<string>();

        // Add each slot as an option in the format "Slot X"
        foreach (string slot in slots)
        {
            options.Add($"Slot {slot}");
        }

        // Clear any existing options in the dropdown
        saveSlotDropdown.ClearOptions();

        // Add the new options to the dropdown
        saveSlotDropdown.AddOptions(options);
    }

    // Called when the user selects an option from the dropdown
    void SelectSlot(int index)
    {
        // Extract the slot number from the selected option (e.g., "Slot 1" -> "1")
        string selectedSlot = saveSlotDropdown.options[index].text.Split(' ')[1];

        // Check if SaveManager exists and update the selected slot
        if (SaveManager.instance != null)
        {
            SaveManager.instance.selectedSlot = selectedSlot;
            Debug.Log($"Selected slot: {selectedSlot}");
        }
        else
        {
            Debug.LogError("SaveManager instance not found!");
        }
    }
}