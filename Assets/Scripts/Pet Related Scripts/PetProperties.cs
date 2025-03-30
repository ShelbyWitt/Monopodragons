//PetProperties.cs
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

            Mana = 0,
            MaxMana = 0,
            ManaBuff = 0,

            Shield = 20,
            MaxShield = 20,
            ShieldBuff = 0,

            Strength = 0,
            MaxStrength = 0,
            StrengthBuff = 0,

            Magic = 0,
            MaxMagic = 0,
            MagicBuff = 0,

            Defense = 0,
            MaxDefense = 0,
            DefenseBuff = 0,

            Dexterity = 0,
            MaxDexterity = 0,
            DexterityBuff = 0,

            Agility = 0,
            MaxAgility = 0,
            AgilityBuff = 0,

            Luck = 0,
            MaxLuck = 0,
            LuckBuff = 0,

            Intelligence = 0,
            MaxIntelligence = 0,
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
            BleedResistance = 0,

            // Base stats
            Health = 10,    //TODO -- make this per turn
            MaxHealth = 10, //TODO -- make this per turn
            HealthBuff = 0,

            Mana = 0,
            MaxMana = 0,
            ManaBuff = 0,

            Shield = 0,
            MaxShield = 0,
            ShieldBuff = 0,

            Strength = 0,
            MaxStrength = 0,
            StrengthBuff = 0,

            Magic = 0,
            MaxMagic = 0,
            MagicBuff = 0,

            Defense = 0,
            MaxDefense = 0,
            DefenseBuff = 0,

            Dexterity = 0,
            MaxDexterity = 0,
            DexterityBuff = 0,

            Agility = 0,
            MaxAgility = 0,
            AgilityBuff = 0,

            Luck = 0,
            MaxLuck = 0,
            LuckBuff = 0,

            Intelligence = 0,
            MaxIntelligence = 0,
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

            Mana = 0,
            MaxMana = 0,
            ManaBuff = 0,

            Shield = 0,
            MaxShield = 0,
            ShieldBuff = 0,

            Strength = 22,
            MaxStrength = 22,
            StrengthBuff = 0,

            Magic = 0,
            MaxMagic = 0,
            MagicBuff = 0,

            Defense = 0,
            MaxDefense = 0,
            DefenseBuff = 0,

            Dexterity = 0,
            MaxDexterity = 0,
            DexterityBuff = 0,

            Agility = 0,
            MaxAgility = 0,
            AgilityBuff = 0,

            Luck = 0,
            MaxLuck = 0,
            LuckBuff = 0,

            Intelligence = 0,
            MaxIntelligence = 0,
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
            BleedResistance = 0,

            // Base stats
            Health = 0,
            MaxHealth = 0,
            HealthBuff = 0,

            Mana = 0,
            MaxMana = 0,
            ManaBuff = 0,

            Shield = 0,
            MaxShield = 0,
            ShieldBuff = 0,

            Strength = 0,
            MaxStrength = 0,
            StrengthBuff = 0,

            Magic = 0,
            MaxMagic = 0,
            MagicBuff = 0,

            Defense = 20,
            MaxDefense = 20,
            DefenseBuff = 0,

            Dexterity = 0,
            MaxDexterity = 0,
            DexterityBuff = 0,

            Agility = 0,
            MaxAgility = 0,
            AgilityBuff = 0,

            Luck = 0,
            MaxLuck = 0,
            LuckBuff = 0,

            Intelligence = 0,
            MaxIntelligence = 0,
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

            Mana = 10,
            MaxMana = 10,
            ManaBuff = 0,

            Shield = 0,
            MaxShield = 0,
            ShieldBuff = 0,

            Strength = 0,
            MaxStrength = 0,
            StrengthBuff = 0,

            Magic = 12,
            MaxMagic = 12,
            MagicBuff = 0,

            Defense = 0,
            MaxDefense = 0,
            DefenseBuff = 0,

            Dexterity = 0,
            MaxDexterity = 0,
            DexterityBuff = 0,

            Agility = 0,
            MaxAgility = 0,
            AgilityBuff = 0,

            Luck = 0,
            MaxLuck = 0,
            LuckBuff = 0,

            Intelligence = 0,
            MaxIntelligence = 0,
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

    }

    public PetStats MechaTankPetProperties;
    public PetStats CosmoHealerPetProperties;
    public PetStats NinjaAttackPetProperties;
    public PetStats PandaDefensePetProperties;
    public PetStats CatMagicPetProperties;



    StateManager theStateManager;



    private Pet pet;


    public PetStats GetPetProperties(string petName)
    {
        switch (petName)
        {
            case "Mecha Tank":
                return MechaTankPetProperties;
            case "Cosmo Healer":
                return CosmoHealerPetProperties;
            case "Ninja Attack":
                return NinjaAttackPetProperties;
            case "Panda Defense":
                return PandaDefensePetProperties;
            case "Cat Magic":
                return CatMagicPetProperties;
            default:
                return MechaTankPetProperties;
        }
    }
}



