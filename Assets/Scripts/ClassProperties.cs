//ClassProperties.cs

using UnityEngine;



[ExecuteAlways]
public class ClassProperties : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnValidate()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        MageClassProperties = new PlayerProperties
        {
            //MAGE CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 12,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 14,
            MaxMana = 20,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 16,
            MaxMagic = 20,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 11,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 16,
            MaxIntelligence = 20,
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

        KnightClassProperties = new PlayerProperties
        {
            //KNIGHT CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 18,
            HealthBuff = 0,

            Mana = 11,
            MaxMana = 13,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 13,
            MaxStrength = 18,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 13,
            MagicBuff = 0,

            Defense = 13,
            MaxDefense = 18,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 13,
            LuckBuff = 0,

            Intelligence = 13,
            MaxIntelligence = 13,
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

        ThiefClassProperties = new PlayerProperties
        {
            //THIEF CLASS CHART

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
            PoisonResistance = 18,
            FireResistance = 18,
            FreezeResistance = 25,
            ShockResistance = 18,
            CursedResistance = 22,

            // Base stats               //Divide By 10 for %
            Health = 11,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 13,
            MaxMana = 11,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 11,
            MaxStrength = 11,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 12,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 15,
            MaxDexterity = 19,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 19,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 19,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 12,
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

        ArcherClassProperties = new PlayerProperties
        {
            //ARCHER CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 10,
            ShockResistance = 0,
            CursedResistance = 0,

            // Base stats               //Divide By 10 for %
            Health = 10,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 7,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 17,
            MaxStrength = 12,
            StrengthBuff = 0,

            Magic = 16,
            MaxMagic = 11,
            MagicBuff = 0,

            Defense = 9,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 14,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 14,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 15,
            MaxLuck = 18,
            LuckBuff = 0,

            Intelligence = 17,
            MaxIntelligence = 12,
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

        ClericClassProperties = new PlayerProperties
        {
            //CLERIC CLASS CHART

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
            PoisonResistance = 25,
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 9,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 17,
            MaxMana = 17,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 12,
            ShieldBuff = 0,

            Strength = 8,
            MaxStrength = 11,
            StrengthBuff = 0,

            Magic = 17,
            MaxMagic = 17,
            MagicBuff = 0,

            Defense = 9,
            MaxDefense = 14,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 11,
            DexterityBuff = 0,

            Agility = 11,
            MaxAgility = 11,
            AgilityBuff = 0,

            Luck = 15,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 17,
            MaxIntelligence = 14,
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

        DruidClassProperties = new PlayerProperties
        {
            //DRUID CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 35,
            CursedResistance = 30,

            // Base stats               //Divide By 10 for %
            Health = 8,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 15,
            MaxMana = 15,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 13,
            ShieldBuff = 0,

            Strength = 11,
            MaxStrength = 11,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 15,
            MagicBuff = 0,

            Defense = 11,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 16,
            MaxLuck = 16,
            LuckBuff = 0,

            Intelligence = 16,
            MaxIntelligence = 12,
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

        FighterClassProperties = new PlayerProperties
        {
            //FIGHTER CLASS CHART

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

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 15,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 14,
            ShieldBuff = 0,

            Strength = 17,
            MaxStrength = 17,
            StrengthBuff = 0,

            Magic = 11,
            MaxMagic = 11,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 15,
            DefenseBuff = 0,

            Dexterity = 14,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 14,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 13,
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

        TrackerClassProperties = new PlayerProperties
        {
            //TRACKER CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 10,
            ShockResistance = 20,
            CursedResistance = 15,

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 14,
            MaxMana = 13,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 12,
            ShieldBuff = 0,

            Strength = 14,
            MaxStrength = 13,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 11,
            MagicBuff = 0,

            Defense = 13,
            MaxDefense = 12,
            DefenseBuff = 0,

            Dexterity = 16,
            MaxDexterity = 17,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 16,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 14,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 13,
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

        WarriorClassProperties = new PlayerProperties
        {
            //WARRIOR CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 15,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 17,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 15,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 12,
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

        BerserkerClassProperties = new PlayerProperties
        {
            //BERSERKER CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 15,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 11,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 19,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 11,
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

        TwinBladeClassProperties = new PlayerProperties
        {
            //TWIN BLADE CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 16,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 11,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 17,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 17,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 13,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 13,
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

        SpearClassProperties = new PlayerProperties
        {
            //SPEAR CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 12,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 17,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 12,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 17,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 17,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 12,
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

        ShieldClassProperties = new PlayerProperties
        {
            //SHIELD CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 17,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 17,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 17,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 17,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 11,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 11,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 12,
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

        ShortSwordClassProperties = new PlayerProperties
        {
            //SHORT SWORD CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 11,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 14,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 18,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 11,
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

        PaladinClassProperties = new PlayerProperties
        {
            //PALADIN CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 13,
            ShieldBuff = 0,

            Strength = 14,
            MaxStrength = 14,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 14,
            DefenseBuff = 0,

            Dexterity = 10,
            MaxDexterity = 10,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 10,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        WarlockClassProperties = new PlayerProperties
        {
            //WARLOCK CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 25,
            FreezeResistance = 15,
            ShockResistance = 20,
            CursedResistance = 30,

            // Base stats               //Divide By 10 for %
            Health = 11,
            MaxHealth = 11,
            HealthBuff = 0,

            Mana = 16,
            MaxMana = 16,
            ManaBuff = 0,

            Shield = 9,
            MaxShield = 9,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 17,
            MaxMagic = 17,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        BardClassProperties = new PlayerProperties
        {
            //BARD CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 11,
            MaxHealth = 11,
            HealthBuff = 0,

            Mana = 15,
            MaxMana = 15,
            ManaBuff = 0,

            Shield = 9,
            MaxShield = 9,
            ShieldBuff = 0,

            Strength = 11,
            MaxStrength = 11,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 15,
            MagicBuff = 0,

            Defense = 9,
            MaxDefense = 9,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 13,
            MaxLuck = 13,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        RangerClassProperties = new PlayerProperties
        {
            //RANGER CLASS CHART

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
            PoisonResistance = 25,
            FireResistance = 15,
            FreezeResistance = 20,
            ShockResistance = 15,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 12,
            ShieldBuff = 0,

            Strength = 13,
            MaxStrength = 13,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 13,
            MaxDefense = 13,
            DefenseBuff = 0,

            Dexterity = 15,
            MaxDexterity = 15,
            DexterityBuff = 0,

            Agility = 15,
            MaxAgility = 15,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        SorcererClassProperties = new PlayerProperties
        {
            //SORCERER CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 25,
            CursedResistance = 15,

            // Base stats               //Divide By 10 for %
            Health = 10,
            MaxHealth = 10,
            HealthBuff = 0,

            Mana = 18,
            MaxMana = 18,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 20,
            MaxMagic = 20,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 14,
            MaxDexterity = 14,
            DexterityBuff = 0,

            Agility = 14,
            MaxAgility = 14,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 13,
            MaxIntelligence = 13,
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

        MonkClassProperties = new PlayerProperties
        {
            //MONK CLASS CHART

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
            PoisonResistance = 25,
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 15,

            // Base stats               //Divide By 10 for %
            Health = 12,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 13,
            MaxStrength = 13,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 10,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 18,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        RogueClassProperties = new PlayerProperties
        {
            //ROGUE CLASS CHART

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
            PoisonResistance = 25,
            FireResistance = 15,
            FreezeResistance = 20,
            ShockResistance = 15,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 11,
            MaxHealth = 11,
            HealthBuff = 0,

            Mana = 11,
            MaxMana = 11,
            ManaBuff = 0,

            Shield = 9,
            MaxShield = 9,
            ShieldBuff = 0,

            Strength = 11,
            MaxStrength = 11,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 9,
            MaxDefense = 9,
            DefenseBuff = 0,

            Dexterity = 18,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 14,
            LuckBuff = 0,

            Intelligence = 14,
            MaxIntelligence = 14,
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

        WizardClassProperties = new PlayerProperties
        {
            //WIZARD CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 8,
            MaxHealth = 8,
            HealthBuff = 0,

            Mana = 20,
            MaxMana = 20,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 8,
            MaxStrength = 8,
            StrengthBuff = 0,

            Magic = 20,
            MaxMagic = 20,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 19,
            MaxIntelligence = 19,
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

        BarbarianClassProperties = new PlayerProperties
        {
            //BARBARIAN CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 25,
            ShockResistance = 20,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 16,
            MaxHealth = 16,
            HealthBuff = 0,

            Mana = 8,
            MaxMana = 8,
            ManaBuff = 0,

            Shield = 14,
            MaxShield = 14,
            ShieldBuff = 0,

            Strength = 19,
            MaxStrength = 19,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 8,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 14,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 10,
            MaxIntelligence = 10,
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

        ArtificerClassProperties = new PlayerProperties
        {
            //ARTIFICER CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 25,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 12,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 15,
            MaxMana = 15,
            ManaBuff = 0,

            Shield = 11,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 12,
            MaxStrength = 12,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 15,
            MagicBuff = 0,

            Defense = 11,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 17,
            MaxIntelligence = 17,
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

        NecromancerClassProperties = new PlayerProperties
        {
            //NECROMANCER CLASS CHART

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
            FireResistance = 10,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 30,

            // Base stats               //Divide By 10 for %
            Health = 10,
            MaxHealth = 10,
            HealthBuff = 0,

            Mana = 15,
            MaxMana = 15,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 18,
            MaxMagic = 18,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 18,
            MaxIntelligence = 18,
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

        SamuraiClassProperties = new PlayerProperties
        {
            //SAMURAI CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 10,
            MaxMana = 10,
            ManaBuff = 0,

            Shield = 15,
            MaxShield = 15,
            ShieldBuff = 0,

            Strength = 16,
            MaxStrength = 16,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 15,
            MaxDefense = 15,
            DefenseBuff = 0,

            Dexterity = 14,
            MaxDexterity = 14,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        SwashbucklerClassProperties = new PlayerProperties
        {
            //SWASHBUCKLER CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 25,
            ShockResistance = 20,
            CursedResistance = 15,

            // Base stats               //Divide By 10 for %
            Health = 12,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 10,
            MaxMana = 10,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 12,
            MaxStrength = 12,
            StrengthBuff = 0,

            Magic = 10,
            MaxMagic = 10,
            MagicBuff = 0,

            Defense = 10,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 18,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 18,
            MaxAgility = 18,
            AgilityBuff = 0,

            Luck = 16,
            MaxLuck = 16,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        PsionClassProperties = new PlayerProperties
        {
            //PSION CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 15,
            FreezeResistance = 15,
            ShockResistance = 30,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 10,
            MaxHealth = 10,
            HealthBuff = 0,

            Mana = 17,
            MaxMana = 17,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 17,
            MaxMagic = 17,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 14,
            LuckBuff = 0,

            Intelligence = 19,
            MaxIntelligence = 19,
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

        InquisitorClassProperties = new PlayerProperties
        {
            //INQUISITOR CLASS CHART

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
            FireResistance = 25,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 13,
            ShieldBuff = 0,

            Strength = 14,
            MaxStrength = 14,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 14,
            DefenseBuff = 0,

            Dexterity = 10,
            MaxDexterity = 10,
            DexterityBuff = 0,

            Agility = 10,
            MaxAgility = 10,
            AgilityBuff = 0,

            Luck = 11,
            MaxLuck = 11,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        AlchemistClassProperties = new PlayerProperties
        {
            //ALCHEMIST CLASS CHART

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
            PoisonResistance = 30,
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 10,

            // Base stats               //Divide By 10 for %
            Health = 12,
            MaxHealth = 12,
            HealthBuff = 0,

            Mana = 14,
            MaxMana = 14,
            ManaBuff = 0,

            Shield = 10,
            MaxShield = 10,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 15,
            MaxMagic = 15,
            MagicBuff = 0,

            Defense = 10,
            MaxDefense = 10,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 14,
            LuckBuff = 0,

            Intelligence = 18,
            MaxIntelligence = 18,
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

        GunslingerClassProperties = new PlayerProperties
        {
            //GUNSLINGER CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 15,
            FreezeResistance = 20,
            ShockResistance = 25,
            CursedResistance = 25,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 8,
            MaxMana = 8,
            ManaBuff = 0,

            Shield = 12,
            MaxShield = 12,
            ShieldBuff = 0,

            Strength = 12,
            MaxStrength = 12,
            StrengthBuff = 0,

            Magic = 8,
            MaxMagic = 8,
            MagicBuff = 0,

            Defense = 12,
            MaxDefense = 12,
            DefenseBuff = 0,

            Dexterity = 18,
            MaxDexterity = 18,
            DexterityBuff = 0,

            Agility = 16,
            MaxAgility = 16,
            AgilityBuff = 0,

            Luck = 16,
            MaxLuck = 16,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        BloodHunterClassProperties = new PlayerProperties
        {
            //BLOOD HUNTER CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 14,
            MaxHealth = 14,
            HealthBuff = 0,

            Mana = 12,
            MaxMana = 12,
            ManaBuff = 0,

            Shield = 13,
            MaxShield = 13,
            ShieldBuff = 0,

            Strength = 15,
            MaxStrength = 15,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 14,
            MaxDefense = 14,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 12,
            MaxIntelligence = 12,
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

        HexbladeClassProperties = new PlayerProperties
        {
            //HEXBLADE CLASS CHART

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
            PoisonResistance = 15,
            FireResistance = 25,
            FreezeResistance = 15,
            ShockResistance = 20,
            CursedResistance = 30,

            // Base stats               //Divide By 10 for %
            Health = 13,
            MaxHealth = 13,
            HealthBuff = 0,

            Mana = 15,
            MaxMana = 15,
            ManaBuff = 0,

            Shield = 11,
            MaxShield = 11,
            ShieldBuff = 0,

            Strength = 14,
            MaxStrength = 14,
            StrengthBuff = 0,

            Magic = 16,
            MaxMagic = 16,
            MagicBuff = 0,

            Defense = 11,
            MaxDefense = 11,
            DefenseBuff = 0,

            Dexterity = 13,
            MaxDexterity = 13,
            DexterityBuff = 0,

            Agility = 13,
            MaxAgility = 13,
            AgilityBuff = 0,

            Luck = 12,
            MaxLuck = 12,
            LuckBuff = 0,

            Intelligence = 15,
            MaxIntelligence = 15,
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

        SummonerClassProperties = new PlayerProperties
        {
            //SUMMONER CLASS CHART

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
            FireResistance = 20,
            FreezeResistance = 20,
            ShockResistance = 20,
            CursedResistance = 20,

            // Base stats               //Divide By 10 for %
            Health = 10,
            MaxHealth = 10,
            HealthBuff = 0,

            Mana = 18,
            MaxMana = 18,
            ManaBuff = 0,

            Shield = 8,
            MaxShield = 8,
            ShieldBuff = 0,

            Strength = 10,
            MaxStrength = 10,
            StrengthBuff = 0,

            Magic = 20,
            MaxMagic = 20,
            MagicBuff = 0,

            Defense = 8,
            MaxDefense = 8,
            DefenseBuff = 0,

            Dexterity = 12,
            MaxDexterity = 12,
            DexterityBuff = 0,

            Agility = 12,
            MaxAgility = 12,
            AgilityBuff = 0,

            Luck = 14,
            MaxLuck = 14,
            LuckBuff = 0,

            Intelligence = 18,
            MaxIntelligence = 18,
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



    public PlayerProperties MageClassProperties;
    public PlayerProperties KnightClassProperties;
    public PlayerProperties ThiefClassProperties;
    public PlayerProperties ArcherClassProperties;
    public PlayerProperties ClericClassProperties;
    public PlayerProperties DruidClassProperties;
    public PlayerProperties FighterClassProperties;
    public PlayerProperties TrackerClassProperties;
    public PlayerProperties WarriorClassProperties;
    public PlayerProperties BerserkerClassProperties;
    public PlayerProperties TwinBladeClassProperties;
    public PlayerProperties SpearClassProperties;
    public PlayerProperties ShieldClassProperties;
    public PlayerProperties ShortSwordClassProperties;
    public PlayerProperties PaladinClassProperties;
    public PlayerProperties WarlockClassProperties;
    public PlayerProperties BardClassProperties;
    public PlayerProperties RangerClassProperties;
    public PlayerProperties SorcererClassProperties;
    public PlayerProperties MonkClassProperties;
    public PlayerProperties RogueClassProperties;
    public PlayerProperties WizardClassProperties;
    public PlayerProperties BarbarianClassProperties;
    public PlayerProperties ArtificerClassProperties;
    public PlayerProperties NecromancerClassProperties;
    public PlayerProperties SamuraiClassProperties;
    public PlayerProperties SwashbucklerClassProperties;
    public PlayerProperties PsionClassProperties;
    public PlayerProperties InquisitorClassProperties;
    public PlayerProperties AlchemistClassProperties;
    public PlayerProperties GunslingerClassProperties;
    public PlayerProperties BloodHunterClassProperties;
    public PlayerProperties HexbladeClassProperties;
    public PlayerProperties SummonerClassProperties;


    StateManager theStateManager;



    private Player player;


    public PlayerProperties GetClassProperties(string className)
    {
        switch (className)
        {
            case "Mage":
                return MageClassProperties;
            case "Knight":
                return KnightClassProperties;
            case "Thief":
                return ThiefClassProperties;
            case "Archer":
                return ArcherClassProperties;
            case "Cleric":
                return ClericClassProperties;
            case "Druid":
                return DruidClassProperties;
            case "Fighter":
                return FighterClassProperties;
            case "Tracker":
                return TrackerClassProperties;
            case "Warrior":
                return WarriorClassProperties;
            case "Berserker":
                return BerserkerClassProperties;
            case "Twin Blade":
                return TwinBladeClassProperties;
            case "Spear":
                return SpearClassProperties;
            case "Shield":
                return ShieldClassProperties;
            case "Short Sword":
                return ShortSwordClassProperties;
            case "Paladin":
                return PaladinClassProperties;
            case "Warlock":
                return WarlockClassProperties;
            case "Bard":
                return BardClassProperties;
            case "Ranger":
                return RangerClassProperties;
            case "Sorcerer":
                return SorcererClassProperties;
            case "Monk":
                return MonkClassProperties;
            case "Rogue":
                return RogueClassProperties;
            case "Wizard":
                return WizardClassProperties;
            case "Barbarian":
                return BarbarianClassProperties;
            case "Artificer":
                return ArtificerClassProperties;
            case "Necromancer":
                return NecromancerClassProperties;
            case "Samurai":
                return SamuraiClassProperties;
            case "Swashbuckler":
                return SwashbucklerClassProperties;
            case "Psion":
                return PsionClassProperties;
            case "Inquisitor":
                return InquisitorClassProperties;
            case "Alchemist":
                return AlchemistClassProperties;
            case "Gunslinger":
                return GunslingerClassProperties;
            case "Blood Hunter":
                return BloodHunterClassProperties;
            case "Hexblade":
                return HexbladeClassProperties;
            case "Summoner":
                return SummonerClassProperties;
            default:
                return WarriorClassProperties;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
