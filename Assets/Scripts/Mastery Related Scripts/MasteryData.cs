//MasteryData.cs


using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MasteryData", menuName = "Game/MasteryData", order = 1)]
public class MasteryData : ScriptableObject
{
    [SerializeField] public List<MasterySubcategory> raceSubcategories = new List<MasterySubcategory>();
    [SerializeField] public List<MasterySubcategory> classSubcategories = new List<MasterySubcategory>();
    [SerializeField] public List<MasterySubcategory> gearSubcategories = new List<MasterySubcategory>();
    [SerializeField] public List<MasterySubcategory> weaponSubcategories = new List<MasterySubcategory>();
    [SerializeField] public List<MasterySubcategory> petSubcategories = new List<MasterySubcategory>();
    [SerializeField] public List<MasterySubcategory> masterySubcategories = new List<MasterySubcategory>();

    // References to data sources
    public RaceData raceData;
    public ClassData classData;
    public PetDatabase petDatabase;
    public GearData gearData; // Assuming GearData exists for gear items
    public MasteryCategoryData masteryCategoryData;
    // Note: Weapon and Mastery types need defined data sources; adjust as needed
}