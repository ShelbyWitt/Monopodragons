//Medal.cs

using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Medal
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
        Deaths,
        Collect_Gear,
        Collect_Medals_From_Playing,
        Collect_All,
    }

    
    public string medalName = "New Medal";
    public string medalDescription = "Achieve a goal to unlock this medal.";
    public bool hasUnlocked = false;
    public float unlockPercentage = 0f;
    public string typeCategory;
    public int XPUnlocked = 100;
    public List<MedalRequirement> medalRequirements = new List<MedalRequirement>();

    // Constructor for programmatic creation
    public Medal(string name, string desc, params MedalRequirement[] reqs)
    {
        medalName = name;
        medalDescription = desc;
        medalRequirements.AddRange(reqs);
    }

    public Medal() { } // Parameterless constructor for serialization
}

[System.Serializable]
public class MedalRequirement
{
    public Medal.RequirementType requirementType = Medal.RequirementType.None;
    public int amount = 0;
    public int gameLimit = 0;  // 0 for no limit
    public int turnLimit = 0; // 0 for no limit

    public MedalRequirement() { } // Parameterless constructor

    public MedalRequirement(Medal.RequirementType reqType, int amt, int gameLim = 0, int turnLim = -1)
    {
        requirementType = reqType;
        amount = amt;
        gameLimit = gameLim;
        turnLimit = turnLim;
    }
}
