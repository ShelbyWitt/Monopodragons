//LevelingSytsem.cs

using UnityEngine;
using System;

public class LevelingSystem : MonoBehaviour
{
    public PlayerProgress player;

    private void Start()
    {
        LoadPlayerData(); // Load saved data or initialize new progress
    }

    private void Update()
    {
        CheckDailyReset(); // Check if daily tasks need resetting
    }

    // Called when a game ends
    public void OnGameCompleted()
    {
        player.gamesPlayed++;
        AddXP(150);              // Award XP for completing a game
        UpdateDailyTasks(0, 1);  // Example: Task 0 = "Play X games"
        SavePlayerData();        // Save after changes
    }

    // Update progress for a daily task
    public void UpdateDailyTasks(int taskIndex, int progress)
    {
        if (player.dailyTaskCompleted[taskIndex]) return; // Skip if already completed

        player.dailyTaskProgress[taskIndex] += progress;

        // Example task goals (customize as needed)
        int[] taskGoals = { 3, 100, 1 }; // e.g., "Play 3 games," "Collect 100 coins," "Win 1 game"
        if (player.dailyTaskProgress[taskIndex] >= taskGoals[taskIndex])
        {
            player.dailyTaskCompleted[taskIndex] = true;
            AddXP(25); // Award XP for task completion
            Debug.Log($"Daily Task {taskIndex} Completed!");
            SavePlayerData(); // Save after task completion
        }
    }

    // Add XP and level up if necessary
    private void AddXP(int amount)
    {
        player.xp += amount;
        while (player.xp >= player.XpToNextLevel)
        {
            player.xp -= player.XpToNextLevel;
            player.level++;
            Debug.Log($"Level Up! New Level: {player.level}");
        }
        SavePlayerData(); // Save after XP or level changes
    }

    // Reset daily tasks if a new day has started
    private void CheckDailyReset()
    {
        if (DateTime.Now.Date > player.lastReset.Date)
        {
            for (int i = 0; i < player.dailyTaskProgress.Length; i++)
            {
                player.dailyTaskProgress[i] = 0;
                player.dailyTaskCompleted[i] = false;
            }
            player.lastReset = DateTime.Now;
            Debug.Log("Daily tasks reset!");
            SavePlayerData(); // Save after reset
        }
    }

    // Load player data from PlayerPrefs
    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerProgress"))
        {
            string json = PlayerPrefs.GetString("PlayerProgress");
            SerializablePlayerProgress serializable = JsonUtility.FromJson<SerializablePlayerProgress>(json);
            player = new PlayerProgress
            {
                level = serializable.level,
                xp = serializable.xp,
                gamesPlayed = serializable.gamesPlayed,
                dailyTaskProgress = serializable.dailyTaskProgress,
                dailyTaskCompleted = serializable.dailyTaskCompleted,
                lastReset = DateTime.Parse(serializable.lastReset)
            };
        }
        else
        {
            player = new PlayerProgress();
            player.Initialize(); // Set default values
            SavePlayerData();    // Save initial state
        }
    }

    // Save player data to PlayerPrefs
    private void SavePlayerData()
    {
        SerializablePlayerProgress serializable = new SerializablePlayerProgress
        {
            level = player.level,
            xp = player.xp,
            gamesPlayed = player.gamesPlayed,
            dailyTaskProgress = player.dailyTaskProgress,
            dailyTaskCompleted = player.dailyTaskCompleted,
            lastReset = player.lastReset.ToString("o") // ISO 8601 format for DateTime
        };
        string json = JsonUtility.ToJson(serializable);
        PlayerPrefs.SetString("PlayerProgress", json);
        PlayerPrefs.Save(); // Ensure data is written to disk
    }

    // Optional: Save when the application quits
    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}

