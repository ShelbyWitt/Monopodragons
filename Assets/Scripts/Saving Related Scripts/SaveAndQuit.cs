//SaveAndQuit.cs

// SaveAndQuit.cs
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour
{
    public Button saveAndQuitButton;

    CharacterData characterData;

    //void Start()
    //{

        


    //    if (!isBot)
    //    {
    //        SaveData saveData = SaveSystem.LoadGame(SaveManager.instance.selectedSlot);
    //        if (saveData != null)
    //        {
    //            characterData = new CharacterData();
    //            characterData.characterName = saveData.playerName;
    //            characterData.health = saveData.health;
    //            // Apply other saved data as needed
    //            Debug.Log($"Loaded Player data from slot {SaveManager.instance.selectedSlot}: Health: {characterData.health}");
    //        }
    //        else
    //        {
    //            characterData.LoadCharacter(characterData.characterName); // Fallback to default
    //        }
    //    }
    //    // Bot-specific loading logic here
    //}

    //void SaveAndQuitGame()
    //{
    //    if (SaveManager.instance != null && int.TryParse(SaveManager.instance.selectedSlot, out int slot) && slot > 0)
    //    {
    //        SaveData data = CollectSaveData(); // Implement this method
    //        SaveSystem.SaveGame(data, slot.ToString());
    //        Debug.Log($"Saving to slot: {slot}");
    //        Application.Quit();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No save slot selected, invalid slot, or SaveManager not found!");
    //    }
    //}


    //public void SetRandomSeed(int r)
    //{
    //    int seedValue = 42;
    //    Random.InitState(seedValue);    //Use InitState instead
    //}

    //// Example method to collect game data (customize as needed)
    //private SaveData CollectSaveData()
    //{
    //    SaveData data = new SaveData
    //    {
    //        playerName = "Player", // Replace with actual player data
    //        level = 1,
    //        health = 100,
    //        currentQuest = "Quest1",
    //        seed = SetRandomSeed(r),
    //    };
    //    data.inventory.Add("Sword");
    //    data.inventory.Add("Shield");
    //    return data;
    //}
}