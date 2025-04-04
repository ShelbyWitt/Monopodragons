//Mastery.cs


using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Mastery
{
    public enum RequirementType
    {
        None,
        Play_With,
        Leveling,
        Use_Skill,
        Use_Ultimate,
        Win_With,
        Unique_Scenario,
        Play_Map,
        Play_Multiplayer,
        Move_Spaces,
        Complete_Turns,
        Kill_Enemy,
        Kill_Boss,
        Acquire_Effect,
        Use_Item,
        Accumulate_Gold,
        Damage_Dealt,
        Damage_Received,
        Health_Recovered,
        Deaths
    }


    public string masteryName = "New Medal";
    public string masteryDescription = "Achieve a goal to unlock this medal.";
    public bool hasUnlocked = false;
    public float unlockPercentage = 0f;
    public string typeCategory;
    public int XPUnlocked = 100;
    public List<MasteryRequirement> masteryRequirements = new List<MasteryRequirement>();

    // Constructor for programmatic creation
    public Mastery(string name, string desc, params MasteryRequirement[] reqs)
    {
        masteryName = name;
        masteryDescription = desc;
        masteryRequirements.AddRange(reqs);
    }

    public Mastery() { } // Parameterless constructor for serialization
}

[System.Serializable]
public class MasteryRequirement
{
    public Mastery.RequirementType requirementType = Mastery.RequirementType.None;
    public int amount = 0;
    public int gameLimit = 0;  // 0 for no limit
    public int turnLimit = -1; // -1 for no limit

    public MasteryRequirement() { } // Parameterless constructor

    public MasteryRequirement(Mastery.RequirementType reqType, int amt, int gameLim = 0, int turnLim = -1)
    {
        requirementType = reqType;
        amount = amt;
        gameLimit = gameLim;
        turnLimit = turnLim;
    }
}
