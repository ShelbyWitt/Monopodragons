//SaveAndQuit.cs

// SaveAndQuit.cs
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour
{
    public Button saveAndQuitButton;

    void Start()
    {
        saveAndQuitButton.onClick.AddListener(SaveAndQuitGame);
    }

    void SaveAndQuitGame()
    {
        if (SaveManager.Instance != null && int.TryParse(SaveManager.Instance.selectedSlot, out int slot) && slot > 0)
        {
            SaveData data = CollectSaveData(); // Implement this method
            SaveSystem.SaveGame(data, slot.ToString());
            Debug.Log($"Saving to slot: {slot}");
            Application.Quit();
        }
        else
        {
            Debug.LogWarning("No save slot selected, invalid slot, or SaveManager not found!");
        }
    }

    // Example method to collect game data (customize as needed)
    private SaveData CollectSaveData()
    {
        SaveData data = new SaveData
        {
            playerName = "Player", // Replace with actual player data
            level = 1,
            health = 100,
            currentQuest = "Quest1",
            seed = Random.seed
        };
        data.inventory.Add("Sword");
        data.inventory.Add("Shield");
        return data;
    }
}