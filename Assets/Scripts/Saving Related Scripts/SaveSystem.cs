//SaveSystem.cs

using System.IO;
using UnityEngine;

public static class SaveSystem
{
    // Helper method to generate the file path for a given save slot
    private static string GetSavePath(string slot)
    {
        return Path.Combine(Application.persistentDataPath, $"save_{slot}.json");
    }

    // Save the game data to a JSON file in the specified slot
    public static void SaveGame(SaveData data, string slot)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true); // Pretty-print for readability
            File.WriteAllText(GetSavePath(slot), json);
            Debug.Log($"Game saved successfully to slot {slot}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save game to slot {slot}: {e.Message}");
        }
    }

    // Load the game data from a JSON file in the specified slot
    public static SaveData LoadGame(string slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            try
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                Debug.Log($"Game loaded successfully from slot {slot}");
                return data;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load game from slot {slot}: {e.Message}");
                return null;
            }
        }
        Debug.LogWarning($"No save file found for slot {slot}");
        return null; // Return null if no file exists
    }

    // Get a list of all available save slots
    public static string[] GetSaveSlots()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "save_*.json");
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = Path.GetFileNameWithoutExtension(files[i]).Replace("save_", "");
        }
        return files;
    }
}