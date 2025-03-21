//Gear.cs

using UnityEngine;

[System.Serializable]
public class Gear : MonoBehaviour
{
    public string gearName;
    public string slotType; // e.g., "Helmet", "Robe", "Pants", "Shoes", "Ring", "Amulet"
    public HeldItemStats stats;

    // Constructor to initialize gear
    public Gear(string name, string slot, HeldItemStats gearStats)
    {
        gearName = name;
        slotType = slot;
        stats = gearStats;
    }
}