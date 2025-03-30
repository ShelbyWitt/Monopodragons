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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 57,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 42,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 57,
            MaxDefense = 57,
            DefenseBuff = 0,

            Dexterity = 62,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 62,
            MaxLuck = 62,
            LuckBuff = 0,

            Intelligence = 84,
            MaxIntelligence = 84,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 25,

            // Base stats
            Health = 79,
            MaxHealth = 79,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 23,
            MaxShield = 23,
            ShieldBuff = 0,

            Strength = 94,
            MaxStrength = 94,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 82,
            MaxDefense = 82,
            DefenseBuff = 0,

            Dexterity = 47,
            MaxDexterity = 47,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 36,
            MaxLuck = 36,
            LuckBuff = 0,

            Intelligence = 59,
            MaxIntelligence = 59,
            IntelligenceBuff = 0,

            Stamina = 70,
            MaxStamina = 70,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 25,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 72,
            MaxMana = 72,
            ManaBuff = 0,

            Shield = 22,
            MaxShield = 22,
            ShieldBuff = 0,

            Strength = 22,
            MaxStrength = 22,
            StrengthBuff = 0,

            Magic = 77,
            MaxMagic = 77,
            MagicBuff = 0,

            Defense = 45,
            MaxDefense = 45,
            DefenseBuff = 0,

            Dexterity = 72,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 11,
            MaxAgility = 11,
            AgilityBuff = 0,

            Luck = 54,
            MaxLuck = 54,
            LuckBuff = 0,

            Intelligence = 100,
            MaxIntelligence = 100,
            IntelligenceBuff = 0,

            Stamina = 30,
            MaxStamina = 30,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 50,

            // Base stats
            Health = 67,
            MaxHealth = 67,
            HealthBuff = 0,

            Mana = 29,
            MaxMana = 29,
            ManaBuff = 0,

            Shield = 19,
            MaxShield = 19,
            ShieldBuff = 0,

            Strength = 77,
            MaxStrength = 77,
            StrengthBuff = 0,

            Magic = 14,
            MaxMagic = 14,
            MagicBuff = 0,

            Defense = 58,
            MaxDefense = 58,
            DefenseBuff = 0,

            Dexterity = 62,
            MaxDexterity = 62,
            DexterityBuff = 0,

            Agility = 46,
            MaxAgility = 46,
            AgilityBuff = 0,

            Luck = 38,
            MaxLuck = 38,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 77,
            IntelligenceBuff = 0,

            Stamina = 63,
            MaxStamina = 63,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 20,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 68,
            MaxHealth = 68,
            HealthBuff = 0,

            Mana = 28,
            MaxMana = 28,
            ManaBuff = 0,

            Shield = 25,
            MaxShield = 25,
            ShieldBuff = 0,

            Strength = 67,
            MaxStrength = 67,
            StrengthBuff = 0,

            Magic = 24,
            MaxMagic = 24,
            MagicBuff = 0,

            Defense = 68,
            MaxDefense = 68,
            DefenseBuff = 0,

            Dexterity = 44,
            MaxDexterity = 44,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 56,
            MaxLuck = 56,
            LuckBuff = 0,

            Intelligence = 74,
            MaxIntelligence = 74,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 88,
            MaxHealth = 88,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 20,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 96,
            MaxStrength = 96,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 76,
            MaxDefense = 76,
            DefenseBuff = 0,

            Dexterity = 44,
            MaxDexterity = 44,
            DexterityBuff = 0,

            Agility = 37,
            MaxAgility = 37,
            AgilityBuff = 0,

            Luck = 37,
            MaxLuck = 37,
            LuckBuff = 0,

            Intelligence = 58,
            MaxIntelligence = 58,
            IntelligenceBuff = 0,

            Stamina = 70,
            MaxStamina = 70,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 10,
            FreezeResistance = 15,
            ShockResistance = 10,
            CursedResistance = 20,
            BleedResistance = 20,

            // Base stats
            Health = 40,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 70,
            MaxMana = 70,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 15,
            StrengthBuff = 0,

            Magic = 70,
            MaxMagic = 70,
            MagicBuff = 0,

            Defense = 40,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 45,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 55,
            LuckBuff = 0,

            Intelligence = 90,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 10,
            BleedResistance = 10,

            // Base stats
            Health = 40,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 60,
            MaxMana = 60,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 25,
            MaxStrength = 25,
            StrengthBuff = 0,

            Magic = 60,
            MaxMagic = 60,
            MagicBuff = 0,

            Defense = 50,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 65,
            MaxDexterity = 65,
            DexterityBuff = 0,

            Agility = 45,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 50,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 90,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 10,
            BleedResistance = 10,

            // Base stats
            Health = 40,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 65,
            MaxMana = 65,
            ManaBuff = 0,

            Shield = 20,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 25,
            MaxStrength = 25,
            StrengthBuff = 0,

            Magic = 65,
            MaxMagic = 65,
            MagicBuff = 0,

            Defense = 40,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 45,
            MaxAgility = 45,
            AgilityBuff = 0,

            Luck = 50,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 90,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 5,
            FireResistance = 10,
            FreezeResistance = 10,
            ShockResistance = 10,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 80,
            MaxHealth = 80,
            HealthBuff = 0,

            Mana = 21,
            MaxMana = 21,
            ManaBuff = 0,

            Shield = 24,
            MaxShield = 24,
            ShieldBuff = 0,

            Strength = 95,
            MaxStrength = 95,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 72,
            MaxDefense = 72,
            DefenseBuff = 0,

            Dexterity = 48,
            MaxDexterity = 48,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 36,
            MaxLuck = 36,
            LuckBuff = 0,

            Intelligence = 64,
            MaxIntelligence = 64,
            IntelligenceBuff = 0,

            Stamina = 62,
            MaxStamina = 62,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 10,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 90,
            MaxHealth = 90,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 19,
            MaxShield = 19,
            ShieldBuff = 0,

            Strength = 96,
            MaxStrength = 96,
            StrengthBuff = 0,

            Magic = 7,
            MaxMagic = 7,
            MagicBuff = 0,

            Defense = 77,
            MaxDefense = 77,
            DefenseBuff = 0,

            Dexterity = 45,
            MaxDexterity = 45,
            DexterityBuff = 0,

            Agility = 38,
            MaxAgility = 38,
            AgilityBuff = 0,

            Luck = 58,
            MaxLuck = 58,
            LuckBuff = 0,

            Intelligence = 70,
            MaxIntelligence = 70,
            IntelligenceBuff = 0,

            Stamina = 0,
            MaxStamina = 0,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = -10,
            FreezeResistance = -5,
            ShockResistance = 0,
            CursedResistance = 15,
            BleedResistance = 0,

            // Base stats
            Health = 64,
            MaxHealth = 64,
            HealthBuff = 0,

            Mana = 26,
            MaxMana = 26,
            ManaBuff = 0,

            Shield = 19,
            MaxShield = 19,
            ShieldBuff = 0,

            Strength = 66,
            MaxStrength = 66,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 38,
            MagicBuff = 0,

            Defense = 77,
            MaxDefense = 77,
            DefenseBuff = 0,

            Dexterity = 55,
            MaxDexterity = 55,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 40,
            MaxLuck = 40,
            LuckBuff = 0,

            Intelligence = 65,
            MaxIntelligence = 65,
            IntelligenceBuff = 0,

            Stamina = 64,
            MaxStamina = 64,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 15,
            BleedResistance = 15,

            // Base stats
            Health = 49,
            MaxHealth = 49,
            HealthBuff = 0,

            Mana = 17,
            MaxMana = 17,
            ManaBuff = 0,

            Shield = 18,
            MaxShield = 18,
            ShieldBuff = 0,

            Strength = 57,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 51,
            MaxDefense = 51,
            DefenseBuff = 0,

            Dexterity = 96,
            MaxDexterity = 96,
            DexterityBuff = 0,

            Agility = 73,
            MaxAgility = 73,
            AgilityBuff = 0,

            Luck = 53,
            MaxLuck = 53,
            LuckBuff = 0,

            Intelligence = 66,
            MaxIntelligence = 66,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 10,
            BleedResistance = 0,

            // Base stats
            Health = 60,
            MaxHealth = 60,
            HealthBuff = 0,

            Mana = 24,
            MaxMana = 24,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 14,
            ShieldBuff = 0,

            Strength = 66,
            MaxStrength = 66,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 54,
            MaxDefense = 54,
            DefenseBuff = 0,

            Dexterity = 88,
            MaxDexterity = 88,
            DexterityBuff = 0,

            Agility = 66,
            MaxAgility = 66,
            AgilityBuff = 0,

            Luck = 48,
            MaxLuck = 48,
            LuckBuff = 0,

            Intelligence = 60,
            MaxIntelligence = 60,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 49,
            MaxHealth = 49,
            HealthBuff = 0,

            Mana = 65,
            MaxMana = 65,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 19,
            MaxStrength = 19,
            StrengthBuff = 0,

            Magic = 68,
            MaxMagic = 68,
            MagicBuff = 0,

            Defense = 40,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 40,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 49,
            MaxLuck = 49,
            LuckBuff = 0,

            Intelligence = 90,
            MaxIntelligence = 90,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 42,
            MaxHealth = 42,
            HealthBuff = 0,

            Mana = 77,
            MaxMana = 77,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 16,
            MaxStrength = 16,
            StrengthBuff = 0,

            Magic = 78,
            MaxMagic = 78,
            MagicBuff = 0,

            Defense = 36,
            MaxDefense = 36,
            DefenseBuff = 0,

            Dexterity = 68,
            MaxDexterity = 68,
            DexterityBuff = 0,

            Agility = 47,
            MaxAgility = 47,
            AgilityBuff = 0,

            Luck = 52,
            MaxLuck = 52,
            LuckBuff = 0,

            Intelligence = 94,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Stamina = 30,
            MaxStamina = 30,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 10,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 36,
            MaxHealth = 36,
            HealthBuff = 0,

            Mana = 68,
            MaxMana = 68,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 21,
            MaxStrength = 21,
            StrengthBuff = 0,

            Magic = 83,
            MaxMagic = 83,
            MagicBuff = 0,

            Defense = 36,
            MaxDefense = 36,
            DefenseBuff = 0,

            Dexterity = 78,
            MaxDexterity = 78,
            DexterityBuff = 0,

            Agility = 52,
            MaxAgility = 52,
            AgilityBuff = 0,

            Luck = 47,
            MaxLuck = 47,
            LuckBuff = 0,

            Intelligence = 89,
            MaxIntelligence = 89,
            IntelligenceBuff = 0,

            Stamina = 30,
            MaxStamina = 30,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 53,
            MaxHealth = 53,
            HealthBuff = 0,

            Mana = 39,
            MaxMana = 39,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 57,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 38,
            MaxMagic = 38,
            MagicBuff = 0,

            Defense = 58,
            MaxDefense = 58,
            DefenseBuff = 0,

            Dexterity = 71,
            MaxDexterity = 71,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 34,
            AgilityBuff = 0,

            Luck = 63,
            MaxLuck = 63,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 77,
            IntelligenceBuff = 0,

            Stamina = 45,
            MaxStamina = 45,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 50,
            MaxHealth = 50,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 20,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 64,
            MaxStrength = 64,
            StrengthBuff = 0,

            Magic = 39,
            MaxMagic = 39,
            MagicBuff = 0,

            Defense = 58,
            MaxDefense = 58,
            DefenseBuff = 0,

            Dexterity = 58,
            MaxDexterity = 58,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 34,
            AgilityBuff = 0,

            Luck = 56,
            MaxLuck = 56,
            LuckBuff = 0,

            Intelligence = 76,
            MaxIntelligence = 76,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 10,
            BleedResistance = 10,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 36,
            MaxMana = 36,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 57,
            MaxStrength = 57,
            StrengthBuff = 0,

            Magic = 42,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 57,
            MaxDefense = 57,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 61,
            MaxLuck = 61,
            LuckBuff = 0,

            Intelligence = 98,
            MaxIntelligence = 98,
            IntelligenceBuff = 0,

            Stamina = 30,
            MaxStamina = 30,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 55,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 50,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 72,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 35,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 67,
            MaxLuck = 67,
            LuckBuff = 0,

            Intelligence = 86,
            MaxIntelligence = 86,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 10,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 55,
            MaxStrength = 55,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 50,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 67,
            MaxDexterity = 67,
            DexterityBuff = 0,

            Agility = 35,
            MaxAgility = 35,
            AgilityBuff = 0,

            Luck = 64,
            MaxLuck = 64,
            LuckBuff = 0,

            Intelligence = 94,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 34,
            MaxMana = 34,
            ManaBuff = 0,

            Shield = 17,
            MaxShield = 17,
            ShieldBuff = 0,

            Strength = 64,
            MaxStrength = 64,
            StrengthBuff = 0,

            Magic = 45,
            MaxMagic = 45,
            MagicBuff = 0,

            Defense = 58,
            MaxDefense = 58,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 34,
            AgilityBuff = 0,

            Luck = 56,
            MaxLuck = 56,
            LuckBuff = 0,

            Intelligence = 77,
            MaxIntelligence = 77,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 50,
            MaxHealth = 50,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 70,
            MaxStrength = 70,
            StrengthBuff = 0,

            Magic = 41,
            MaxMagic = 41,
            MagicBuff = 0,

            Defense = 54,
            MaxDefense = 54,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 34,
            AgilityBuff = 0,

            Luck = 65,
            MaxLuck = 65,
            LuckBuff = 0,

            Intelligence = 66,
            MaxIntelligence = 66,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 40,
            MaxHealth = 40,
            HealthBuff = 0,

            Mana = 40,
            MaxMana = 40,
            ManaBuff = 0,

            Shield = 40,
            MaxShield = 40,
            ShieldBuff = 0,

            Strength = 40,
            MaxStrength = 40,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 40,
            MaxDefense = 40,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 70,
            MaxAgility = 70,
            AgilityBuff = 0,

            Luck = 60,
            MaxLuck = 60,
            LuckBuff = 0,

            Intelligence = 60,
            MaxIntelligence = 60,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 10,
            FireResistance = -10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 15,
            BleedResistance = 0,

            // Base stats
            Health = 44,
            MaxHealth = 44,
            HealthBuff = 0,

            Mana = 34,
            MaxMana = 34,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 53,
            MaxStrength = 53,
            StrengthBuff = 0,

            Magic = 50,
            MaxMagic = 50,
            MagicBuff = 0,

            Defense = 48,
            MaxDefense = 48,
            DefenseBuff = 0,

            Dexterity = 61,
            MaxDexterity = 61,
            DexterityBuff = 0,

            Agility = 34,
            MaxAgility = 34,
            AgilityBuff = 0,

            Luck = 69,
            MaxLuck = 69,
            LuckBuff = 0,

            Intelligence = 80,
            MaxIntelligence = 80,
            IntelligenceBuff = 0,

            Stamina = 62,
            MaxStamina = 62,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 10,
            BleedResistance = 10,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 36,
            MaxMana = 36,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 52,
            StrengthBuff = 0,

            Magic = 49,
            MaxMagic = 49,
            MagicBuff = 0,

            Defense = 57,
            MaxDefense = 57,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 36,
            MaxAgility = 36,
            AgilityBuff = 0,

            Luck = 61,
            MaxLuck = 61,
            LuckBuff = 0,

            Intelligence = 96,
            MaxIntelligence = 96,
            IntelligenceBuff = 0,

            Stamina = 30,
            MaxStamina = 30,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 10,
            BleedResistance = 10,

            // Base stats
            Health = 65,
            MaxHealth = 65,
            HealthBuff = 0,

            Mana = 45,
            MaxMana = 45,
            ManaBuff = 0,

            Shield = 35,
            MaxShield = 35,
            ShieldBuff = 0,

            Strength = 65,
            MaxStrength = 65,
            StrengthBuff = 0,

            Magic = 60,
            MaxMagic = 60,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 40,
            MaxDexterity = 40,
            DexterityBuff = 0,

            Agility = 40,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 45,
            MaxLuck = 45,
            LuckBuff = 0,

            Intelligence = 55,
            MaxIntelligence = 55,
            IntelligenceBuff = 0,

            Stamina = 45,
            MaxStamina = 45,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 20,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 54,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 42,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 59,
            MaxDexterity = 59,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 70,
            MaxLuck = 70,
            LuckBuff = 0,

            Intelligence = 89,
            MaxIntelligence = 89,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 54,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 47,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 72,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 57,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 82,
            MaxIntelligence = 82,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 40,
            MaxMana = 40,
            ManaBuff = 0,

            Shield = 40,
            MaxShield = 40,
            ShieldBuff = 0,

            Strength = 45,
            MaxStrength = 45,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 45,
            MaxDefense = 45,
            DefenseBuff = 0,

            Dexterity = 70,
            MaxDexterity = 70,
            DexterityBuff = 0,

            Agility = 70,
            MaxAgility = 70,
            AgilityBuff = 0,

            Luck = 55,
            MaxLuck = 55,
            LuckBuff = 0,

            Intelligence = 50,
            MaxIntelligence = 50,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 15,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 62,
            MaxStrength = 62,
            StrengthBuff = 0,

            Magic = 42,
            MaxMagic = 42,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 57,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 72,
            MaxLuck = 72,
            LuckBuff = 0,

            Intelligence = 81,
            MaxIntelligence = 81,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 10,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 54,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 47,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 57,
            MaxDexterity = 57,
            DexterityBuff = 0,

            Agility = 31,
            MaxAgility = 31,
            AgilityBuff = 0,

            Luck = 62,
            MaxLuck = 62,
            LuckBuff = 0,

            Intelligence = 94,
            MaxIntelligence = 94,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 65,
            MaxHealth = 65,
            HealthBuff = 0,

            Mana = 30,
            MaxMana = 30,
            ManaBuff = 0,

            Shield = 40,
            MaxShield = 40,
            ShieldBuff = 0,

            Strength = 75,
            MaxStrength = 75,
            StrengthBuff = 0,

            Magic = 30,
            MaxMagic = 30,
            MagicBuff = 0,

            Defense = 50,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 60,
            MaxDexterity = 60,
            DexterityBuff = 0,

            Agility = 50,
            MaxAgility = 50,
            AgilityBuff = 0,

            Luck = 50,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 40,
            MaxIntelligence = 40,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 70,
            MaxHealth = 70,
            HealthBuff = 0,

            Mana = 30,
            MaxMana = 30,
            ManaBuff = 0,

            Shield = 40,
            MaxShield = 40,
            ShieldBuff = 0,

            Strength = 70,
            MaxStrength = 70,
            StrengthBuff = 0,

            Magic = 30,
            MaxMagic = 30,
            MagicBuff = 0,

            Defense = 50,
            MaxDefense = 50,
            DefenseBuff = 0,

            Dexterity = 50,
            MaxDexterity = 50,
            DexterityBuff = 0,

            Agility = 60,
            MaxAgility = 60,
            AgilityBuff = 0,

            Luck = 50,
            MaxLuck = 50,
            LuckBuff = 0,

            Intelligence = 40,
            MaxIntelligence = 40,
            IntelligenceBuff = 0,

            Stamina = 60,
            MaxStamina = 60,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 47,
            MaxHealth = 47,
            HealthBuff = 0,

            Mana = 37,
            MaxMana = 37,
            ManaBuff = 0,

            Shield = 16,
            MaxShield = 16,
            ShieldBuff = 0,

            Strength = 54,
            MaxStrength = 54,
            StrengthBuff = 0,

            Magic = 47,
            MaxMagic = 47,
            MagicBuff = 0,

            Defense = 55,
            MaxDefense = 55,
            DefenseBuff = 0,

            Dexterity = 72,
            MaxDexterity = 72,
            DexterityBuff = 0,

            Agility = 33,
            MaxAgility = 33,
            AgilityBuff = 0,

            Luck = 57,
            MaxLuck = 57,
            LuckBuff = 0,

            Intelligence = 82,
            MaxIntelligence = 82,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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
            isBleeding = false,
            isTouchingWater = false,

            // Status effect amounts
            PoisonedAmount = 0,
            FireAmount = 0,
            FrozenAmount = 0,
            ShockedAmount = 0,
            CursedAmount = 0,
            BleedAmount = 0,

            // Resistances (default 0% resistance)
            PoisonResistance = 0,
            FireResistance = 0,
            FreezeResistance = 0,
            ShockResistance = 0,
            CursedResistance = 0,
            BleedResistance = 0,

            // Base stats
            Health = 45,
            MaxHealth = 45,
            HealthBuff = 0,

            Mana = 35,
            MaxMana = 35,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 52,
            MaxStrength = 52,
            StrengthBuff = 0,

            Magic = 40,
            MaxMagic = 40,
            MagicBuff = 0,

            Defense = 58,
            MaxDefense = 58,
            DefenseBuff = 0,

            Dexterity = 74,
            MaxDexterity = 74,
            DexterityBuff = 0,

            Agility = 40,
            MaxAgility = 40,
            AgilityBuff = 0,

            Luck = 63,
            MaxLuck = 63,
            LuckBuff = 0,

            Intelligence = 78,
            MaxIntelligence = 78,
            IntelligenceBuff = 0,

            Stamina = 50,
            MaxStamina = 50,
            StaminaBuff = 0,

            //d6-20 rolls stats

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