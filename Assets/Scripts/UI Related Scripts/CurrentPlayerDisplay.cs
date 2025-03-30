//CurrentPlayerDisplay.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentPlayerDisplay : MonoBehaviour
{
    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        myText = GetComponent<TextMeshProUGUI>();
    }

    StateManager theStateManager;
    TextMeshProUGUI myText;
    string[] numberWords = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight" };

    void Update()
    {
        string playerDataKey = $"Player{theStateManager.CurrentPlayerId + 1}_Data";
        string playerDataJson = PlayerPrefs.GetString(playerDataKey);

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

                myText.text = !string.IsNullOrEmpty(charData.characterTitle) ? charData.characterTitle : charData.characterName;
                return;
            }
        }

        // Fallback to default text if no character data found
        myText.text = "Player " + numberWords[theStateManager.CurrentPlayerId];
    }
}