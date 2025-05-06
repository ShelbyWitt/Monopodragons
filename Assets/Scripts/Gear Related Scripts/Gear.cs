//Gear.cs


using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.ExceptionServices;
using MedalSystem;



public enum GearStatType
{
    None,  // Default - use regular calculation

    Health,
    Mana,
    Shield,

    Strength,
    Magic,
    Defense,
    Dexterity,
    Agility,
    Luck,
    Intelligence,
    Stamina,
    AllStats,

    Attack,
    Speed,
    CriticalChance,
    CriticalDamage,
    DodgeChance,
    Pierce,
    Accuracy,

    ExtraDice,
    Gold,
}

[Serializable]
public class GearBuffEffect
{
    public Gear.GearBuffType gearBuffType;      //Buff Type
    public int amount;                          // + ___ amount to stat
    public int duration;                        //Buff Duration -- if perm do -1
    public int backfirePercentage = 0;          //Percent of taking recoil (standard 10%)


    // Parameterless constructor for serialization/Inspector
    public GearBuffEffect()
    {
        gearBuffType = Gear.GearBuffType.None;
        amount = 0;
        duration = 0;
        backfirePercentage = 0;
    }
}

//[Serializable]
//public class WeaponBuffEffect
//{
//    public Gear.GearBuffType weaponBuffType;      //Buff Type
//    public int amount;                          // + ___ amount to stat
//    public int duration;                        //Buff Duration -- if perm do -1
//    public int backfirePercentage = 0;          //Percent of taking recoil (standard 10%)


//    // Parameterless constructor for serialization/Inspector
//    public WeaponBuffEffect()
//    {
//        weaponBuffType = Gear.GearBuffType.None;
//        amount = 0;
//        duration = 0;
//        backfirePercentage = 0;
//    }
//}

public class GearType
{
    public Gear.GearTypes gearType;
    public int amount;
    public int duration;
    public int backfireChance;

    // Parameterless constructor for serialization/Inspector
    public GearType()
    {
        gearType = Gear.GearTypes.None;
        amount = 0;
        duration = 0;
        backfireChance = 0;
    }

    // Parameterized constructor with an optional buff target
    public GearType(Gear.GearTypes type, int amt, int dur, int backfire)
    {
        gearType = type;
        amount = amt;
        duration = dur;
        backfireChance = backfire;
    }
}


[Serializable]
public class SpecificBuffs
{
    public Races races;
    public Classes classes;
    public GearStats buffs = new GearStats();


    //Enums

    public enum Races
    {
        None,
        Human,
        Giant,
        Elf,
        Werewolf,
        Dwarf,
        Ogre,
        Triling,
        Morphling,
        Changeling,
        Minotaur,
        Troll,
        Undead,
        Skeleton,
        Ghoul,
        Tiefling,
        HighElf,
        DarkElf,
        Goblin,
        Orc,
        Gnome,
        Halfling,
        Merfolk,
        Centaur,
        Dragonborn,
        Kobold,
        Vampire,
        Fairy,
        Firbolg,
        YuanTi,
        Kenku,
        Tabaxi,
        Aasimar,
        Genasi,
        Bugbear,
        Gnoll,
        Satyr,
        Harpy,
    }

    public enum Classes
    {
        None,
        Mage,
        Knight,
        Thief,
        Archer,
        Cleric,
        Druid,
        Fighter,
        Tracker,
        Warrior,
        Berserker,
        TwinBlade,
        Spear,
        Shield,
        ShortSword,
        Paladin,
        Warlock,
        Bard,
        Ranger,
        Sorcerer,
        Monk,
        Rogue,
        Wizard,
        Barbarian,
        Artificer,
        Necromancer,
        Samurai,
        Swashbuckler,
        Psion,
        Inquisitor,
        Alchemist,
        Gunslinger,
        BloodHunter,
        Hexblade,
        Summoner,
        
    }


}


[System.Serializable]
public class Gear
{
    // Basic properties
    public string gearName;     //Gear Name
    public string description;  //Gear Description
    public GameObject AssetModel;
    public GearTypes gearTypes;
    public WeaponTypes weaponTypes;
    public ShieldTypes shieldTypes;
    public ArtifactTypes artifactTypes;
    public int distance = 0;                    // + ___ amount to distance (range)
    public bool hasElementalAttribute = false;       //If elemental skill, add elemental debuff and make backfire work for debuff too
    public bool isPartOfSet = true;             // If Part of set, include some set bonus TODO
    public List<SpecificBuffs> SpecificBuffs = new List<SpecificBuffs>();

    
    public GearStats stats = new GearStats();   //only use if NEEDED


    // Enums

    public enum EquippableType
    {
        None,
        Gear,
        Weapons,
        Shield,
        Artifacts
    }

    public enum GearTypes
    {
        None,
        Headwear,
        Chesticles,
        Leggings,
        Shoes,
        Amulet,
        Ring,

    }

    public enum WeaponTypes
    {
        None,
        Sword,
        ShortSword,
        LongSword,
        Katana,
        Dagger,
        TwinBlades,
        Spear,
        Staff,
        Knives,
        Machete,
        Scythe,
        Trident,
        Hammer,
        Scimitar,
        Hatchet,
        Naginata,

    }

    public enum ShieldTypes
    {
        None,
        Shield,
        BigShield,
    }

    public enum ArtifactTypes
    {
        None,
        Spheres,
        Pendants,
        Runes,
    }

    public enum GearBuffType
    {
        None,
        Health,
        Mana,
        Gold,
        Shield,
        Strength,
        Magic,
        Defense,
        Dexterity,
        Agility,
        Luck,
        Intelligence,
        Stamina,
        Attack,
        Speed,
        CriticalChance,
        CriticalDamage,
        DodgeChance,
        Pierce,
        Accuracy,
        Stunned,
        Poisoned,
        Burned,
        Frozen,
        Confused,
        Cursed,
        Bleeding,
        Fatigue
    }

   
}

[System.Serializable]
public class GearStats
{

    [Header("Statuses")]
    // Status effects
    public bool isPoisoned; public int PoisonedAmount;
    public bool isOnFire; public int FireAmount;
    public bool isFrozen; public int FrozenAmount;
    public bool isShocked; public int ShockedAmount;
    public bool isCursed; public int CursedAmount;
    public bool isBleeding; public int BleedAmount;
    public bool isTouchingWater;

    [Header("Resistances")]
    // Resistances
    public int PoisonResistance;
    public int FireResistance;
    public int FreezeResistance;
    public int ShockResistance;
    public int CursedResistance;
    public int BleedResistance;

    [Header("Buffs")]
    // Stat characteristics
    public int HealthBuff;
    public int ManaBuff;
    public int ShieldBuff;
    public int StrengthBuff;
    public int MagicBuff;
    public int DefenseBuff;
    public int DexterityBuff;
    public int AgilityBuff;
    public int LuckBuff;
    public int IntelligenceBuff;
    public int AllStatsBuff;
    public int StaminaBuff;
    public int AttackBuff;
    public int SpeedBuff;
    public int CriticalChanceBuff;
    public int CriticalDamageBuff;
    public int DodgeChanceBuff;
    public int PierceBuff;
    public int AccuracyBuff;

    [Header("Extra Stats")]
    public int Gold;
    public int ExtraDice;

    // Default constructor to initialize values
    public GearStats()
    {
        // Initialize all fields to default values (0 or false)
    }
}

[System.Serializable]
public class GearsSubcategory
{
    public string setName;           // e.g., "Human" for Race, "Mage" for Class
    public List<Gear> gears = new List<Gear>(); // Medals under this subcategory
    public List<Gear> weapons = new List<Gear>();
    public List<Gear> shields = new List<Gear>();
    public List<Gear> artifacts = new List<Gear>();
}