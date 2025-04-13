//Player.cs
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        // If we are in the character build scene, delete the ModelHolder child (if any)
        if (SceneManager.GetActiveScene().name == "Character Build")
        {
            Debug.LogWarning("Player model generation skipped in Character Build scene.");
            Transform modelHolder = transform.Find("ModelHolder");
            if (modelHolder != null)
            {
                Destroy(modelHolder.gameObject);
                Debug.LogWarning("Destroyed ModelHolder on " + gameObject.name);
            }
            return;
        }

        theStateManager = GameObject.FindFirstObjectByType<StateManager>();
        isBot = false;
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
                        characterData = charData; // Store the charData for use in UpdatePlayerModel
                        properties = charData.properties.ToPlayerProperties();
                        playerColor = charData.playerColor;
                        ApplyColorToPlayer();
                        Debug.Log($"Loaded Player 1: Health: {properties.Health}, Color: {playerColor}");
                        // REMOVED return statement
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
                        characterData = charData; // Store the charData for use in UpdatePlayerModel
                        properties = charData.properties.ToPlayerProperties();
                        playerColor = charData.playerColor;
                        ApplyColorToPlayer();
                        Debug.Log($"Bot {playerMove.PlayerId} assigned: {charData.characterName}, Color: {playerColor}");

                        string botDataKey = $"Player{playerMove.PlayerId + 1}_Data";
                        PlayerPrefs.SetString(botDataKey, JsonUtility.ToJson(charData));
                        PlayerPrefs.Save();
                        // REMOVED return statement
                    }
                }
            }
        }

        // Only set default properties if no character data was loaded
        if (properties == null)
        {
            properties = new PlayerProperties();
            playerColor = Color.gray;
            ApplyColorToPlayer();
        }

        // This code will now always execute
        Debug.Log("********** PLAYER START METHOD RUNNING **********");
        Debug.Log("********** TRYING TO CREATE PLAYER MODEL **********");
        UpdatePlayerModel();
        Debug.Log("********** AFTER UPDATING PLAYER MODEL **********");
    }

    private IEnumerator DelayedModelUpdate()
    {
        Debug.Log($"[{Time.time}] DelayedModelUpdate STARTED for Player {GetComponent<PlayerMove>()?.PlayerId}");

        // Wait a bit longer to ensure everything else is initialized
        yield return new WaitForSeconds(0.5f);

        Debug.Log($"[{Time.time}] DelayedModelUpdate calling UpdatePlayerModel for Player {GetComponent<PlayerMove>()?.PlayerId}");
        UpdatePlayerModel();

        Debug.Log($"[{Time.time}] DelayedModelUpdate COMPLETED for Player {GetComponent<PlayerMove>()?.PlayerId}");

        // Check if model was created
        Transform modelHolder = transform.Find("ModelHolder");
        if (modelHolder != null)
        {
            Debug.Log($"[{Time.time}] After update, ModelHolder has {modelHolder.childCount} children");
        }
        else
        {
            Debug.LogError($"[{Time.time}] After update, ModelHolder is still null!");
        }
    }

    public void UpdatePlayerModel()
    {

        // Add timestamp to distinguish between different calls
        Debug.Log($"[{Time.time}] UpdatePlayerModel START for Player {GetComponent<PlayerMove>()?.PlayerId}");

        if (characterData == null)
        {
            Debug.LogError($"[{Time.time}] Character data is null for Player {GetComponent<PlayerMove>()?.PlayerId}!");
            return;
        }

        // Log character info
        Debug.Log($"[{Time.time}] Character: {characterData.characterName}, Race: {characterData.race}, Gender: {characterData.gender ?? "Not set"}");

        // First check if ModelHolder exists directly
        Transform modelHolder = transform.Find("ModelHolder");
        Debug.Log($"[{Time.time}] Direct ModelHolder search result: {(modelHolder != null ? "FOUND" : "NOT FOUND")}");

        // List all children to debug hierarchy
        Debug.Log($"[{Time.time}] Player {GetComponent<PlayerMove>()?.PlayerId} has {transform.childCount} direct children:");
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log($"[{Time.time}] -- Child {i}: {transform.GetChild(i).name}");
        }

        if (modelHolder == null)
        {
            Debug.Log($"[{Time.time}] Creating new ModelHolder as child of Player {GetComponent<PlayerMove>()?.PlayerId}");
            GameObject holderObj = new GameObject("ModelHolder");
            modelHolder = holderObj.transform;
            modelHolder.SetParent(transform); // This makes it a child of Player
            modelHolder.localPosition = Vector3.zero;
            Debug.Log($"[{Time.time}] ModelHolder created. Now Player has {transform.childCount} children.");
        }
        else
        {
            Debug.Log($"[{Time.time}] Found existing ModelHolder with {modelHolder.childCount} children");
        }

        // Get RaceManager
        RaceManager raceManager = GameObject.FindObjectOfType<RaceManager>();
        if (raceManager == null)
        {
            Debug.LogError($"[{Time.time}] RaceManager not found in scene!");
            return;
        }

        // Get race properties
        RaceProperty raceProp = raceManager.GetRaceProperty(characterData.race);
        if (raceProp == null)
        {
            Debug.LogError($"[{Time.time}] Race property not found for: {characterData.race}");
            return;
        }

        // Check model references
        Debug.Log($"[{Time.time}] Race: {raceProp.raceName}, Male model: {(raceProp.maleCharacterModel != null ? raceProp.maleCharacterModel.name : "NULL")}");
        Debug.Log($"[{Time.time}] Race: {raceProp.raceName}, Female model: {(raceProp.femaleCharacterModel != null ? raceProp.femaleCharacterModel.name : "NULL")}");

        // Clear any existing models
        if (modelHolder.childCount > 0)
        {
            Debug.Log($"[{Time.time}] Clearing {modelHolder.childCount} existing models from ModelHolder");
            for (int i = modelHolder.childCount - 1; i >= 0; i--)
            {
                string childName = modelHolder.GetChild(i).name;
                Destroy(modelHolder.GetChild(i).gameObject);
                Debug.Log($"[{Time.time}] Destroyed child model: {childName}");
            }
        }

        // Determine which model to use based on gender
        string gender = !string.IsNullOrEmpty(characterData.gender) ? characterData.gender : "Male";
        GameObject prefabToInstantiate = null;

        if (gender == "Female" && raceProp.femaleCharacterModel != null)
        {
            prefabToInstantiate = raceProp.femaleCharacterModel;
            Debug.Log($"[{Time.time}] Using female model: {prefabToInstantiate.name}");
        }
        else if (raceProp.maleCharacterModel != null)
        {
            prefabToInstantiate = raceProp.maleCharacterModel;
            Debug.Log($"[{Time.time}] Using male model: {prefabToInstantiate.name}");
        }
        else
        {
            Debug.LogError($"[{Time.time}] No valid model prefab found for race {raceProp.raceName}!");

            // Create a visible fallback model so we know something happened
            GameObject fallbackCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            fallbackCube.transform.SetParent(modelHolder);
            fallbackCube.transform.localPosition = new Vector3(0, 1.0f, 0);
            fallbackCube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            fallbackCube.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log($"[{Time.time}] Created fallback cube model");
            return;
        }

        // Instantiate the character model
        GameObject characterModel = Instantiate(prefabToInstantiate, modelHolder);
        characterModel.transform.localPosition = new Vector3(0, .09f, 0);  // Position above the game piece
        characterModel.transform.localScale = Vector3.one;
        Debug.Log($"[{Time.time}] Instantiated character model {characterModel.name} at position {characterModel.transform.position}");

        Debug.Log($"[{Time.time}] UpdatePlayerModel COMPLETED for Player {GetComponent<PlayerMove>()?.PlayerId}");
    }

    void ApplyColorToPlayer()
    {
        // Look for the Basemesh by name
        Transform baseMeshTransform = transform.Find("BaseMesh");
        if (baseMeshTransform != null)
        {
            Renderer baseMeshRenderer = baseMeshTransform.GetComponent<Renderer>();
            if (baseMeshRenderer != null)
            {
                baseMeshRenderer.material.color = playerColor;
                Debug.Log($"Applied color {playerColor} to Basemesh on Player {GetComponent<PlayerMove>()?.PlayerId}");
            }
            else
            {
                Debug.LogWarning("Basemesh found but it doesn't have a Renderer component.");
            }
        }
        else
        {
            Debug.LogWarning("Basemesh not found on this Player object!");
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
