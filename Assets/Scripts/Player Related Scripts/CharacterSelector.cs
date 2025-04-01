//CharacterSelector.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    // Maintain both dropdown variables for compatibility
    public TMP_Dropdown characterDropdown;
    public TMP_Dropdown dropdown; // From the broken version

    public Slider BotCountSlider;
    public TextMeshProUGUI statsText;
    public TMP_Text noStatsText;

    // References from broken version
    public SaveManager saveManager;
    public Player player;

    public TMP_Text BotCountText;

    private string selectedCharacterName; // Kept from broken version

    void Start()
    {
        // Use whichever dropdown is available
        if (characterDropdown == null && dropdown != null)
            characterDropdown = dropdown;
        else if (dropdown == null && characterDropdown != null)
            dropdown = characterDropdown;
        else if (characterDropdown == null && dropdown == null)
            characterDropdown = dropdown = GetComponent<TMP_Dropdown>();

        // Ensure we have at least one valid dropdown
        if (characterDropdown == null)
        {
            Debug.LogError("No TMP_Dropdown found or assigned!");
            return;
        }

        // Setup dropdown event listener
        characterDropdown.onValueChanged.AddListener(OnCharacterSelected);

        // Initialize bot count slider
        if (BotCountSlider != null && BotCountText != null)
        {
            BotCountSlider.onValueChanged.RemoveAllListeners();
            BotCountSlider.onValueChanged.AddListener(OnBotCountChanged);

            // Set initial text value from slider
            int initialBotCount = Mathf.RoundToInt(BotCountSlider.value);
            BotCountText.text = initialBotCount.ToString();

            // Store initial value in PlayerPrefs
            PlayerPrefs.SetInt("BotCount", initialBotCount);
        }

        // Initialize player data from broken version
        if (saveManager != null && player != null)
        {
            saveManager.selectedSlot = "Slot1";
            player.isBot = false;
            player.characterData = new CharacterData("Hero", "Human", "Warrior", new PlayerProperties());
            Random.InitState(42); // Set random seed
        }

        // Load characters - critical working function
        LoadSavedCharacters();
    }

    private void OnDropdownValueChanged(int index)
    {
        // Keep this method for compatibility with any existing references
        if (characterDropdown != null && characterDropdown.options.Count > index)
        {
            selectedCharacterName = characterDropdown.options[index].text;
            Debug.Log("Selected character: " + selectedCharacterName);
        }
    }

    void LoadSavedCharacters()
    {
        List<string> savedCharacters = CharacterData.GetSavedCharactersList();

        // Clear both dropdowns (if both exist)
        characterDropdown.ClearOptions();
        if (dropdown != null && dropdown != characterDropdown)
            dropdown.ClearOptions();

        if (savedCharacters.Count > 0)
        {
            Debug.Log($"Found {savedCharacters.Count} saved characters: {string.Join(", ", savedCharacters)}");

            // Add characters to both dropdowns
            characterDropdown.AddOptions(savedCharacters);
            if (dropdown != null && dropdown != characterDropdown)
                dropdown.AddOptions(savedCharacters);

            // Set initial selection and display stats
            characterDropdown.value = 0;
            if (dropdown != null && dropdown != characterDropdown)
                dropdown.value = 0;

            DisplayCharacterStats(savedCharacters[0]);

            // Update UI elements
            if (noStatsText != null) noStatsText.gameObject.SetActive(false);
            if (statsText != null) statsText.gameObject.SetActive(true);
        }
        else
        {
            // No characters case
            characterDropdown.AddOptions(new List<string> { "No Characters" });
            if (dropdown != null && dropdown != characterDropdown)
                dropdown.AddOptions(new List<string> { "No Characters" });

            if (noStatsText != null) noStatsText.gameObject.SetActive(true);
            if (statsText != null) statsText.gameObject.SetActive(false);
        }
    }

    public void OnCharacterSelected(int index)
    {
        Debug.Log($"OnCharacterSelected called with index: {index}");

        // Make sure we're using the right dropdown
        TMP_Dropdown activeDropdown = characterDropdown != null ? characterDropdown : dropdown;

        if (activeDropdown != null && index >= 0 && index < activeDropdown.options.Count)
        {
            selectedCharacterName = activeDropdown.options[index].text;

            // Set selected slot in SaveManager if available (from broken version)
            if (SaveManager.instance != null)
            {
                SaveManager.instance.selectedSlot = "Slot1";
            }

            Debug.Log($"Selected character at index {index}: {selectedCharacterName}");

            // Only display stats if a valid character is selected
            if (selectedCharacterName != "No Characters")
            {
                DisplayCharacterStats(selectedCharacterName);
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

            Debug.Log($"Bot count changed to: {botCount}");
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
                           $"Shield: {props.Shield}" +
                           $"Strength: {props.Strength}\n" +
                           $"Magic: {props.Magic}\n" +
                           $"Defense: {props.Defense}\n" +
                           $"Dexterity: {props.Dexterity}\n" +
                           $"Agility: {props.Agility}\n" +
                           $"Luck: {props.Luck} \n" +
                           $"Intelligence: {props.Intelligence} \n" +
                           $"Stamina: {props.Stamina} \n" +
                           $"All Stats: {props.AllStats} \n";

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
        // Make sure we're using the right dropdown
        TMP_Dropdown activeDropdown = characterDropdown != null ? characterDropdown : dropdown;

        if (activeDropdown != null &&
            activeDropdown.options.Count > 0 &&
            activeDropdown.options[activeDropdown.value].text != "No Characters")
        {
            string selectedCharacter = activeDropdown.options[activeDropdown.value].text;
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

                // Load the correct scene
                // Support both scene names from the two versions
                string sceneName = "Monopodragons"; // From broken version

                Debug.Log($"Starting game with character: {selectedCharacter} and {botCount} bots");
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.LogWarning("Please select a character first!");
        }
    }
}