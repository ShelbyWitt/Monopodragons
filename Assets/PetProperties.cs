//PetProperties
using UnityEngine;

public class PetProperties : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnValidate()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();


        MechaTankPetProperties = new PetStats
        {
            //MECHA TANK CHART

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
            Health = 0,
            MaxHealth = 0,
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

        CosmoHealerPetProperties = new PetStats
        {
            //COSMO HEALER CHART

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

        NinjaAttackPetProperties = new PetStats
        {
            //NINJA ATTACK CHART

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

        PandaDefensePetProperties = new PetStats
        {
            //PANDA DEFENSE CHART

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

        CatMagicPetProperties = new PetStats
        {
            //CAT MAGIC CHART

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

    }

    public PetStats MechaTankPetProperties;
    public PetStats CosmoHealerPetProperties;
    public PetStats NinjaAttackPetProperties;
    public PetStats PandaDefensePetProperties;
    public PetStats CatMagicPetProperties;



    StateManager theStateManager;



    private Player player;
}



