//Skill.cs
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.ExceptionServices;

[Serializable]
public class BuffEffect
{
    public Skill.BuffType buffType;
    public int amount;
    public int duration;
    public BuffTarget target;
    public int triggerPercentage = 100;
    public int backfirePercentage = 0;
    public bool isAOE;
    public int AOERadius;
    public int distance = 0;

    // Parameterless constructor for serialization/Inspector
    public BuffEffect()
    {
        buffType = Skill.BuffType.None;
        amount = 0;
        duration = 0;
        target = BuffTarget.Caster; // Default target
        triggerPercentage = 100;
        backfirePercentage = 0;
        isAOE = false;
        AOERadius = 0;
        distance = 0;
    }

    // Parameterized constructor with an optional buff target.
    public BuffEffect(Skill.BuffType type, int amt, int dur, BuffTarget target = BuffTarget.Caster, int triggerChance = 100, int backfireChance = 0, bool AOE = false, int Radius = 0, int Distance = 0)
    {
        buffType = type;
        amount = amt;
        duration = dur;
        this.target = target;
        triggerPercentage = triggerChance;
        backfirePercentage =backfireChance;
        isAOE = AOE;
        AOERadius= Radius;
        distance = Distance;
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
    public int manaCost;
    public int damage;
    public int healing;
    public bool isAttack;
    public string skillType;  // Physical, Magical, Support, etc.


    //Unique properties
    public bool isGoldSkill;
    public bool isAOESkill;
    public bool isTrapSkill;
    public bool isCleanseSkill;
    public bool isKnockackSkill;
    public bool isCounterSkill;
    public bool isTauntSkill;
    public bool isReflectSkill; 
    public bool isCopySkill;    
    public bool isStealSkill;
    public bool isDefenseBasedAttackSkill;
    public bool isMultipleHits;

    public bool doesTrigger;
    public int triggerChance;
    public int triggeredDamage;
    public int triggeredHealing;
    public int triggeredDamagePercentage;
    // Gold stealing properties
    public int goldAmount;
    public int goldAmountGainedPer;
    // AOE properties
    public int AOERadius;
    //Trap properties
    public bool isDropTrapOnCurrentSpace;
    //Knockback properties
    public int knockbackLength;
    //Counter properties
    public bool isAOECounter;
    //Taunt properties
    public int tauntDefenseBuff;
    public int tauntShieldBuff;
    //Reflect properties
    public int reflectDefenseBuff;
    //copy properties
    public bool canCopyInRadius;
    public bool canPickTargetToCopy;
    //steal item properties
    //make a steal held item or steal from backpack toggle
    //defense based attack skill properties
    public int defenseBasedAttackDefenseBuff;
    public int defenseBasedAttackMultiplier;
    //multiple hits properties
    public bool isSetAmountOfHits;
    public int leastAmountOfHits;
    public int mostAmountOfHits;
    public int damagePerAttack;
    public bool doesCycleBuffs;



    //Multiple Buffs
    public List<BuffEffect> buffEffects = new List<BuffEffect>();

    // Buff properties -- obscolete new in Bufftype - AddBuff
    public BuffType buffType;
    public int buffAmount;
    public int buffDuration;  // in turns

    public enum BuffType
    {
        None,
        Attack,
        Defense,
        Speed, 
        Strength,
        Magic,
        Agility,
        Health,
        Mana,
        CriticalChance, 
        CriticalDamage, 
        DodgeChance,    //
        Shield,
        Dexterity,
        Luck,
        Intelligence,
        Pierce, 
        Accuracy,
        ManaRestore,
        GoldBuff,
        Stamina,
        Vitality,

        //leave chances in for now -- will remove later -- chances handled now in BuffEffects
        Stunned,
        StunChance, //
        Poisoned,
        PoisonChance,   //
        Burned,
        BurnChance, //
        Frozen,
        FreezeChance,   //
        Confused,
        ConfuseChance,  //
        Cursed,
        CursedChance,   //
        Bleeding,
        BleedChance,    //
        Fatigue,
        FatigueChance,  //

        Gold,
        Trap,
        Cleanse,
        Knockack,
        Counter,
        Taunt,
        Reflect,
        Copy,
        Steal,
        DefenseBasedAttack,
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

    // stun properties
    public bool isStunSkill;
    public bool doesStun;
    public int stunChance;
    public int stunDuration;
    public bool stunsTarget;
    public bool stunsSelf;

    // poison properties
    public bool isPoisonSkill;
    public bool doesPoison;
    public int poisonChance;
    public int poisonDuration;
    public int poisonDamageAmount;
    public bool poisonsTarget;
    public bool poisonsSelf;

    // burn properties
    public bool isBurnSkill;
    public bool doesBurn;
    public int burnChance;
    public int burnDuration;
    public int burnDamageAmount;
    public bool burnsTarget;
    public bool burnsSelf;

    // freeze properties
    public bool isFreezeSkill;
    public bool doesFreeze;
    public int freezeChance;
    public int freezeDuration;
    public int freezeDamageAmount;
    public bool freezesTarget;
    public bool freezesSelf;

    // confuse properties
    public bool isConfuseSkill;
    public bool doesConfuse;
    public int confuseChance;
    public int confuseDuration;
    public int confuseDamageAmount; //50/50 chance to do this damage
    public bool confusesTarget;
    public bool confusesSelf;

    // curse properties
    public bool isCurseSkill;
    public bool doesCurse;
    public int curseChance;
    public int curseDuration;
    public int curseDamageAmount;
    public bool cursesTarget;
    public bool cursesSelf;

    // bleed properties
    public bool isBleedSkill;
    public bool doesBleed;
    public int bleedChance;
    public int bleedDuration;
    public int bleedDamageAmount;
    public bool bleedTarget;
    public bool bleedSelf;

    // fatigue properties -- cant use skills 
    public bool isFatigueSkill;
    public bool doesFatigue;
    public int fatigueChance;
    public int fatigueDuration;
    public bool fatiguesTarget;
    public bool fatiguesSelf;


    //helper method to add buffs
    public void AddBuff(BuffType type, int amount, int duration, BuffTarget target = BuffTarget.Caster, int triggerChance = 100, int backfireChance = 0, bool AOE = false, int Radius = 0, int Distance = 0)
    {
        buffEffects.Add(new BuffEffect(type, amount, duration, target, triggerChance, backfireChance, AOE, Radius, Distance));
    }
}

