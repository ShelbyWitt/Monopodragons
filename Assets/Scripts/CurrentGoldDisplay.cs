//CurrentGoldDisplay.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentGoldDisplay : MonoBehaviour
{
    private StateManager theStateManager;
    private TextMeshProUGUI goldText;

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        goldText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Find all players
        Player[] players = GameObject.FindObjectsByType<Player>(FindObjectsSortMode.None);

        // Find the current player
        foreach (Player player in players)
        {
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            if (playerMove != null && playerMove.PlayerId == theStateManager.CurrentPlayerId)
            {
                // Update gold text with current player's gold amount
                goldText.text = player.properties.Gold.ToString();
                return;
            }
        }

        // Fallback if no player found
        goldText.text = "0";
    }
}