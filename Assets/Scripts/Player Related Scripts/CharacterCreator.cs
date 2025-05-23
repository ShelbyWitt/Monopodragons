//CharacterCreator.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class CharacterCreator : MonoBehaviour
{
    private RaceManager raceManager;
    private ClassManager classManager;
    private PetManager petManager;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown classDropdown;
    public TMP_Dropdown colorDropdown; // For color selection
    public TMP_InputField nameInput;

    public TMP_Dropdown genderDropdown;

    public Transform modelDisplayLocation;

    public string selectedRace = "Human";
    public string selectedClass = "Warrior";
    public string selectedPet = "Ninja";
    private string selectedColorName = "Gray"; // Default color updated to Gray
    private string selectedGender = "Male"; //Default
    private string characterName = "";


    private GameObject currentCharacterModel;

    // NEW: A public offset value to raise the player model above the base.
    [Tooltip("Raise the player model by this many units relative to the ModelDisplayLocation.")]
    public float modelYOffset = 1.0f;  // Adjust this value in the Inspector

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

        // Populate Gender Dropdown
        if (genderDropdown != null)
        {
            genderDropdown.ClearOptions();
            genderDropdown.AddOptions(new List<string> { "Male", "Female" });
            genderDropdown.onValueChanged.AddListener(OnGenderSelected);
        }
        else Debug.LogError("Gender Dropdown not assigned! ; Defaulting to male");

        // Handle name input
        if (nameInput != null)
        {
            nameInput.onValueChanged.AddListener(OnNameChanged);
            characterName = nameInput.text;
        }
        else Debug.LogError("Name Input field not assigned!");

        LoadTemporarySelections();

        UpdateCharacterModel();
    }

    void OnRaceSelected(int index)
    {
        selectedRace = raceDropdown.options[index].text;
        SaveTemporarySelections();
        UpdateCharacterModel();     //update model when race changes
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
        UpdateCharacterModel();     //update model color if applicable
    }

    public void OnGenderSelected(int index)
    {
        selectedGender = genderDropdown.options[index].text;
        SaveTemporarySelections();
        UpdateCharacterModel();     //Update model when gender changes
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
        PlayerPrefs.SetString("TempGender", selectedGender);
        PlayerPrefs.Save();
    }

    void LoadTemporarySelections()
    {
        characterName = PlayerPrefs.GetString("TempCharacterName", "");
        selectedRace = PlayerPrefs.GetString("TempRace", "Human");
        selectedClass = PlayerPrefs.GetString("TempClass", "Warrior");
        selectedColorName = PlayerPrefs.GetString("TempColor", "Gray"); // Default updated to Gray
        selectedGender = PlayerPrefs.GetString("TempGender", "Male");

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
        if (genderDropdown != null)
        {
            int genderIndex = genderDropdown.options.FindIndex(option => option.text == selectedGender);
            genderDropdown.value = genderIndex >= 0 ? genderIndex : 0;
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
            characterData.gender = selectedGender;

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

    void UpdateCharacterModelForPreview()
    {
        if (modelDisplayLocation == null)
        {
            Debug.LogWarning("Model Display Location not assigned!");
            return;
        }

        // Remove any previous preview model.
        if (currentCharacterModel != null)
        {
            Destroy(currentCharacterModel);
        }

        // Retrieve the race property (add this helper method in RaceManager if necessary).
        RaceProperty raceProp = raceManager.GetRaceProperty(selectedRace);
        if (raceProp == null)
        {
            Debug.LogWarning("Race property not found for: " + selectedRace);
            return;
        }

        // Choose the prefab based on the selected gender.
        GameObject prefabToInstantiate = null;
        if (selectedGender == "Female" && raceProp.femaleCharacterModel != null)
        {
            prefabToInstantiate = raceProp.femaleCharacterModel;
        }
        else
        {
            prefabToInstantiate = raceProp.maleCharacterModel;
        }

        if (prefabToInstantiate == null)
        {
            Debug.LogWarning("No prefab found for the selected race/gender combination.");
            return;
        }

        // Instantiate the prefab as a child of the model display location.
        currentCharacterModel = Instantiate(prefabToInstantiate,
                                              modelDisplayLocation.position,
                                              modelDisplayLocation.rotation,
                                              modelDisplayLocation);

        // Raise the model above the base by modelYOffset.
        currentCharacterModel.transform.localPosition += new Vector3(0, modelYOffset, 0);

        // Rotate the model 180 degrees on the Y axis so it faces the camera.
        currentCharacterModel.transform.localRotation = Quaternion.Euler(0, 180, 0);

        // OPTIONAL: Apply color change if desired.
        Renderer modelRenderer = currentCharacterModel.GetComponentInChildren<Renderer>();
        if (modelRenderer != null && ColorManager.ColorOptions.ContainsKey(selectedColorName))
        {
            modelRenderer.material.color = ColorManager.ColorOptions[selectedColorName];
        }
    }


    // NEW: Update the character model based on race and gender
    void UpdateCharacterModel()
    {
        if (modelDisplayLocation == null)
        {
            Debug.LogWarning("Model Display Location not assigned!");
            return;
        }

        // Destroy the previous model if it exists
        if (currentCharacterModel != null)
        {
            Destroy(currentCharacterModel);
        }

        // Use a custom helper from RaceManager to get the entire RaceProperty
        // (Add the following method to RaceManager if it�s not already there:
        //   public RaceProperty GetRaceProperty(string raceName) { � } )
        RaceProperty raceProp = raceManager.GetRaceProperty(selectedRace);
        if (raceProp == null)
        {
            Debug.LogWarning("Race property not found for: " + selectedRace);
            return;
        }

        // Choose the prefab based on gender
        GameObject prefabToInstantiate = null;
        if (selectedGender == "Female" && raceProp.femaleCharacterModel != null)
        {
            prefabToInstantiate = raceProp.femaleCharacterModel;
        }
        else
        {
            prefabToInstantiate = raceProp.maleCharacterModel;
        }

        if (prefabToInstantiate == null)
        {
            Debug.LogWarning("No prefab found for the selected race/gender combination.");
            return;
        }

        // Instantiate the prefab as a child of the model display location.
        currentCharacterModel = Instantiate(prefabToInstantiate,
                                            modelDisplayLocation.position,
                                            modelDisplayLocation.rotation,
                                            modelDisplayLocation);

        // Raise it above the base
        currentCharacterModel.transform.localPosition += new Vector3(0, modelYOffset, 0);

        // Rotate 180 degrees on Y so it faces the camera
        currentCharacterModel.transform.localRotation = Quaternion.Euler(0, 180, 0);

        // ...search inside modelDisplayLocation for "BaseMesh":
        Transform baseTransform = modelDisplayLocation.Find("BaseMesh");
        if (baseTransform != null)
        {
            Renderer baseRenderer = baseTransform.GetComponent<Renderer>();
            if (baseRenderer != null && ColorManager.ColorOptions.ContainsKey(selectedColorName))
            {
                baseRenderer.material.color = ColorManager.ColorOptions[selectedColorName];
            }
        }


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