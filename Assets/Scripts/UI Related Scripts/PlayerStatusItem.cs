//PlayerStatusItem.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;

public class PlayerStatusItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthBarFill;
    private Player player;
    private PlayerMove playerMove;

    private void Awake()
    {
        // Auto-find components if not assigned
        if (playerNameText == null)
            playerNameText = GetComponentInChildren<TextMeshProUGUI>();
        if (healthBar == null)
            healthBar = GetComponentInChildren<Slider>();
        if (healthBarFill == null && healthBar != null)
            healthBarFill = healthBar.fillRect.GetComponent<Image>();

        Debug.Log($"Components found - Name Text: {playerNameText != null}, Health Bar: {healthBar != null}, Fill: {healthBarFill != null}");
    }

    public void Initialize(Player targetPlayer)
    {
        player = targetPlayer;
        playerMove = player.GetComponent<PlayerMove>();
        Debug.Log($"Initializing PlayerStatusItem for Player {playerMove?.PlayerId}");
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        if (player == null || playerMove == null)
        {
            Debug.LogError("Player or PlayerMove is null!");
            return;
        }

        string playerDataKey = $"Player{playerMove.PlayerId + 1}_Data";
        string playerDataJson = PlayerPrefs.GetString(playerDataKey);

        // Update name
        if (playerNameText != null)
        {
            string displayName = $"Player {playerMove.PlayerId + 1}";
            if (!string.IsNullOrEmpty(playerDataJson))
            {
                CharacterData charData = JsonUtility.FromJson<CharacterData>(playerDataJson);
                if (charData != null)
                {
                    // Generate title if it doesn't exist
                    if (string.IsNullOrEmpty(charData.characterTitle))
                    {
                        TitleGenerator titleGen = GameObject.FindFirstObjectByType<TitleGenerator>();
                        if (titleGen != null)
                        {
                            charData.characterTitle = titleGen.GenerateTitle(charData.characterName, charData.race, charData.characterClass);
                            // Save the updated character data with the new title
                            PlayerPrefs.SetString(playerDataKey, JsonUtility.ToJson(charData));
                        }
                    }

                    displayName = !string.IsNullOrEmpty(charData.characterTitle) ? charData.characterTitle : charData.characterName;
                }
            }
            playerNameText.text = displayName;
            //Debug.Log($"Set name text to: {displayName} for Player {playerMove.PlayerId + 1}");
        }
        else
        {
            Debug.LogError($"PlayerNameText is null for Player {playerMove.PlayerId + 1}!");
        }

        // Update health bar
        if (healthBar != null)
        {
            healthBar.maxValue = player.properties.MaxHealth;
            healthBar.value = player.properties.Health;

            if (healthBarFill != null)
            {
                float healthPercentage = (float)player.properties.Health / player.properties.MaxHealth;
                healthBarFill.color = Color.Lerp(Color.red, Color.green, healthPercentage);
            }
            //debug log for updated health bar
            //Debug.Log($"Updated health bar for Player {playerMove.PlayerId + 1}: {player.properties.Health}/{player.properties.MaxHealth}");
        }
        else
        {
            Debug.LogError($"HealthBar is null for Player {playerMove.PlayerId + 1}!");
        }
    }
}