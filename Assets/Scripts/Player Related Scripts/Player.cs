//Player.cs
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerProperties properties;
    public Color playerColor; // Holds the character's color
    StateManager theStateManager;
    public Pet activePet;
    public int petBaseAttack = 10;
    public bool isBot;
    public CharacterData characterData;


    public int GetAttack()
    {
        if (activePet != null)
        {
            return petBaseAttack + activePet.currentStats.Strength / 2; // Example: Strength boosts attack
        }
        return petBaseAttack;
    }

    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        isBot = false;      //Example - Set based on your logic
        Debug.Log("Is this a bot? " + isBot);

        characterData = new CharacterData("Hero", "Human", "Warrior", new PlayerProperties());


        PlayerMove playerMove = GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            if (playerMove.PlayerId == 0) // Player 1
            {
                string player1DataJson = PlayerPrefs.GetString("Player1_Data");
                if (!string.IsNullOrEmpty(player1DataJson))
                {
                    CharacterData charData = JsonUtility.FromJson<CharacterData>(player1DataJson);
                    if (charData != null && charData.properties != null)
                    {
                        properties = charData.properties.ToPlayerProperties();
                        playerColor = charData.playerColor; // Set the color
                        ApplyColorToPlayer(); // Apply the color
                        Debug.Log($"Loaded Player 1: Health: {properties.Health}, Color: {playerColor}");
                        return;
                    }
                }
            }
            else // Bots (Players 2-8)
            {
                List<string> savedCharacters = CharacterData.GetSavedCharactersList();
                if (savedCharacters.Count > 0)
                {
                    string randomCharacter = savedCharacters[Random.Range(0, savedCharacters.Count)];
                    CharacterData charData = CharacterData.LoadCharacter(randomCharacter);
                    if (charData != null && charData.properties != null)
                    {
                        properties = charData.properties.ToPlayerProperties();
                        playerColor = charData.playerColor; // Set the color
                        ApplyColorToPlayer(); // Apply the color
                        Debug.Log($"Bot {playerMove.PlayerId} assigned: {charData.characterName}, Color: {playerColor}");

                        string botDataKey = $"Player{playerMove.PlayerId + 1}_Data";
                        PlayerPrefs.SetString(botDataKey, JsonUtility.ToJson(charData));
                        PlayerPrefs.Save();
                        return;
                    }
                }
            }
        }

        // Default properties assignment remains unchanged
        properties = new PlayerProperties { /* existing default values */ };
        playerColor = Color.gray; // Default color if no character data
        ApplyColorToPlayer();
    }

    void ApplyColorToPlayer()
    {
        // Apply color to main player renderer
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = playerColor;
            Debug.Log($"Applied color {playerColor} to Player {GetComponent<PlayerMove>()?.PlayerId}");
        }
        else
        {
            Debug.LogWarning("No Renderer found on Player object. Color not applied.");
        }

        // Apply same color to all child renderers (including the mutant model)
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer childRenderer in childRenderers)
        {
            // Skip if it's the same renderer we already colored
            if (childRenderer == renderer) continue;

            // Apply the color to each material in the child renderer
            foreach (Material material in childRenderer.materials)
            {
                material.color = playerColor;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        Debug.Log("Click");


    }

    //events
    public void ModifyHealth(int amount)
    {
        properties.Health = Mathf.Clamp(properties.Health + amount, 0, properties.MaxHealth);
        Debug.Log($"Player health modified by {amount}. New health: {properties.Health}");
    }

    public void ModifyGold(int amount)
    {
        properties.Gold += amount;
        Debug.Log($"Player gold modified by {amount}. New gold: {properties.Gold}");
    }

    public void ModifyMana(int amount)
    {
        properties.Mana = Mathf.Clamp(properties.Mana - amount, 0, properties.MaxMana);
        Debug.Log($"Player mana is now: {properties.Mana}/{properties.MaxMana}");
    }

    public float CalculateDamageReduction(int incomingDamage)
    {
        //increase to make luck matter more
        float luckScale = 0.05f;

        float baseDefense = (properties.Defense + properties.DefenseBuff);
        Debug.Log($"Defense {baseDefense}");
        float luckFactor = 1f * (1f - (1f / (1f + properties.Luck * luckScale))); // Approaches 0.5 asymptotically
        float randomFactor = Random.Range(0.5f + luckFactor, 1.5f ); // Higher luck reduces maximum damage
        float damageReduction = baseDefense / (baseDefense + 20f);
        float finalDamageMultiplier = 1f - (damageReduction * randomFactor);

        return Mathf.Clamp(incomingDamage * finalDamageMultiplier, 1, incomingDamage);
    }

    
}
