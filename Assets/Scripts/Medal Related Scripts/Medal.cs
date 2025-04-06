//Medal.cs

using UnityEngine;
using System;
using System.Collections.Generic;
using MedalSystem;

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
        Collect_All_Public_Medals_From_Playing,
        Collect_All_Hidden_Medals_From_Playing,
        Collect_All_Public_Medals_From_Moving_Tiles,
        Collect_All_Hidden_Medals_From_Moving_Tiles,
        Collect_All_Public_Medals_From_Killing_Enemies,
        Collect_All_Hidden_Medals_From_Killing_Enemies,
        Collect_All,
    }


    public string medalName = "New Medal";
    public string medalReqDescription = "Achieve ____ goal to unlock this medal.";
    public string medalTagline = "Message player gets when unlocked";
    public bool hasUnlocked = false;
    public bool isHiddenMedal = false;
    public float unlockPercentage = 0f;
    public int XPUnlocked = 100;
    public List<MedalRequirement> medalRequirements = new List<MedalRequirement>();

    // Constructor for programmatic creation
    public Medal(string name, string reqDesc, string tag, params MedalRequirement[] reqs)
    {
        medalName = name;
        medalReqDescription = reqDesc;
        medalTagline = tag;
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
    public int turnLimit = -1; // -1 for no limit
    public string type;

    public MedalRequirement() { } // Parameterless constructor

    public MedalRequirement(Medal.RequirementType reqType, int amt, int gameLim = 0, int turnLim = -1, string _type = null)
    {
        requirementType = reqType;
        amount = amt;
        gameLimit = gameLim;
        turnLimit = turnLim;
        type = _type;
    }
}

public enum MedalRequirementType
{
    None,
    Play_With,
    Leveling,
    Use_Skill,

}


[System.Serializable]
public class MedalSubcategory
{
    public string subcategoryName;           // e.g., "Human" for Race, "Mage" for Class
    public List<Medal> medals = new List<Medal>(); // Medals under this subcategory
}