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
        // Get bot count (defaults to 7 if not set)
        int botCount = PlayerPrefs.GetInt("BotCount", 7);
        totalPlayers = botCount + 1; // Add 1 for human player

        GameObject playersParent = GameObject.Find("Players");
        if (playersParent != null)
        {
            // Clear active player list
            activePlayerIds.Clear();

            // Get all PlayerMove components and sort them by ID
            PlayerMove[] allPlayers = playersParent.GetComponentsInChildren<PlayerMove>(true)
                                                  .OrderBy(p => p.PlayerId)
                                                  .ToArray();

            Debug.Log($"Found {allPlayers.Length} total players");

            // Activate/deactivate players and build active player list
            for (int i = 0; i < allPlayers.Length; i++)
            {
                bool shouldBeActive = i < totalPlayers;
                allPlayers[i].gameObject.SetActive(shouldBeActive);

                if (shouldBeActive)
                {
                    activePlayerIds.Add(allPlayers[i].PlayerId);
                    Debug.Log($"Activated Player {allPlayers[i].PlayerId}");
                }
                else
                {
                    Debug.Log($"Deactivated Player {allPlayers[i].PlayerId}");
                }
            }

            Debug.Log($"Game initialized with {totalPlayers} players ({botCount} bots)");
            Debug.Log($"Active player IDs: {string.Join(", ", activePlayerIds)}");
        }
        else
        {
            Debug.LogError("No Players parent object found!");
        }
    }

    void Update()
    {
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
