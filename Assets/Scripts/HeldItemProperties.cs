//HeldItemProperties.cs

using UnityEngine;

public class HeldItemProperties : MonoBehaviour
{





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnValidate()
    {
        theStateManager = GameObject.FindFirstObjectByType<StateManager>();

        SwordOfStrengthProperties = new HeldItemStats
        {
            //SWORD OF STRENGTH CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 0,

            ShieldBuff = 0,

            StrengthBuff = 5,

            MagicBuff = 0,

            DefenseBuff = 0,

            DexterityBuff = 0,

            AgilityBuff = 0,

            LuckBuff = 0,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 1, //equals +1 on rolls

            SpeedBuff = 0,

            CriticalChanceBuff = 0,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 0,

            PierceBuff = 0,

            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        BowOfDexterityProperties = new HeldItemStats
        {
            //BOW OF DEXTERITY CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 0,

            ShieldBuff = 0,

            StrengthBuff = 0,

            MagicBuff = 0,

            DefenseBuff = 0,

            DexterityBuff = 5,

            AgilityBuff = 0,

            LuckBuff = 0,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 0,

            SpeedBuff = 0,

            CriticalChanceBuff = 0,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 0,

            PierceBuff = 0,

            AccuracyBuff = 10,

            Gold = 1500,
            ExtraDice = 0
        };

        StaffOfMagicProperties = new HeldItemStats
        {
            //STAFF OF MAGIC CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 10,  //per turn

            ShieldBuff = 0,

            StrengthBuff = 0,

            MagicBuff = 5,

            DefenseBuff = 0,

            DexterityBuff = 0,

            AgilityBuff = 0,

            LuckBuff = 0,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 0,

            SpeedBuff = 0,

            CriticalChanceBuff = 0,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 0,

            PierceBuff = 0,

            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        ShieldOfDefenseProperties = new HeldItemStats
        {
            //SHIELD OF DEFENSE CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 0,

            ShieldBuff = 0,

            StrengthBuff = 0,

            MagicBuff = 0,

            DefenseBuff = 5,

            DexterityBuff = 0,

            AgilityBuff = 0,

            LuckBuff = 0,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 0,

            SpeedBuff = 0,

            CriticalChanceBuff = 0,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 5,

            PierceBuff = 0,

            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        DaggerOfAgilityProperties = new HeldItemStats
        {
            //DAGGER OF AGILITY CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 0,

            ShieldBuff = 0,

            StrengthBuff = 0,

            MagicBuff = 0,

            DefenseBuff = 0,

            DexterityBuff = 0,

            AgilityBuff = 5,

            LuckBuff = 0,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 0,

            SpeedBuff = 0,

            CriticalChanceBuff = 5,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 0,

            PierceBuff = 0,

            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

        CloakOfInvisibilityProperties = new HeldItemStats
        {
            //CLOAK OF INVISIBILITY CHART

            // Status effects 
            isPoisoned = false,
            isOnFire = false,
            isFrozen = false,
            isShocked = false,
            isCursed = false,
            isBleeding = false,

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
            HealthBuff = 0,

            ManaBuff = 0,

            ShieldBuff = 0,

            StrengthBuff = 0,

            MagicBuff = 0,

            DefenseBuff = 0,

            DexterityBuff = 0,

            AgilityBuff = 0,

            LuckBuff = 5,

            IntelligenceBuff = 0,

            StaminaBuff = 0,

            //d6-20 rolls stats

            AttackBuff = 0,

            SpeedBuff = 0,

            CriticalChanceBuff = 5,

            CriticalDamageBuff = 0,

            DodgeChanceBuff = 10,

            PierceBuff = 0,

            AccuracyBuff = 0,

            Gold = 1500,
            ExtraDice = 0
        };

    }

    public HeldItemStats SwordOfStrengthProperties;
    public HeldItemStats BowOfDexterityProperties;
    public HeldItemStats StaffOfMagicProperties;
    public HeldItemStats ShieldOfDefenseProperties;
    public HeldItemStats DaggerOfAgilityProperties;

    //need speed, crit damage and pierce standard weapon
    public HeldItemStats CloakOfInvisibilityProperties;



    StateManager theStateManager;



    private Pet pet;    //TODO -- make HeldItem.cs and change this


    public HeldItemStats GetHeldItemStats(string heldItemName)
    {
        switch (heldItemName)
        {
            case "Sword Of Strength":
                return SwordOfStrengthProperties;
            case "Bow Of Dexterity":
                return BowOfDexterityProperties;
            case "Staff Of Magic":
                return StaffOfMagicProperties;
            case "Shield Of Defense":
                return ShieldOfDefenseProperties;
            case "Dagger Of Agility":
                return DaggerOfAgilityProperties;
            case "Cloak Of Invisibility":
                return CloakOfInvisibilityProperties;
            default:
                return SwordOfStrengthProperties;
        }
    }
}