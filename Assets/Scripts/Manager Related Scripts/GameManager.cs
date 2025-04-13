//GameManager.cs

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Remove these references if they're causing problems
    // public GameObject playerPrefab;  // Remove or comment this out
    // public Transform[] startPositions; // Remove or comment this out

    public string loadSlot = "1";
    private MedalManager medalManager;

    void Start()
    {
        // Your original setup - this works with the hierarchy-based player objects
        // Instead of instantiating new players, we'll activate/deactivate existing ones
        SetupPlayersFromHierarchy();
        DebugPlayerCounts();
    }

    void Update()
    {
        // Press F2 to print debug info about active players
        if (Input.GetKeyDown(KeyCode.F2))
        {
            DebugActivePlayers();
        }
    }

    void DebugActivePlayers()
    {
        GameObject playersParent = GameObject.Find("Players");
        if (playersParent != null)
        {
            Debug.Log("=== ACTIVE PLAYERS DEBUG ===");
            foreach (Transform child in playersParent.transform)
            {
                PlayerMove pm = child.GetComponent<PlayerMove>();
                if (pm != null)
                {
                    Debug.Log($"Player {pm.PlayerId} ({child.name}): Active={child.gameObject.activeInHierarchy}, " +
                             $"Position={child.position}, Current Tile={pm.currentTile?.name ?? "None"}");
                }
            }
        }
    }

    void DebugPlayerCounts()
    {
        int botCount = PlayerPrefs.GetInt("BotCount", 0);
        PlayerMove[] allPlayers = GameObject.FindObjectsOfType<PlayerMove>();
        Player[] allPlayerComponents = GameObject.FindObjectsOfType<Player>();

        Debug.Log($"============== PLAYER COUNT DEBUG ==============");
        Debug.Log($"Desired bot count: {botCount}");
        Debug.Log($"Total player objects found: {allPlayers.Length}");
        Debug.Log($"Total Player components found: {allPlayerComponents.Length}");

        foreach (PlayerMove pm in allPlayers)
        {
            Debug.Log($"Player {pm.PlayerId} active: {pm.gameObject.activeInHierarchy}");
        }
        Debug.Log($"==============================================");
    }

    void SetupPlayersFromHierarchy()
    {
        // Get the desired bot count from PlayerPrefs
        int desiredBotCount = PlayerPrefs.GetInt("BotCount", 0);
        Debug.Log($"Desired bot count: {desiredBotCount}");

        // Find the Players parent in the hierarchy
        GameObject playersParent = GameObject.Find("Players");
        if (playersParent == null)
        {
            Debug.LogError("Players parent not found in hierarchy!");
            return;
        }

        // Get all Player components that are direct children of the Players parent
        // First, get all direct child transforms
        List<Transform> playerTransforms = new List<Transform>();
        foreach (Transform child in playersParent.transform)
        {
            if (child.name.StartsWith("Player ")) // Only include actual player objects
                playerTransforms.Add(child);
        }

        Debug.Log($"Found {playerTransforms.Count} player objects in hierarchy");

        // Deactivate all players first
        foreach (Transform playerTransform in playerTransforms)
        {
            playerTransform.gameObject.SetActive(false);
        }

        // Activate only the players we need (player 0 + bots)
        int totalPlayersToActivate = 1 + desiredBotCount; // Human + bots
        for (int i = 0; i < playerTransforms.Count && i < totalPlayersToActivate; i++)
        {
            Transform playerTransform = playerTransforms[i];
            PlayerMove playerMove = playerTransform.GetComponent<PlayerMove>();
            Player player = playerTransform.GetComponent<Player>();

            if (playerMove == null || player == null)
            {
                Debug.LogError($"Player object {playerTransform.name} is missing PlayerMove or Player component!");
                continue;
            }

            // Activate the player
            playerTransform.gameObject.SetActive(true);
            Debug.Log($"Activated player {i}: {playerTransform.name}");

            // Set the player's ID explicitly to match its index
            playerMove.PlayerId = i;

            if (i == 0) // Human player
            {
                player.isBot = false;
                string player1DataJson = PlayerPrefs.GetString("Player1_Data");
                if (!string.IsNullOrEmpty(player1DataJson))
                {
                    CharacterData charData = JsonUtility.FromJson<CharacterData>(player1DataJson);
                    if (charData != null)
                    {
                        player.characterData = charData;
                        player.properties = charData.properties.ToPlayerProperties();
                        player.playerColor = charData.playerColor;
                        Debug.Log($"Set up human player with character {charData.characterName}");
                    }
                }
            }
            else // Bot
            {
                player.isBot = true;

                // Assign a random character from saved characters
                List<string> savedCharacters = CharacterData.GetSavedCharactersList();
                if (savedCharacters.Count > 0)
                {
                    string randomCharacter = savedCharacters[Random.Range(0, savedCharacters.Count)];
                    CharacterData charData = CharacterData.LoadCharacter(randomCharacter);

                    if (charData != null)
                    {
                        player.characterData = charData;
                        player.properties = charData.properties.ToPlayerProperties();
                        player.playerColor = charData.playerColor;

                        // Save bot data to PlayerPrefs
                        string botDataKey = $"Player{i + 1}_Data";
                        PlayerPrefs.SetString(botDataKey, JsonUtility.ToJson(charData));
                        Debug.Log($"Set up bot {i} with character {charData.characterName}");
                    }
                }
            }
        }

        Debug.Log($"Activated {totalPlayersToActivate} players from hierarchy");
    }

    // Your existing LoadGame method
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
        }
    }

    // Your existing ApplySaveData method
    void ApplySaveData(SaveData data)
    {
        Debug.Log($"Loading: Player {data.playerName}, Level {data.level}, Health {data.health}");
        Debug.Log($"Inventory: {string.Join(", ", data.inventory)}");
        Debug.Log($"Current Quest: {data.currentQuest}");
        Debug.Log($"World Seed: {data.seed}");
    }
}