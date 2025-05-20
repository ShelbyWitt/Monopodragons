//Items.cs

using UnityEngine;
using System;
using System.Collections.Generic;
using MedalSystem;

[System.Serializable]
public class Items
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


    public string itemName = "New Item";
    public string itemDescription = "Item Description.";
    public bool isElixer = false;
    public float amount = 0f;
    public int XPGained = 10;
   // public List<MedalRequirement> medalRequirements = new List<MedalRequirement>();

    // Constructor for programmatic creation
    public Items(string name, string itemDesc)
    {
        itemName = name;
        itemDescription = itemDesc;
    }

    public Items() { } // Parameterless constructor for serialization
}



public enum ItemRequirements
{
    None,
    Level

}


[System.Serializable]
public class ItemSubcategory
{
    public string subcategoryName;           // e.g., "Human" for Race, "Mage" for Class
    public List<Items> items = new List<Items>(); // Medals under this subcategory
}
