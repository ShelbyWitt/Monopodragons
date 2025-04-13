//RaceManager.cs
using UnityEngine;
using System.Collections.Generic;


[ExecuteAlways]
public class RaceManager : MonoBehaviour
{
    [SerializeField]
    private RaceData raceData; // Assign the RaceData asset in the Inspector

    // Method to get race names from RaceData
    public List<string> GetRaceNames()
    {
        List<string> raceNames = new List<string>();
        foreach (var race in raceData.races) // Assuming 'races' is the list in RaceData
        {
            raceNames.Add(race.raceName); // Assuming 'raceName' is the name property
        }
        return raceNames;
    }

    public RaceProperty GetRaceProperty(string raceName)
    {
        foreach (var race in raceData.races)
        {
            if (race.raceName == raceName)
                return race;
        }
        Debug.LogWarning("Race " + raceName + " not found, defaulting to first race.");
        return raceData.races.Length > 0 ? raceData.races[0] : null;
    }


    // Existing method to get race properties
    public PlayerProperties GetRaceProperties(string raceName)
    {
        foreach (var race in raceData.races)
        {
            if (race.raceName == raceName)
            {
                return race.properties; // Assuming 'properties' holds PlayerProperties
            }
        }
        Debug.LogWarning($"Race '{raceName}' not found in RaceData. Returning default (Human) properties.");
        return raceData.races[0].properties; // Fallback to first race (e.g., Human)
    }
}