//MasteryCategoryData.cs

using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MasteryCategoryData", menuName = "Game/MasteryCategoryData", order = 1)]
public class MasteryCategoryData : ScriptableObject
{
    [System.Serializable]
    public class Category
    {
        public string categoryName;
        // Add other properties here if needed, e.g., int categoryID, string description, etc.
    }

    public List<Category> categories = new List<Category>();
}