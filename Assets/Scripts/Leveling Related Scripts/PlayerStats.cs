//PlayerStats.cs


using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Singleton instance for easy access
    public static PlayerStats Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persists across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    // Gets the play count for a given subcategory
    public int GetPlayCount(string subcategory)
    {
        // Replace this with your actual save data logic
        Debug.Log($"Getting play count for {subcategory} - implement this!");
        return 0; // Placeholder value; implement based on your game’s data
    }
}