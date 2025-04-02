//CharacterCreator.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class CharacterCreator : MonoBehaviour
{
    private RaceManager raceManager;
    private ClassManager classManager;
    private PetManager petManager;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_Dropdown colorDropdown; // For color selection
    public TMP_InputField nameInput;

    public string selectedRace = "Human";
    public string selectedClass = "Warrior";
    public string selectedPet = "Ninja";
    private string characterName = "";
    private string selectedColorName = "Gray"; // Default color updated to Gray

    void Start()
    {
        raceManager = GameObject.FindFirstObjectByType<RaceManager>();
        classManager = GameObject.FindFirstObjectByType<ClassManager>();

        if (raceManager == null) Debug.LogError("RaceManager not found in scene!");
        if (classManager == null) Debug.LogError("ClassManager not found in scene!");

        //PlayerPrefs.DeleteAll();      //-- TURNON IF WANT TO ERASE PLAYER LIST

        // Populate race dropdown
        if (raceDropdown != null)
        {
            List<string> raceNames = raceManager.GetRaceNames();
            raceDropdown.ClearOptions();
            raceDropdown.AddOptions(raceNames);
            raceDropdown.onValueChanged.AddListener(OnRaceSelected);
        }
        else Debug.LogError("Race Dropdown not assigned!");

        // Populate class dropdown
        if (classDropdown != null)
        {
            List<string> classNames = classManager.GetClassNames();
            classDropdown.ClearOptions();
            classDropdown.AddOptions(classNames);
            classDropdown.onValueChanged.AddListener(OnClassSelected);
        }
        else Debug.LogError("Class Dropdown not assigned!");

        // Populate color dropdown
        if (colorDropdown != null)
        {
            colorDropdown.ClearOptions();
            colorDropdown.AddOptions(new List<string>(ColorManager.ColorOptions.Keys));
            colorDropdown.onValueChanged.AddListener(OnColorSelected);
        }
        else Debug.LogError("Color Dropdown not assigned!");

        // Handle name input
        if (nameInput != null)
        {
            nameInput.onValueChanged.AddListener(OnNameChanged);
            characterName = nameInput.text;
        }
        else Debug.LogError("Name Input field not assigned!");

        LoadTemporarySelections();
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

    void OnColorSelected(int index)
    {
        selectedColorName = colorDropdown.options[index].text;
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
        PlayerPrefs.SetString("TempColor", selectedColorName); // Save color name
        PlayerPrefs.Save();
    }

    void LoadTemporarySelections()
    {
        characterName = PlayerPrefs.GetString("TempCharacterName", "");
        selectedRace = PlayerPrefs.GetString("TempRace", "Human");
        selectedClass = PlayerPrefs.GetString("TempClass", "Warrior");
        selectedColorName = PlayerPrefs.GetString("TempColor", "Gray"); // Default updated to Gray

        if (nameInput != null) nameInput.text = characterName;
        if (raceDropdown != null)
            raceDropdown.value = raceDropdown.options.FindIndex(option => option.text == selectedRace);
        if (classDropdown != null)
            classDropdown.value = classDropdown.options.FindIndex(option => option.text == selectedClass);
        if (colorDropdown != null)
        {
            int colorIndex = colorDropdown.options.FindIndex(option => option.text == selectedColorName);
            colorDropdown.value = colorIndex >= 0 ? colorIndex : 0;
        }
    }

    public void SaveCharacter()
    {
        if (nameInput != null) characterName = nameInput.text;

        if (string.IsNullOrWhiteSpace(characterName))
        {
            Debug.LogWarning("Character name is required!");
            return;
        }

        Debug.Log($"Saving character: {characterName}, Race: {selectedRace}, Class: {selectedClass}, Color: {selectedColorName}");

        try
        {
            PlayerProperties combinedProps = CombineProperties();
            CharacterData characterData = new CharacterData(characterName, selectedRace, selectedClass, combinedProps);
            characterData.playerColor = ColorManager.ColorOptions[selectedColorName]; // Set the color

            SkillGenerator skillGen = GameObject.FindFirstObjectByType<SkillGenerator>();
            if (skillGen != null)
            {
                characterData.skills = skillGen.GenerateSkillSet(selectedRace, selectedClass, 2, 2);
            }
            else
            {
                characterData.skills = new List<Skill>();
            }

            characterData.SaveCharacter();
            Debug.Log($"Character {characterName} saved with color {selectedColorName}");
            ClearTemporarySelections();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save character: {e.Message}");
        }
    }


    private void ClearTemporarySelections()
    {
        PlayerPrefs.DeleteKey("TempCharacterName");
        PlayerPrefs.DeleteKey("TempRace");
        PlayerPrefs.DeleteKey("TempClass");
        PlayerPrefs.DeleteKey("TempColor");
        PlayerPrefs.Save();
    }

    public void ClearAllSavedCharacters()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All saved characters and temporary selections cleared.");
    }

    public PlayerProperties CombineProperties()
    {
        PlayerProperties raceProps = raceManager.GetRaceProperties(selectedRace);
        PlayerProperties classProps = classManager.GetClassProperties(selectedClass);
        //PetStats petProps = petManager.GetPetProperties(selectedPet);

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts (start at 0)
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Take higher resistance between race and class
            PoisonResistance = Mathf.Max(raceProps.PoisonResistance, classProps.PoisonResistance),
            FireResistance = Mathf.Max(raceProps.FireResistance, classProps.FireResistance),
            FreezeResistance = Mathf.Max(raceProps.FreezeResistance, classProps.FreezeResistance),
            ShockResistance = Mathf.Max(raceProps.ShockResistance, classProps.ShockResistance),
            CursedResistance = Mathf.Max(raceProps.CursedResistance, classProps.CursedResistance),
            BleedResistance = Mathf.Max( raceProps.BleedResistance, classProps.BleedResistance),

            // Combine all stats to get full health, mana and shield -- all displayed in UI
            Health = raceProps.Health * (classProps.Health / 10),
            MaxHealth = raceProps.MaxHealth * (classProps.MaxHealth / 10),
            HealthBuff = 0,

            Mana = raceProps.Mana * (classProps.Mana / 10),
            MaxMana = raceProps.MaxMana * (classProps.MaxMana / 10),
            ManaBuff = 0,
            
            Shield = raceProps.Shield * (classProps.Shield / 10),
            MaxShield = raceProps.MaxShield * (classProps.MaxShield / 10),
            ShieldBuff = 0,
            
            // Combine base stats and class multipliers
            Strength = raceProps.Strength * (classProps.Strength / 10),
            MaxStrength = raceProps.MaxStrength * (classProps.MaxStrength / 10),
            StrengthBuff = 0,
            
            Magic = raceProps.Magic * (classProps.Magic / 10),
            MaxMagic = raceProps.MaxMagic * (classProps.MaxMagic / 10),
            MagicBuff = 0,
            
            Defense = raceProps.Defense * (classProps.Defense / 10),
            MaxDefense = raceProps.MaxDefense * (classProps.MaxDefense / 10),
            DefenseBuff = 0,
            
            Dexterity = raceProps.Dexterity * (classProps.Dexterity / 10),
            MaxDexterity = raceProps.MaxDexterity * (classProps.MaxDexterity / 10),
            DexterityBuff = 0,
            
            Agility = raceProps.Agility * (classProps.Agility / 10),
            MaxAgility = raceProps.MaxAgility * (classProps.MaxAgility / 10),
            AgilityBuff = 0,
            
            Luck = raceProps.Luck * (classProps.Luck / 10),
            MaxLuck = raceProps.MaxLuck * (classProps.MaxLuck / 10),
            LuckBuff = 0,
            
            Intelligence = raceProps.Intelligence * (classProps.Intelligence / 10),
            MaxIntelligence = raceProps.MaxIntelligence * (classProps.MaxIntelligence / 10),
            IntelligenceBuff = 0,
            
            Stamina = raceProps.Stamina * (classProps.Stamina / 10),
            MaxStamina = raceProps.MaxStamina * (classProps.MaxStamina / 10),
            StaminaBuff = 0,
            
            AllStats = raceProps.AllStats * (classProps.AllStats / 10),
            MaxAllStats = raceProps.MaxAllStats * (classProps.MaxAllStats / 10),
            AllStatsBuff = 0,
            
            Gold = raceProps.Gold + classProps.Gold, // Simply adding the two values as requested
            
            ExtraDice = 0
        };

       
        Debug.Log($"Combined stats - Health: {combinedProps.Health}, Mana: {combinedProps.Mana}");
        return combinedProps;
    }

    
}