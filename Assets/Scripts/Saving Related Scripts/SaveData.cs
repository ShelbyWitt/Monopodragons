//SaveData.cs

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    // Player-related data
    public string playerName;           // The name of the player character
    public int level;                   // Player's current level
    public int health;                  // Player's current health
    public List<string> inventory;      // List of items in the player's inventory
    public string currentQuest;         // The name or ID of the current quest
    public int seed;                    // Seed for procedural generation (if applicable)

    // Constructor to initialize the list
    public SaveData()
    {
        inventory = new List<string>();
    }
}