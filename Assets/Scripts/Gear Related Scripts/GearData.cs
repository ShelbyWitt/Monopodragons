//GearData.cs

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GearProperty
{
    public string gearName;
    public GearProperties gearProperties;
}

[CreateAssetMenu(fileName = "GearData", menuName = "Gear/GearData", order = 1)]
public class GearData : ScriptableObject
{
    [SerializeField] public List<GearsSubcategory> Sets = new List<GearsSubcategory>();
    public Gear[] gears;
}


//// Groups medals under a subcategory (e.g., "Human" for races)
//[System.Serializable]
//public class SubcategoryGear
//{
//    public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//    public List<EquippableType> gearTypes = new List<EquippableType>(); // List of medals in this subcategory
//}

//[System.Serializable]
//public class SubcategoryWeapon
//{
//    public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//    public List<WeaponTypes> weaponTypes = new List<WeaponTypes>(); // List of medals in this subcategory
//}

//// Groups medals under a subcategory (e.g., "Human" for races)
//[System.Serializable]
//public class PetSubcategory
//{
//    public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//    public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//}

//[System.Serializable]
//public class GearSubcategory
//{
//    public string subcategoryName;        // Name of the subcategory (e.g., "Human")
//    public List<Medal> medals = new List<Medal>(); // List of medals in this subcategory
//}