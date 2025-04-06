//GameManager.cs


using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string loadSlot = "1"; // Slot to load from (can be set via UI)

    //public MedalData medalDataAsset;    //Assign in Inspector
    private MedalManager medalManager;

    void Start()
    {
        // Example: Load the game when the scene starts (optional)
        // LoadGame(loadSlot);

       // medalManager = new MedalManager(medalDataAsset);
       // medalManager.UpdateMedalStatuses();
    }

    // Public method to load a game from a specific slot
    public void LoadGame(string slot)
    {
        SaveData data = SaveSystem.LoadGame(slot);
        if (data != null)
        {
            ApplySaveData(data);
        }
        else
        {
            Debug.LogWarning("No save data found. Starting a new game?");
            // Optionally start a new game here
        }
    }

    // Apply the loaded data to the game state
    void ApplySaveData(SaveData data)
    {
        // Example: Apply data to game systems (replace with your actual implementation)
        Debug.Log($"Loading: Player {data.playerName}, Level {data.level}, Health {data.health}");
        Debug.Log($"Inventory: {string.Join(", ", data.inventory)}");
        Debug.Log($"Current Quest: {data.currentQuest}");
        Debug.Log($"World Seed: {data.seed}");

        // Example integration (uncomment and adjust for your game):
        // Player.instance.name = data.playerName;
        // Player.instance.level = data.level;
        // Player.instance.health = data.health;
        // InventoryManager.instance.SetInventory(data.inventory);
        // QuestManager.instance.SetCurrentQuest(data.currentQuest);
        // WorldGenerator.instance.SetSeed(data.seed);
    }
}