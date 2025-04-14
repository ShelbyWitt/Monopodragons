//Skill.cs
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.ExceptionServices;


public enum StatType
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
public class BuffEffect
{
    public Skill.BuffType buffType;
    public StatType statOverride = StatType.None;  // Changed from Skill.BuffType to StatType
    public int amount;
    public int duration;
    public BuffTarget target;
    public bool isTransferred = false;
    public int triggerPercentage = 100;
    public int backfirePercentage = 0;
    public bool isAOE;
    public int AOERadius;
    public int distance = 0;
    public bool isElementalSkill = false;

    // Parameterless constructor for serialization/Inspector
    public BuffEffect()
    {
        buffType = Skill.BuffType.None;
        statOverride = StatType.None;
        amount = 0;
        duration = 0;
        target = BuffTarget.Caster;
        isTransferred = false;
        triggerPercentage = 100;
        backfirePercentage = 0;
        isAOE = false;
        AOERadius = 0;
        distance = 0;
        isElementalSkill = false;
    }

    // Update the parameterized constructor to include statOverride
    public BuffEffect(Skill.BuffType type, int amt, int dur, BuffTarget target = BuffTarget.Caster,
                     StatType statOverride = StatType.None, bool _isTransferred = false,
                     int triggerChance = 100, int backfireChance = 0,
                     bool AOE = false, int Radius = 0, int Distance = 0, bool _isElementalSkill = false)
    {
        buffType = type;
        this.statOverride = statOverride;
        amount = amt;
        duration = dur;
        this.target = target;
        isTransferred = _isTransferred;
        triggerPercentage = triggerChance;
        backfirePercentage = backfireChance;
        isAOE = AOE;
        AOERadius = Radius;
        distance = Distance;
        isElementalSkill = _isElementalSkill;
    }

    // Helper method to get the stat value based on statOverride
    public int GetOverriddenStatValue(PlayerProperties playerProps)
    {
        switch (statOverride)
        {
            case StatType.None:
                return 0; // Return 0 to indicate no override
            case StatType.Health:
                return playerProps.Health;
            case StatType.Mana:
                return playerProps.Mana;
            case StatType.Shield:
                return playerProps.Shield;
            case StatType.Strength:
                return playerProps.Strength;
            case StatType.Magic:
                return playerProps.Magic;
            case StatType.Defense:
                return playerProps.Defense;
            case StatType.Dexterity:
                return playerProps.Dexterity;
            case StatType.Agility:
                return playerProps.Agility;
            case StatType.Luck:
                return playerProps.Luck;
            case StatType.Intelligence:
                return playerProps.Intelligence;
            case StatType.Stamina:
                return playerProps.Stamina;
            case StatType.Attack:
                return playerProps.Attack;
            case StatType.Speed:
                return playerProps.Speed;
            case StatType.CriticalChance:
                return playerProps.CriticalChance;
            case StatType.CriticalDamage:
                return playerProps.CriticalDamage;
            case StatType.DodgeChance:
                return playerProps.DodgeChance;
            case StatType.Pierce:
                return playerProps.Pierce;
            case StatType.Accuracy:
                return playerProps.Accuracy;
            case StatType.AllStats:
                return playerProps.AllStats;
            default:
                return 0;
        }
    }
}


public class SkillType
{
    public Skill.SkillTypes skillType;
    public int amount;
    public int duration;
    public SkillTarget skillTarget;
    public int triggerPercentage = 100;

    // Parameterless constructor for serialization/Inspector
    public SkillType()
    {
        skillType = Skill.SkillTypes.None;
        amount = 0;
        duration = 0;
        skillTarget = SkillTarget.Caster; // Default target
        triggerPercentage = 100;
    }

    // Parameterized constructor with an optional buff target.
    public SkillType(Skill.SkillTypes type, int amt, int dur, SkillTarget targetS = SkillTarget.Caster, int triggerChance = 100, int backfireChance = 0, bool AOE = false, int Radius = 0)
    {
        skillType = type;
        amount = amt;
        duration = dur;
        this.skillTarget = targetS;
        triggerPercentage = triggerChance;
    }


}

public enum SkillTarget
{
    Caster, // The buff is applied to the skill user.
    Target  // The buff is applied to the attacked enemy.
}

public enum BuffTarget
{
    Caster, // The buff is applied to the skill user.
    Target  // The buff is applied to the attacked enemy.
}


[System.Serializable]
public class Skill
{
    // Basic properties
    public string skillName;
    public string description;
    public AnimationClip skillAnimationClip;
    public int manaCost;
    public int damage;
    public int healing;
    public bool isAttack;
    public string skillType;  // Physical Attack, Special Attack, Drain, Support, Custom


            //Unique properties
    public bool guarenteed;
    public int hitChance;
    //defense based attack skill properties
    public bool isDefenseBasedAttack;
    //multiple hits properties
    public int leastAmountOfHits;
    public int mostAmountOfHits;
    public float subsequentMultiplier = 1.0f;
    public bool cyclesBuffs;



    //Multiple Buffs
    public List<BuffEffect> buffEffects = new List<BuffEffect>();

    // Buff properties -- obscolete new in Bufftype - AddBuff
    public BuffType buffType;
    public int buffAmount;
    public int buffDuration;  // in turns

    public enum BuffType
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
        DodgeChance,    //
        Pierce, 
        Accuracy,

        
        Vitality,   //?

 
        Stunned,
        Poisoned,
        Burned,
        Frozen,
        Confused,
        Cursed,
        Bleeding,
        Fatigue,

        
        Trap,
        Cleanse,
        Knockback,
        Counter,
        Taunt,
        TauntDefense,
        TauntShield,
        Reflect,
        ReflectDefense,
        ReflectShield,
        CopyChoice,
        CopyLastAttack,
        StealHeld,
        StealInventory,
        StealChoice,
      

    }

    public enum SkillTypes
    {
        None,
        GoldSkill,
        AOESkill,
        TrapSkill,
        CleanseSkill,
        KnockackSkill,
        CounterSkill,
        TauntSkill,
        ReflectSkill,
        CopySkill,
        StealSkill,
        DefenseBasedAttackSkill,
        MultipleHits,
    }

    

    public void AddBuff(BuffType type, int amount, int duration, BuffTarget target = BuffTarget.Caster,
                   StatType statOverride = StatType.None, bool _isTransferred = false,
                   int triggerChance = 100, int backfireChance = 0,
                   bool AOE = false, int Radius = 0, int Distance = 0)
    {
        buffEffects.Add(new BuffEffect(type, amount, duration, target, statOverride, _isTransferred,
                                      triggerChance, backfireChance, AOE, Radius, Distance));
    }
}

