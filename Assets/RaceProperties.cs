//RaceProperties.cs
using UnityEngine;

public class RaceProperties : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnValidate()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        HumanProperties = new PlayerProperties
        {
            //HUMAN CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 13,
            MaxDefense = 57,
            DefenseBuff = 0,

            Dexterity = 10,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 15,
            MaxLuck = 62,
            LuckBuff = 0,

            Intelligence = 20,
            MaxIntelligence = 84,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        GiantProperties = new PlayerProperties
        {
            //GIANT CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 75,
            MaxHealth = 85,
            HealthBuff = 0,

            Mana = 25,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 17,
            MaxShield = 24,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 98,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 17,
            MaxDefense = 85,
            DefenseBuff = 0,

            Dexterity = 6,
            MaxDexterity = 49,
            DexterityBuff = 0,

            Agility = 9,
            MaxAgility = 37,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 37,
            LuckBuff = 0,

            Intelligence = 25,
            MaxIntelligence = 61,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        ElfProperties = new PlayerProperties
        {
            //ELF CHART

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
            ShockResistance = 10,
            CursedResistance = 20,

            // Base stats
            Health = 55,
            MaxHealth = 43,
            HealthBuff = 0,

            Mana = 70,
            MaxMana = 69,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 21,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 21,
            StrengthBuff = 0,

            Magic = 18,
            MaxMagic = 74,
            MagicBuff = 0,

            Defense = 11,
            MaxDefense = 43,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 69,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 11,
            AgilityBuff = 0,

            Luck = 19,
            MaxLuck = 53,
            LuckBuff = 0,

            Intelligence = 25,
            MaxIntelligence = 96,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        WerewolfProperties = new PlayerProperties
        {
            //WEREWOLF CHART

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
            FreezeResistance = 20,
            ShockResistance = 0,
            CursedResistance = 20,

            // Base stats
            Health = 70,
            MaxHealth = 70,
            HealthBuff = 0,

            Mana = 40,
            MaxMana = 30,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 20,
            MaxStrength = 75,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 15,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 60,
            DefenseBuff = 0,

            Dexterity = 18,
            MaxDexterity = 65,
            DexterityBuff = 0,

            Agility = 19,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 8,
            MaxLuck = 40,
            LuckBuff = 0,

            Intelligence = 13,
            MaxIntelligence = 80,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        DwarfProperties = new PlayerProperties
        {
            //DWARF CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 20,
            CursedResistance = 0,

            // Base stats
            Health = 55,
            MaxHealth = 70,
            HealthBuff = 0,

            Mana = 75,
            MaxMana = 29,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 23,
            ShieldBuff = 0,

            Strength = 13,
            MaxStrength = 70,
            StrengthBuff = 0,

            Magic = 18,
            MaxMagic = 23,
            MagicBuff = 0,

            Defense = 11,
            MaxDefense = 70,
            DefenseBuff = 0,

            Dexterity = 14,
            MaxDexterity = 46,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 17,
            MaxLuck = 58,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 76,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        OgreProperties = new PlayerProperties
        {
            //OGRE CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 70,
            MaxHealth = 92,
            HealthBuff = 0,

            Mana = 40,
            MaxMana = 13,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 100,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 18,
            MaxDefense = 79,
            DefenseBuff = 0,

            Dexterity = 8,
            MaxDexterity = 46,
            DexterityBuff = 0,

            Agility = 9,
            MaxAgility = 39,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 39,
            LuckBuff = 0,

            Intelligence = 10,
            MaxIntelligence = 60,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        TrilingProperties = new PlayerProperties
        {
            //TRILING CHART

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
            FireResistance = 10,
            FreezeResistance = 15,
            ShockResistance = 10,
            CursedResistance = 20,

            // Base stats
            Health = 35,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 70,
            MaxMana = 70,
            ManaBuff = 0,

            Shield = 18,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 15,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 70,
            MagicBuff = 0,

            Defense = 18,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 15,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 10,
            MaxLuck = 55,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        MorphlingProperties = new PlayerProperties
        {
            //MORPHLING CHART

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
            PoisonResistance = 10,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 10,

            // Base stats
            Health = 65,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 80,
            MaxMana = 60,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 14,
            MaxStrength = 25,
            StrengthBuff = 0,

            Magic = 19,
            MaxMagic = 60,
            MagicBuff = 0,

            Defense = 10,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 65,
            DexterityBuff = 0,

            Agility = 8,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 10,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 10,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        ChangelingProperties = new PlayerProperties
        {
            //CHANGELING CHART

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
            PoisonResistance = 10,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 10,

            // Base stats
            Health = 65,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 80,
            MaxMana = 65,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 25,
            StrengthBuff = 0,

            Magic = 18,
            MaxMagic = 65,
            MagicBuff = 0,

            Defense = 13,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 10,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 8,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        MinotaurProperties = new PlayerProperties
        {
            //MINOTAUR CHART

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
            PoisonResistance = 5,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 0,

            // Base stats
            Health = 75,
            MaxHealth = 81,
            HealthBuff = 0,

            Mana = 65,
            MaxMana = 19,
            ManaBuff = 0,

            Shield = 18,
            MaxShield = 25,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 94,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 13,
            MagicBuff = 0,

            Defense = 17,
            MaxDefense = 75,
            DefenseBuff = 0,

            Dexterity = 20,
            MaxDexterity = 50,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 38,
            AgilityBuff = 0,

            Luck = 18,
            MaxLuck = 38,
            LuckBuff = 0,

            Intelligence = 5,
            MaxIntelligence = 67,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        TrollProperties = new PlayerProperties
        {
            //TROLL CHART

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
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 10,
            CursedResistance = 0,

            // Base stats
            Health = 60,
            MaxHealth = 93,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 13,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 100,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 7,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 80,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 47,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 40,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 60,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        UndeadProperties = new PlayerProperties
        {
            //UNDEAD CHART

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
            PoisonResistance = 10,
            FireResistance = -10,
            FreezeResistance = -5,
            ShockResistance = 0,
            CursedResistance = 15,

            // Base stats
            Health = 60,
            MaxHealth = 67,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 27,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 80,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 53,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 40,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 66,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        SkeletonProperties = new PlayerProperties
        {
            //SKELETON CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 15,

            // Base stats
            Health = 60,
            MaxHealth = 51,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 17,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 17,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 59,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 8,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 52,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 100,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 76,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 51,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 69,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        GhoulProperties = new PlayerProperties
        {
            //GHOUL CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 10,

            // Base stats
            Health = 60,
            MaxHealth = 62,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 23,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 69,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 8,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 54,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 92,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 69,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 46,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 62,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        TieflingProperties = new PlayerProperties
        {
            //TIEFLING CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 60,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 65,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 20,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 70,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        HighElfProperties = new PlayerProperties
        {
            //HIGH ELF CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 60,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 75,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 15,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 75,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 35,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 65,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        DarkElfProperties = new PlayerProperties
        {
            //DARK ELF CHART

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
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 10,
            CursedResistance = 0,

            // Base stats
            Health = 60,
            MaxHealth = 35,
            HealthBuff = 0,

            Mana = 55,
            MaxMana = 65,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 18,
            MaxStrength = 20,
            StrengthBuff = 0,

            Magic = 13,
            MaxMagic = 80,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 35,
            DefenseBuff = 0,

            Dexterity = 11,
            MaxDexterity = 75,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 50,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 45,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 85,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,

            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,

            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,

            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,

            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,

            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,

            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        GoblinProperties = new PlayerProperties
        {
            //GOBLIN CHART

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
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 50,
            MaxHealth = 52,
            HealthBuff = 0,

            Mana = 34,
            MaxMana = 36,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 58,
            MaxLuck = 59,
            LuckBuff = 0,

            Intelligence = 78,
            MaxIntelligence = 80,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        OrcProperties = new PlayerProperties
        {
            //ORC CHART

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
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 50,
            MaxHealth = 52,
            HealthBuff = 0,

            Mana = 34,
            MaxMana = 36,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 39,
            MaxMagic = 41,
            MagicBuff = 0,

            Defense = 54,
            MaxDefense = 56,
            DefenseBuff = 0,

            Dexterity = 58,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 56,
            MaxLuck = 58,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 79,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        GnomeProperties = new PlayerProperties
        {
            //GNOME CHART

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
            CursedResistance = 10,

            // Base stats
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 65,
            MaxDexterity = 67,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 57,
            MaxLuck = 59,
            LuckBuff = 0,

            Intelligence = 92,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        HalflingProperties = new PlayerProperties
        {
            //HALFLING CHART

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
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 65,
            MaxLuck = 67,
            LuckBuff = 0,

            Intelligence = 84,
            MaxIntelligence = 86,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        MerfolkProperties = new PlayerProperties
        {
            //MERFOLK CHART

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
            FreezeResistance = 10,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 65,
            MaxDexterity = 67,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 62,
            MaxLuck = 64,
            LuckBuff = 0,

            Intelligence = 92,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        CentaurProperties = new PlayerProperties
        {
            //CENTAUR CHART

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
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 57,
            MaxLuck = 59,
            LuckBuff = 0,

            Intelligence = 78,
            MaxIntelligence = 80,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        DragonbornProperties = new PlayerProperties
        {
            //DRAGONBORN CHART

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
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 50,
            MaxHealth = 51,
            HealthBuff = 0,

            Mana = 34,
            MaxMana = 36,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 39,
            MaxMagic = 41,
            MagicBuff = 0,

            Defense = 54,
            MaxDefense = 56,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 65,
            MaxLuck = 67,
            LuckBuff = 0,

            Intelligence = 66,
            MaxIntelligence = 68,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        KoboldProperties = new PlayerProperties
        {
            //KOBOLD CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 55,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 57,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 60,
            MaxLuck = 62,
            LuckBuff = 0,

            Intelligence = 72,
            MaxIntelligence = 74,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        VampireProperties = new PlayerProperties
        {
            //VAMPIRE CHART

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
            PoisonResistance = 10,
            FireResistance = -10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 15,

            // Base stats
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 70,
            MaxLuck = 72,
            LuckBuff = 0,

            Intelligence = 82,
            MaxIntelligence = 84,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        FairyProperties = new PlayerProperties
        {
            //FAIRY CHART

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
            CursedResistance = 10,

            // Base stats
            Health = 43,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 33,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 50,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 65,
            MaxDexterity = 67,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 57,
            MaxLuck = 59,
            LuckBuff = 0,

            Intelligence = 90,
            MaxIntelligence = 92,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        FirbolgProperties = new PlayerProperties
        {
            //FIRBOLG CHART

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
            CursedResistance = 10,

            // Base stats
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 55,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 84,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        YuanTiProperties = new PlayerProperties
        {
            //YUAN-TI CHART

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
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 57,
            MaxDexterity = 59,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 70,
            MaxLuck = 70,
            LuckBuff = 0,

            Intelligence = 87,
            MaxIntelligence = 89,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        KenkuProperties = new PlayerProperties
        {
            //KENKU CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 79,
            MaxIntelligence = 82,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        TabaxiProperties = new PlayerProperties
        {
            //TABAXI CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 65,
            MaxLuck = 65,
            LuckBuff = 0,

            Intelligence = 79,
            MaxIntelligence = 81,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        AasimarProperties = new PlayerProperties
        {
            //AASIMAR CHART

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
            CursedResistance = 15,

            // Base stats
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 60,
            MaxStrength = 62,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 55,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 70,
            MaxLuck = 72,
            LuckBuff = 0,

            Intelligence = 79,
            MaxIntelligence = 81,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        GenasiProperties = new PlayerProperties
        {
            //GENASI CHART

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
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 55,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 60,
            MaxLuck = 62,
            LuckBuff = 0,

            Intelligence = 92,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        BugbearProperties = new PlayerProperties
        {
            //BUGBEAR CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 65,
            MaxDexterity = 67,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 81,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        GnollProperties = new PlayerProperties
        {
            //GNOLL CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 55,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 84,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        SatyrProperties = new PlayerProperties
        {
            //SATYR CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 79,
            MaxIntelligence = 82,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };

        HarpyProperties = new PlayerProperties
        {
            //HARPY CHART

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
            Health = 45,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 53,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 29,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 65,
            MaxLuck = 65,
            LuckBuff = 0,

            Intelligence = 79,
            MaxIntelligence = 81,
            IntelligenceBuff = 0,

            Attack = 0,
            MaxAttack = 0,
            AttackBuff = 0,
            Speed = 0,
            MaxSpeed = 0,
            SpeedBuff = 0,
            CriticalChance = 0,
            MaxCriticalChance = 0,
            CriticalChanceBuff = 0,
            CriticalDamage = 0,
            MaxCriticalDamage = 0,
            CriticalDamageBuff = 0,
            DodgeChance = 0,
            MaxDodgeChance = 0,
            DodgeChanceBuff = 0,
            Pierce = 0,
            MaxPierce = 0,
            PierceBuff = 0,
            Accuracy = 0,
            MaxAccuracy = 0,
            AccuracyBuff = 0,
            Gold = 1500,
            ExtraDice = 0
        };


    }

    public PlayerProperties HumanProperties;
    public PlayerProperties GiantProperties;
    public PlayerProperties ElfProperties;
    public PlayerProperties WerewolfProperties;
    public PlayerProperties DwarfProperties;
    public PlayerProperties OgreProperties;
    public PlayerProperties TrilingProperties;
    public PlayerProperties MorphlingProperties;
    public PlayerProperties ChangelingProperties;
    public PlayerProperties MinotaurProperties;
    public PlayerProperties TrollProperties;
    public PlayerProperties UndeadProperties;
    public PlayerProperties SkeletonProperties;
    public PlayerProperties GhoulProperties;
    public PlayerProperties TieflingProperties;
    public PlayerProperties HighElfProperties;
    public PlayerProperties DarkElfProperties;
    public PlayerProperties GoblinProperties;
    public PlayerProperties OrcProperties;
    public PlayerProperties GnomeProperties;
    public PlayerProperties HalflingProperties;
    public PlayerProperties MerfolkProperties;
    public PlayerProperties CentaurProperties;
    public PlayerProperties DragonbornProperties;
    public PlayerProperties KoboldProperties;
    public PlayerProperties VampireProperties;
    public PlayerProperties FairyProperties;
    public PlayerProperties FirbolgProperties;
    public PlayerProperties YuanTiProperties;
    public PlayerProperties KenkuProperties;
    public PlayerProperties TabaxiProperties;
    public PlayerProperties AasimarProperties;
    public PlayerProperties GenasiProperties;
    public PlayerProperties BugbearProperties;
    public PlayerProperties GnollProperties;
    public PlayerProperties SatyrProperties;
    public PlayerProperties HarpyProperties;


    StateManager theStateManager;



    private Player player;
}