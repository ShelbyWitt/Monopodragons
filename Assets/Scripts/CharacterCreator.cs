//CharacterCreator.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class CharacterCreator : MonoBehaviour
{
    private RaceManager raceManager;
    private ClassManager classManager;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_InputField nameInput;

    public string selectedRace = "Human";
    public string selectedClass = "Warrior";
    private string characterName = "";

    void Start()
    {
        raceManager = GameObject.FindFirstObjectByType<RaceManager>();
        classManager = GameObject.FindFirstObjectByType<ClassManager>();

        // Verify managers exist
        if (raceManager == null)
        {
            Debug.LogError("RaceManager not found in scene! Please add a RaceManager to your scene.");
            return;
        }
        if (classManager == null)
        {
            Debug.LogError("ClassManager not found in scene! Please add a ClassManager to your scene.");
            return;
        }

        // Populate race dropdown from RaceData via RaceManager
        if (raceDropdown != null)
        {
            List<string> raceNames = raceManager.GetRaceNames();
            raceDropdown.ClearOptions();
            raceDropdown.AddOptions(raceNames);
            raceDropdown.onValueChanged.AddListener(OnRaceSelected);
        }
        else
        {
            Debug.LogError("Race Dropdown not assigned in inspector!");
        }

        if (classDropdown != null)
        {
            List<string> classNames = classManager.GetClassNames();
            classDropdown.ClearOptions();

            classDropdown.AddOptions(classNames);
            classDropdown.onValueChanged.AddListener(OnClassSelected);
        }
        else
        {
            Debug.LogError("Class Dropdown not assigned in inspector!");
        }

        if (nameInput != null)
        {
            nameInput.onValueChanged.AddListener(OnNameChanged);
            characterName = nameInput.text;
        }
        else
        {
            Debug.LogError("Name Input field not assigned in inspector!");
        }

        LoadTemporarySelections();
    }

    // Rest of your existing methods remain unchanged (OnRaceSelected, CombineProperties, etc.)


void ClearTemporarySelections()
    {
        PlayerPrefs.DeleteKey("TempCharacterName");
        PlayerPrefs.DeleteKey("TempRace");
        PlayerPrefs.DeleteKey("TempClass");
        PlayerPrefs.Save();
    }

    public void ClearAllSavedCharacters()
    {
        List<string> savedCharacters = CharacterData.GetSavedCharactersList();
        foreach (string charName in savedCharacters)
        {
            PlayerPrefs.DeleteKey("Character_" + charName);
        }
        PlayerPrefs.DeleteKey("SavedCharacters");
        PlayerPrefs.Save();
        Debug.Log("All saved characters cleared");
    }

    public PlayerProperties CombineProperties()
    {
        PlayerProperties raceProps = raceManager.GetRaceProperties(selectedRace);
        PlayerProperties classProps = classManager.GetClassProperties(selectedClass);

        Debug.Log($"Race base stats - Health: {raceProps.Health}, Mana: {raceProps.Mana}");
        Debug.Log($"Class multipliers - Health: {classProps.Health}, Mana: {classProps.Mana}");

        PlayerProperties combinedProps = new PlayerProperties
        {
            // Status effects (always start false)
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isTouchingWater = false,

            // Status effect amounts (start at 0)
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,

            // Take higher resistance between race and class
            PoisonResistance = Mathf.Max(raceProps.PoisonResistance, classProps.PoisonResistance),
            FireResistance = Mathf.Max(raceProps.FireResistance, classProps.FireResistance),
            FreezeResistance = Mathf.Max(raceProps.FreezeResistance, classProps.FreezeResistance),
            ShockResistance = Mathf.Max(raceProps.ShockResistance, classProps.ShockResistance),
            CursedResistance = Mathf.Max(raceProps.CursedResistance, classProps.CursedResistance),

            // Combine base stats and class multipliers
            Health = raceProps.Health + (raceProps.Health * classProps.Health / 100),
            MaxHealth = raceProps.MaxHealth + (raceProps.MaxHealth * classProps.MaxHealth / 100),
            HealthBuff = 0,

            Mana = raceProps.Mana + (raceProps.Mana * classProps.Mana / 100),
            MaxMana = raceProps.MaxMana + (raceProps.MaxMana * classProps.MaxMana / 100),
            ManaBuff = 0,

            Shield = raceProps.Shield + (raceProps.Shield * classProps.Shield / 100),
            MaxShield = raceProps.MaxShield + (raceProps.MaxShield * classProps.MaxShield / 100),
            ShieldBuff = 0,

            Strength = raceProps.Strength + (raceProps.Strength * classProps.Strength / 100),
            MaxStrength = raceProps.MaxStrength + (raceProps.MaxStrength * classProps.MaxStrength / 100),
            StrengthBuff = 0,

            Magic = raceProps.Magic + (raceProps.Magic * classProps.Magic / 100),
            MaxMagic = raceProps.MaxMagic + (raceProps.MaxMagic * classProps.MaxMagic / 100),
            MagicBuff = 0,

            Defense = raceProps.Defense + (raceProps.Defense * classProps.Defense / 100),
            MaxDefense = raceProps.MaxDefense + (raceProps.MaxDefense * classProps.MaxDefense / 100),
            DefenseBuff = 0,

            Dexterity = raceProps.Dexterity + (raceProps.Dexterity * classProps.Dexterity / 100),
            MaxDexterity = raceProps.MaxDexterity + (raceProps.MaxDexterity * classProps.MaxDexterity / 100),
            DexterityBuff = 0,

            Agility = raceProps.Agility + (raceProps.Agility * classProps.Agility / 100),
            MaxAgility = raceProps.MaxAgility + (raceProps.MaxAgility * classProps.MaxAgility / 100),
            AgilityBuff = 0,

            Luck = raceProps.Luck + (raceProps.Luck * classProps.Luck / 100),
            MaxLuck = raceProps.MaxLuck + (raceProps.MaxLuck * classProps.MaxLuck / 100),
            LuckBuff = 0,

            Intelligence = raceProps.Intelligence + (raceProps.Intelligence * classProps.Intelligence / 100),
            MaxIntelligence = raceProps.MaxIntelligence + (raceProps.MaxIntelligence * classProps.MaxIntelligence / 100),
            IntelligenceBuff = 0,

            Gold = raceProps.Gold,
            ExtraDice = 0
        };

       
        Debug.Log($"Combined stats - Health: {combinedProps.Health}, Mana: {combinedProps.Mana}");
        return combinedProps;
    }

    void OnRaceSelected(int index)
    {
        selectedRace = raceDropdown.options[index].text;
        SaveTemporarySelections();
    }

    void OnClassSelected(int index)
    {
        selectedClass = classDropdown.options[index].text;
        SaveTemporarySelections();
    }

    public void OnNameChanged(string newName)
    {
        characterName = newName;
        SaveTemporarySelections();
    }

    void SaveTemporarySelections()
    {
        PlayerPrefs.SetString("TempCharacterName", characterName);
        PlayerPrefs.SetString("TempRace", selectedRace);
        PlayerPrefs.SetString("TempClass", selectedClass);
        PlayerPrefs.Save();
    }

    void LoadTemporarySelections()
    {
        characterName = PlayerPrefs.GetString("TempCharacterName", "");
        selectedRace = PlayerPrefs.GetString("TempRace", "Human");
        selectedClass = PlayerPrefs.GetString("TempClass", "Warrior");

        if (nameInput != null)
            nameInput.text = characterName;

        if (raceDropdown != null)
            raceDropdown.value = raceDropdown.options.FindIndex(option => option.text == selectedRace);

        if (classDropdown != null)
            classDropdown.value = classDropdown.options.FindIndex(option => option.text == selectedClass);
    }

    public void SaveCharacter()
    {
        if (nameInput != null)
        {
            characterName = nameInput.text;
        }

        if (string.IsNullOrWhiteSpace(characterName))
        {
            Debug.LogWarning("Character name is required!");
            return;
        }

        Debug.Log($"Attempting to save character: {characterName}, Race: {selectedRace}, Class: {selectedClass}");

        try
        {
            // Get base properties
            PlayerProperties combinedProps = CombineProperties();

            // Create character data
            CharacterData characterData = new CharacterData(characterName, selectedRace, selectedClass, combinedProps);

            // Generate skills
            SkillGenerator skillGen = GameObject.FindFirstObjectByType<SkillGenerator>();
            if (skillGen != null)
            {
                // Generate 3 skills (2 attacks, 1 support)
                characterData.skills = skillGen.GenerateSkillSet(selectedRace, selectedClass, 2, 1);
                Debug.Log($"Generated {characterData.skills.Count} skills for {characterName}");
                foreach (Skill skill in characterData.skills)
                {
                    Debug.Log($"Generated skill: {skill.skillName} - {skill.description}");
                }
            }
            else
            {
                Debug.LogWarning("SkillGenerator not found in scene!");
                characterData.skills = new List<Skill>();
            }

            // Save the character data
            string json = JsonUtility.ToJson(characterData);
            PlayerPrefs.SetString("Character_" + characterName, json);

            List<string> savedCharacters = CharacterData.GetSavedCharactersList();
            if (!savedCharacters.Contains(characterName))
            {
                savedCharacters.Add(characterName);
                string charactersJson = JsonUtility.ToJson(new StringList { strings = savedCharacters.ToArray() });
                PlayerPrefs.SetString("SavedCharacters", charactersJson);
            }
            PlayerPrefs.Save();

            Debug.Log($"Character {characterName} saved successfully with {characterData.skills?.Count ?? 0} skills");

            // Clear temporary selections
            ClearTemporarySelections();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save character: {e.Message}");
        }
    }

    // Your existing CombineProperties method stays the same
}