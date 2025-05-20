//ItemData.cs

using UnityEngine;
using MedalSystem;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ItemSystem
{

    // Enum defining possible requirement types
    public enum RequirementType
    {
        None,        // Default or no requirement
        Play_With,   // Play with a specific subcategory
        Leveling,    // Level up a certain number of times
        Use_Skill    // Use a skill a certain number of times
        // Add more types as needed for your game
    }


    // Represents an individual medal
    [System.Serializable]
    public class Item
    {
        public string itemName;                    // Name of the medal
        public string itemDescription;             // Description of the medal
        public bool hasUnlocked;                    // Whether the medal is unlocked
                                                    //       public List<MedalRequirement> requirements = new List<MedalRequirement>(); // List of requirements
    }

    // Represents a single requirement for a medal (e.g., "Play with Human 1 time")
    [System.Serializable]
    public class ItemRequirement
    {
        public RequirementType requirementType; // Type of requirement (e.g., Play_With)
        public int amount;                      // Amount needed to fulfill the requirement
    }

    [CreateAssetMenu(fileName = "ItemData", menuName = "Game/ItemData", order = 1)]
    public class ItemData : ScriptableObject
    {
        [SerializeField] public List<ItemSubcategory> elixerSubcategories = new List<ItemSubcategory>();
        //[SerializeField] public List<MedalSubcategory> classSubcategories = new List<MedalSubcategory>();
        //[SerializeField] public List<MedalSubcategory> gearSubcategories = new List<MedalSubcategory>();
        //[SerializeField] public List<MedalSubcategory> petSubcategories = new List<MedalSubcategory>();
        //[SerializeField] public List<MedalSubcategory> masterySubcategories = new List<MedalSubcategory>();

        // Data source fields for auto-population
        //public ItemData itemData;

        //public RaceData raceData;
        //public ClassData classData;
        //public PetDatabase petDatabase;
        //public GearData gearData;
        //public MasteryData masteryData;
        // Add more data sources (e.g., MasteryData) as needed
    }


    // Groups medals under a subcategory (e.g., "Human" for races)
    [System.Serializable]
    public class ElixerSubcategory
    {
        public string subcategoryName;        // Name of the subcategory (e.g., "Human")
        public List<Items> items = new List<Items>(); // List of medals in this subcategory
    }
}
//    [System.Serializable]
//    public class ClassSubcategory
//    {
//        public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//        public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//    }

//    // Groups medals under a subcategory (e.g., "Human" for races)
//    [System.Serializable]
//    public class PetSubcategory
//    {
//        public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//        public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//    }

//    [System.Serializable]
//    public class GearSubcategory
//    {
//        public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//        public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//    }

//    // Groups medals under a subcategory (e.g., "Human" for races)


//    [System.Serializable]
//    public class MasterySubcategory
//    {
//        public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//        public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//    }
//}