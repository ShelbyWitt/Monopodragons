//CharacterSelector.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public TMP_Dropdown characterDropdown;
    public Slider BotCountSlider;
    public TextMeshProUGUI statsText;
    public TMP_Text noStatsText;

    public TMP_Text BotCountText;

    void Start()
    {
        if (characterDropdown == null)
            characterDropdown = GetComponent<TMP_Dropdown>();

        characterDropdown.onValueChanged.AddListener(OnCharacterSelected);

        if (BotCountSlider != null && BotCountText != null)
        {
            BotCountSlider.onValueChanged.RemoveAllListeners();
            BotCountSlider.onValueChanged.AddListener(OnBotCountChanged);
            BotCountText.text = Mathf.RoundToInt(BotCountSlider.value).ToString();
        }

        LoadSavedCharacters();
    }

    void LoadSavedCharacters()
    {
        List<string> savedCharacters = CharacterData.GetSavedCharactersList();
        characterDropdown.ClearOptions();

        if (savedCharacters.Count > 0)
        {
            Debug.Log($"Found {savedCharacters.Count} saved characters: {string.Join(", ", savedCharacters)}");
            // Add all saved characters to dropdown
            characterDropdown.AddOptions(savedCharacters);

            // Set to first character and display its stats
            characterDropdown.value = 0;  // Ensure first item is selected
            DisplayCharacterStats(savedCharacters[0]);

            if (noStatsText != null) noStatsText.gameObject.SetActive(false);
            if (statsText != null) statsText.gameObject.SetActive(true);
        }
        else
        {
            characterDropdown.AddOptions(new List<string> { "No Characters" });
            if (noStatsText != null) noStatsText.gameObject.SetActive(true);
            if (statsText != null) statsText.gameObject.SetActive(false);
        }
    }

    public void OnCharacterSelected(int index)
    {
        Debug.Log($"OnCharacterSelected called with index: {index}");

        if (characterDropdown.options.Count > 0 && index >= 0 && index < characterDropdown.options.Count)
        {
            string selectedCharName = characterDropdown.options[index].text;
            Debug.Log($"Selected character at index {index}: {selectedCharName}");

            if (selectedCharName != "No Characters")
            {
                DisplayCharacterStats(selectedCharName);
            }
        }
    }

    public void OnBotCountChanged(float value)
    {
        if (BotCountText != null)
        {
            int botCount = Mathf.RoundToInt(value);
            BotCountText.text = botCount.ToString();
            PlayerPrefs.SetInt("BotCount", botCount);
            PlayerPrefs.Save();
        }
    }

    void DisplayCharacterStats(string characterName)
    {
        if (statsText == null) return;

        Debug.Log($"Attempting to display stats for: {characterName}");
        string rawJson = PlayerPrefs.GetString("Character_" + characterName);
        Debug.Log($"Raw saved data for {characterName}: {rawJson}");

        CharacterData charData = CharacterData.LoadCharacter(characterName);
        if (charData != null && charData.properties != null)
        {
            statsText.gameObject.SetActive(true);
            if (noStatsText != null) noStatsText.gameObject.SetActive(false);

            PlayerProperties props = charData.properties.ToPlayerProperties();

            statsText.text = $"Name: {charData.characterName}\n" +
                           $"Race: {charData.race}\n" +
                           $"Class: {charData.characterClass}\n" +
                           $"Health: {props.Health}\n" +
                           $"Mana: {props.Mana}\n" +
                           $"Strength: {props.Strength}\n" +
                           $"Magic: {props.Magic}\n"  +
                           $"Wisdom: {props.Intelligence}";

            Debug.Log($"Successfully updated stats display for {characterName}");
        }
        else
        {
            Debug.LogError($"Failed to load character data for {characterName}");
            statsText.text = "Error loading character";
        }
    }

    public void StartGame()
    {
        if (characterDropdown.options.Count > 0 &&
            characterDropdown.options[characterDropdown.value].text != "No Characters")
        {
            string selectedCharacter = characterDropdown.options[characterDropdown.value].text;
            CharacterData charData = CharacterData.LoadCharacter(selectedCharacter);

            if (charData != null)
            {
                // Save player 1's data
                string player1Data = JsonUtility.ToJson(charData);
                PlayerPrefs.SetString("Player1_Data", player1Data);

                // Save the bot count
                int botCount = Mathf.RoundToInt(BotCountSlider.value);
                PlayerPrefs.SetInt("BotCount", botCount);
                PlayerPrefs.Save();

                UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            Debug.LogWarning("Please select a character first!");
        }
    }
}