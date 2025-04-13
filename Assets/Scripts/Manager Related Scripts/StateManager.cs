//StateManager.cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StateManager : MonoBehaviour
{
    private static StateManager instance;
    public int CurrentPlayerId = 0;
    public int DiceTotal;
    public bool IsDoneRolling = false;
    public bool IsDoneClicking = false;
    public bool IsDoneAnimating = false;
    public GameObject turnOverPopup;
    private bool waitingForNextTurn = false;

    private int totalPlayers;
    private List<int> activePlayerIds = new List<int>();

    void Start()
    {
        instance = this;
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        InitializePlayers();

        // Make sure popup is hidden at start
        if (turnOverPopup != null)
        {
            turnOverPopup.SetActive(false);
        }
    }

    void InitializePlayers()
    {
        // Get bot count from PlayerPrefs
        int botCount = PlayerPrefs.GetInt("BotCount", 0);
        totalPlayers = botCount + 1; // Add 1 for human player

        Debug.Log($"StateManager initializing game with {totalPlayers} players ({botCount} bots)");

        GameObject playersParent = GameObject.Find("Players");
        if (playersParent != null)
        {
            // Clear active player list
            activePlayerIds.Clear();

            // Find all active players
            PlayerMove[] activePlayers = playersParent.GetComponentsInChildren<PlayerMove>(false); // false = only active objects

            Debug.Log($"Found {activePlayers.Length} active players");

            // Build active player ID list
            foreach (PlayerMove player in activePlayers)
            {
                activePlayerIds.Add(player.PlayerId);
                Debug.Log($"Added active player ID: {player.PlayerId}");
            }

            Debug.Log($"Active player IDs: {string.Join(", ", activePlayerIds)}");
        }
        else
        {
            Debug.LogError("No Players parent object found!");
        }
    }

    void Update()
    {
        // Add debug output when pressing F3
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Debug.Log($"StateManager has {totalPlayers} total players and {activePlayerIds.Count} active player IDs");
            Debug.Log($"Current Player ID: {CurrentPlayerId}");
            Debug.Log($"Active player IDs: {string.Join(", ", activePlayerIds)}");
        }
        // Is turn done
        if (IsDoneRolling && IsDoneClicking && IsDoneAnimating && !waitingForNextTurn)
        {
            Debug.Log("Turn is Done!");
            StartCoroutine(EndTurnSequence());
        }

        // Check for Enter key press when turn over popup is active
        if (turnOverPopup != null && turnOverPopup.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            OnProceedButtonClick();
        }
    }

    IEnumerator EndTurnSequence()
    {
        waitingForNextTurn = true;
        yield return new WaitForSeconds(.2f);
        if (turnOverPopup != null)
        {
            turnOverPopup.SetActive(true);
        }
    }

    public void OnProceedButtonClick()
    {
        Debug.Log("Proceed button clicked");
        if (turnOverPopup != null)
        {
            turnOverPopup.SetActive(false);
        }
        waitingForNextTurn = false;
        NewTurn();
    }

    void NewTurn()
    {
        IsDoneRolling = false;
        IsDoneClicking = false;
        IsDoneAnimating = false;
        DiceTotal = 0;

        // Find next player
        CurrentPlayerId = (CurrentPlayerId + 1) % totalPlayers;
        Debug.Log($"Turn changed to Player {CurrentPlayerId}");
    }


    
}
