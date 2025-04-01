//CharacterSelector.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Slider BotCountSlider;
    public TextMeshProUGUI statsText;
    public TMP_Text noStatsText;

    public SaveManager saveManager;
    public Player player;

    public TMP_Text BotCountText;

    private string selectedCharacterName; // Declare the variable



    void Start()
    {
        if (dropdown == null || saveManager == null || player == null)
        {
            Debug.LogError("Missing references in CharacterSelector!");
            return;
        }

        dropdown.onValueChanged.AddListener(OnCharacterSelected);

            saveManager.selectedSlot = "Slot1";
            player.isBot = false;
            player.characterData = new CharacterData("Hero", "Human", "Warrior", new PlayerProperties());

            Random.InitState(42); // Set random seed
        
    }


    private void OnDropdownValueChanged(int index)
    {

        // Example usage
        selectedCharacterName = dropdown.options[dropdown.value].text;
        Debug.Log("Selected character: " + selectedCharacterName);

    }


    void LoadSavedCharacters()
    {
        List<string> savedCharacters = CharacterData.GetSavedCharactersList();
        dropdown.ClearOptions();

        if (savedCharacters.Count > 0)
        {
            Debug.Log($"Found {savedCharacters.Count} saved characters: {string.Join(", ", savedCharacters)}");
            // Add all saved characters to dropdown
            dropdown.AddOptions(savedCharacters);

            // Set to first character and display its stats
            dropdown.value = 0;  // Ensure first item is selected
            DisplayCharacterStats(savedCharacters[0]);

            if (noStatsText != null) noStatsText.gameObject.SetActive(false);
            if (statsText != null) statsText.gameObject.SetActive(true);
        }
        else
        {
            dropdown.AddOptions(new List<string> { "No Characters" });
            if (noStatsText != null) noStatsText.gameObject.SetActive(true);
            if (statsText != null) statsText.gameObject.SetActive(false);
        }
    }

    public void OnCharacterSelected(int index)
    {
        Debug.Log($"OnCharacterSelected called with index: {index}");
        if (index >= 0 && index < dropdown.options.Count)
        {
            selectedCharacterName = dropdown.options[index].text;
            SaveManager.instance.selectedSlot = "Slot1"; // correct casing
            Debug.Log($"Selected character at index {index}: {selectedCharacterName}");
            DisplayCharacterStats(selectedCharacterName);
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
                           $"Shield: {props.Shield}" +
                           $"Strength: {props.Strength}\n" +
                           $"Magic: {props.Magic}\n"  +
                           $"Defense: {props.Defense}\n" +
                           $"Dexterity: {props.Dexterity}\n" +
                           $"Agility: {props.Agility}\n" +
                           $"Luck: {props.Luck} \n" +
                           $"Intelligence: {props.Intelligence} \n" +
                           $"Stamina: {props.Stamina} \n" +
                           $"All Stats: {props.AllStats} \n" ;

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
        if (dropdown.options.Count > 0 &&
            dropdown.options[dropdown.value].text != "No Characters")
        {
            string selectedCharacter = dropdown.options[dropdown.value].text;
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

                UnityEngine.SceneManagement.SceneManager.LoadScene("Monopodragons");
            }
        }
        else
        {
            Debug.LogWarning("Please select a character first!");
        }
    }
}