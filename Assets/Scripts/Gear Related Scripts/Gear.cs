//Gear.cs


using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.ExceptionServices;

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

[System.Serializable]
public class Gear
{
    // Basic properties
    public string gearName;     //Gear Name
    public string description;  //Gear Description
    public List<GearBuffEffect> gearBuffEffects = new List<GearBuffEffect>();   //Gear Buffs
    public GearTypes gearTypes; //Gear Type -- Helmet, Robe, Leggings, Shoes, Amulet, Ring, Held Item
    public int distance = 0;                    // + ___ amount to distance (range)
    public bool isElementalSkill = false;       //If elemental skill, add elemental debuff and make backfire work for debuff too
    public bool isPartOfSet = true;             // If Part of set, include some set bonus TODO
    public string setName;                      //Which set belongs to


    // New stats field
    public GearStats stats = new GearStats();   //only use if NEEDED

    // Enums
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

    public enum GearTypes
    {
        None,
        Helmet,
        Robe,
        Pants,
        Shoes,
        Amulet,
        Ring,
        HeldItem
    }
}

[System.Serializable]
public class GearStats
{
    // Status effects
    public bool isPoisoned; public int PoisonedAmount;
    public bool isOnFire; public int FireAmount;
    public bool isFrozen; public int FrozenAmount;
    public bool isShocked; public int ShockedAmount;
    public bool isCursed; public int CursedAmount;
    public bool isBleeding; public int BleedAmount;
    public bool isTouchingWater;

    // Resistances
    public int PoisonResistance;
    public int FireResistance;
    public int FreezeResistance;
    public int ShockResistance;
    public int CursedResistance;
    public int BleedResistance;

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
    public int Gold;
    public int ExtraDice;

    // Default constructor to initialize values
    public GearStats()
    {
        // Initialize all fields to default values (0 or false)
    }
}