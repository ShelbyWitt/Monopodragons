//MedalCategoryData.cs


using UnityEngine;
using System.Collections.Generic;
using MedalSystem;

[CreateAssetMenu(fileName = "MedalCategoryData", menuName = "Game/MedalCategoryData", order = 1)]
public class MedalCategoryData : ScriptableObject
{
    [System.Serializable]
    public class Category
    {
        public string categoryName;
        // Add other properties here if needed, e.g., int categoryID, string description, etc.
    }

    public List<Category> categories = new List<Category>();
}