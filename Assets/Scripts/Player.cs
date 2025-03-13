//Player.cs
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Player : MonoBehaviour


{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        // Get the player's ID
        PlayerMove playerMove = GetComponent<PlayerMove>();
        if (playerMove != null)
        {
            if (playerMove.PlayerId == 0)  // Player 1
            {
                // Load the selected character for Player 1
                string player1DataJson = PlayerPrefs.GetString("Player1_Data");
                if (!string.IsNullOrEmpty(player1DataJson))
                {
                    CharacterData charData = JsonUtility.FromJson<CharacterData>(player1DataJson);
                    if (charData != null && charData.properties != null)
                    {
                        properties = charData.properties.ToPlayerProperties();
                        Debug.Log($"Loaded player 1 properties - Health: {properties.Health}, Mana: {properties.Mana}");
                        return;
                    }
                }
            }
            else  // Bots (Players 2-8)

            //TODO -- make saved characters max use of 1 per game
            {
                // Get list of saved characters
                List<string> savedCharacters = CharacterData.GetSavedCharactersList();
                if (savedCharacters.Count > 0)
                {
                    // Randomly select a character
                    string randomCharacter = savedCharacters[Random.Range(0, savedCharacters.Count)];
                    CharacterData charData = CharacterData.LoadCharacter(randomCharacter);

                    if (charData != null && charData.properties != null)
                    {
                        properties = charData.properties.ToPlayerProperties();
                        Debug.Log($"Bot {playerMove.PlayerId} assigned character: {charData.characterName} with Health: {properties.Health}, Mana: {properties.Mana}");

                        // Save the bot's character data for reference (optional)
                        string botDataKey = $"Player{playerMove.PlayerId + 1}_Data";
                        PlayerPrefs.SetString(botDataKey, JsonUtility.ToJson(charData));
                        PlayerPrefs.Save();
                        return;
                    }
                }
            }
        }


        properties = new PlayerProperties
        {
            // Status effects
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 250,
            MaxHealth = 250,
            HealthBuff = 0,

            Mana = 50,
            MaxMana = 100,
            ManaBuff = 0,

            Shield = 0,
            MaxShield = 50,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 20,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 20,
            MagicBuff = 0,

            Defense = 10,
            MaxDefense = 20,
            DefenseBuff = 0,

            Dexterity = 10,
            MaxDexterity = 20,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 20,
            AgilityBuff = 0,

            Luck = 20,
            MaxLuck = 50,
            LuckBuff = 0,

            Gold = 20,
            ExtraDice = 0
        };

        if (PlayerPrefs.HasKey("PlayerProperties"))
        {
            string propsJson = PlayerPrefs.GetString("PlayerProperties");
            properties = JsonUtility.FromJson<PlayerProperties>(propsJson);
        }

    }

    public PlayerProperties properties;

    StateManager theStateManager;

    
    
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

        float baseDefense = properties.Defense + properties.DefenseBuff;
        float luckFactor = 1f * (1f - (1f / (1f + properties.Luck * luckScale))); // Approaches 0.5 asymptotically
        float randomFactor = Random.Range(0.5f + luckFactor, 1.5f ); // Higher luck reduces maximum damage
        float damageReduction = baseDefense / (baseDefense + 20f);
        float finalDamageMultiplier = 1f - (damageReduction * randomFactor);

        return Mathf.Clamp(incomingDamage * finalDamageMultiplier, 1, incomingDamage);
    }
}
