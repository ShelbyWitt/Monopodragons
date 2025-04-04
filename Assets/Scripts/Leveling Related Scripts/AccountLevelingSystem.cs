//AccountLevelingSytsem.cs

using UnityEngine;
using System;

public class AccountLevelingSystem : MonoBehaviour
{
    public AccountProgress account;

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
        account.gamesPlayed++;
        AddXP(150);              // Award XP for completing a game
        UpdateDailyTasks(0, 1);  // Example: Task 0 = "Play X games"
        SavePlayerData();        // Save after changes
    }

    // Update progress for a daily task
    public void UpdateDailyTasks(int taskIndex, int progress)
    {
        if (account.dailyTaskCompleted[taskIndex]) return; // Skip if already completed

        account.dailyTaskProgress[taskIndex] += progress;

        // Example task goals (customize as needed)
        int[] taskGoals = { 3, 100, 1 }; // e.g., "Play 3 games," "Collect 100 coins," "Win 1 game"
        if (account.dailyTaskProgress[taskIndex] >= taskGoals[taskIndex])
        {
            account.dailyTaskCompleted[taskIndex] = true;
            AddXP(25); // Award XP for task completion
            Debug.Log($"Daily Task {taskIndex} Completed!");
            SavePlayerData(); // Save after task completion
        }
    }

    // Add XP and level up if necessary
    private void AddXP(int amount)
    {
        account.xp += amount;
        while (account.xp >= account.XpToNextLevel)
        {
            account.xp -= account.XpToNextLevel;
            account.level++;
            Debug.Log($"Level Up! New Level: {account.level}");
        }
        SavePlayerData(); // Save after XP or level changes
    }

    // Reset daily tasks if a new day has started
    private void CheckDailyReset()
    {
        if (DateTime.Now.Date > account.lastOnline.Date)
        {
            for (int i = 0; i < account.dailyTaskProgress.Length; i++)
            {
                account.dailyTaskProgress[i] = 0;
                account.dailyTaskCompleted[i] = false;
            }
            account.lastOnline = DateTime.Now;
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
            SerializableAccountProgress serializable = JsonUtility.FromJson<SerializableAccountProgress>(json);
            account = new AccountProgress
            {
                level = serializable.level,
                xp = serializable.xp,
                gamesPlayed = serializable.gamesPlayed,
                dailyTaskProgress = serializable.dailyTaskProgress,
                dailyTaskCompleted = serializable.dailyTaskCompleted,
                lastOnline = DateTime.Parse(serializable.lastReset)
            };
        }
        else
        {
            account = new AccountProgress();
            account.Initialize(); // Set default values
            SavePlayerData();    // Save initial state
        }
    }

    // Save player data to PlayerPrefs
    private void SavePlayerData()
    {
        SerializableAccountProgress serializable = new SerializableAccountProgress
        {
            level = account.level,
            xp = account.xp,
            gamesPlayed = account.gamesPlayed,
            dailyTaskProgress = account.dailyTaskProgress,
            dailyTaskCompleted = account.dailyTaskCompleted,
            lastReset = account.lastOnline.ToString("o") // ISO 8601 format for DateTime
        };
        string json = JsonUtility.ToJson(serializable);
        PlayerPrefs.SetString("AccountProgress", json);
        PlayerPrefs.Save(); // Ensure data is written to disk
    }

    // Optional: Save when the application quits
    private void OnApplicationQuit()
    {
        SavePlayerData();
    }
}

