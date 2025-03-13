//CharacterData.cs
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CharacterData
{
    public string characterName;
    public string characterGold;
    public string characterTitle;
    public string race;
    public string characterClass;
    public SerializablePlayerProperties properties;
    public List<Skill> skills = new List<Skill>();

    public CharacterData(string name, string selectedRace, string selectedClass, PlayerProperties props)
    {
        characterName = name;
        race = selectedRace;
        characterClass = selectedClass;
        properties = new SerializablePlayerProperties(props);

        // Generate title
        TitleGenerator titleGen = GameObject.FindFirstObjectByType<TitleGenerator>();
        if (titleGen != null)
        {
            characterTitle = titleGen.GenerateTitle(name, selectedRace, selectedClass);
        }
        else
        {
            characterTitle = name;
        }
    }

    public void RegenerateTitle()
    {
        TitleGenerator titleGen = GameObject.FindFirstObjectByType<TitleGenerator>();
        if (titleGen != null)
        {
            characterTitle = titleGen.GenerateTitle(characterName, race, characterClass);
        }
    }

    public void SaveCharacter()
    {
        string json = JsonUtility.ToJson(this);
        Debug.Log($"Saving character data with {skills?.Count ?? 0} skills: {json}");
        PlayerPrefs.SetString("Character_" + characterName, json);

        List<string> savedCharacters = GetSavedCharactersList();
        if (!savedCharacters.Contains(characterName))
        {
            savedCharacters.Add(characterName);
            string charactersJson = JsonUtility.ToJson(new StringList { strings = savedCharacters.ToArray() });
            PlayerPrefs.SetString("SavedCharacters", charactersJson);
        }
        PlayerPrefs.Save();
    }

    public static CharacterData LoadCharacter(string characterName)
    {
        string json = PlayerPrefs.GetString("Character_" + characterName);
        Debug.Log($"Loading character data: {json}"); // Debug log
        if (string.IsNullOrEmpty(json))
            return null;
        return JsonUtility.FromJson<CharacterData>(json);
    }

    public static List<string> GetSavedCharactersList()
    {
        string json = PlayerPrefs.GetString("SavedCharacters");
        if (string.IsNullOrEmpty(json))
            return new List<string>();
        StringList list = JsonUtility.FromJson<StringList>(json);
        return new List<string>(list.strings ?? new string[0]);
    }
}

[System.Serializable]
public class SerializablePlayerProperties
{
    public bool isPoisoned;
    public bool isOnFire;
    public bool isFrozen;
    public bool isShocked;
    public bool isCursed;
    public bool isTouchingWater;

    public int PoisonedAmount;
    public int FireAmount;
    public int FrozenAmount;
    public int ShockedAmount;
    public int CursedAmount;

    public int PoisonResistance;
    public int FireResistance;
    public int FreezeResistance;
    public int ShockResistance;
    public int CursedResistance;

    public int Health;
    public int MaxHealth;
    public int HealthBuff;

    public int Mana;
    public int MaxMana;
    public int ManaBuff;

    public int Shield;
    public int MaxShield;
    public int ShieldBuff;

    public int Strength;
    public int MaxStrength;
    public int StrengthBuff;

    public int Magic;
    public int MaxMagic;
    public int MagicBuff;

    public int Defense;
    public int MaxDefense;
    public int DefenseBuff;

    public int Dexterity;
    public int MaxDexterity;
    public int DexterityBuff;

    public int Agility;
    public int MaxAgility;
    public int AgilityBuff;

    public int Luck;
    public int MaxLuck;
    public int LuckBuff;

    public int Intelligence;
    public int MaxIntelligence;
    public int IntelligenceBuff;

    public int Gold;
    public int ExtraDice;

    public SerializablePlayerProperties(PlayerProperties props)
    {
        // Copy all properties
        isPoisoned = props.isPoisoned;
        isOnFire = props.isOnFire;
        isFrozen = props.isFrozen;
        isShocked = props.isShocked;
        isCursed = props.isCursed;
        isTouchingWater = props.isTouchingWater;

        PoisonedAmount = props.PoisonedAmount;
        FireAmount = props.FireAmount;
        FrozenAmount = props.FrozenAmount;
        ShockedAmount = props.ShockedAmount;
        CursedAmount = props.CursedAmount;

        PoisonResistance = props.PoisonResistance;
        FireResistance = props.FireResistance;
        FreezeResistance = props.FreezeResistance;
        ShockResistance = props.ShockResistance;
        CursedResistance = props.CursedResistance;

        Health = props.Health;
        MaxHealth = props.MaxHealth;
        HealthBuff = props.HealthBuff;

        Mana = props.Mana;
        MaxMana = props.MaxMana;
        ManaBuff = props.ManaBuff;

        Shield = props.Shield;
        MaxShield = props.MaxShield;
        ShieldBuff = props.ShieldBuff;

        Strength = props.Strength;
        MaxStrength = props.MaxStrength;
        StrengthBuff = props.StrengthBuff;

        Magic = props.Magic;
        MaxMagic = props.MaxMagic;
        MagicBuff = props.MagicBuff;

        Defense = props.Defense;
        MaxDefense = props.MaxDefense;
        DefenseBuff = props.DefenseBuff;

        Dexterity = props.Dexterity;
        MaxDexterity = props.MaxDexterity;
        DexterityBuff = props.DexterityBuff;

        Agility = props.Agility;
        MaxAgility = props.MaxAgility;
        AgilityBuff = props.AgilityBuff;

        Luck = props.Luck;
        MaxLuck = props.MaxLuck;
        LuckBuff = props.LuckBuff;

        Intelligence = props.Intelligence;
        MaxIntelligence = props.MaxIntelligence;
        IntelligenceBuff = props.IntelligenceBuff;

        Gold = props.Gold;
        ExtraDice = props.ExtraDice;
    }

    public PlayerProperties ToPlayerProperties()
    {
        return new PlayerProperties
        {
            isPoisoned = isPoisoned,
            isOnFire = isOnFire,
            isFrozen = isFrozen,
            isShocked = isShocked,
            isCursed = isCursed,
            isTouchingWater = isTouchingWater,

            PoisonedAmount = PoisonedAmount,
            FireAmount = FireAmount,
            FrozenAmount = FrozenAmount,
            ShockedAmount = ShockedAmount,
            CursedAmount = CursedAmount,

            PoisonResistance = PoisonResistance,
            FireResistance = FireResistance,
            FreezeResistance = FreezeResistance,
            ShockResistance = ShockResistance,
            CursedResistance = CursedResistance,

            Health = Health,
            MaxHealth = MaxHealth,
            HealthBuff = HealthBuff,

            Mana = Mana,
            MaxMana = MaxMana,
            ManaBuff = ManaBuff,

            Shield = Shield,
            MaxShield = MaxShield,
            ShieldBuff = ShieldBuff,

            Strength = Strength,
            MaxStrength = MaxStrength,
            StrengthBuff = StrengthBuff,

            Magic = Magic,
            MaxMagic = MaxMagic,
            MagicBuff = MagicBuff,

            Defense = Defense,
            MaxDefense = MaxDefense,
            DefenseBuff = DefenseBuff,

            Dexterity = Dexterity,
            MaxDexterity = MaxDexterity,
            DexterityBuff = DexterityBuff,

            Agility = Agility,
            MaxAgility = MaxAgility,
            AgilityBuff = AgilityBuff,

            Luck = Luck,
            MaxLuck = MaxLuck,
            LuckBuff = LuckBuff,

            Intelligence = Intelligence,
            MaxIntelligence = MaxIntelligence,
            IntelligenceBuff = IntelligenceBuff,

            Gold = Gold,
            ExtraDice = ExtraDice
        };
    }
}

[System.Serializable]
public class StringList
{
    public string[] strings;
}