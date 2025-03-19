//PetData.cs

using UnityEngine;

[System.Serializable]
public class PetProperty
{
    public string petName;
    public PetData properties;
}

[CreateAssetMenu(fileName = "PetData", menuName = "Game/PetData")]
public class PetData : ScriptableObject
{
    public string petName;
    public PetStats baseStats; // Base stats at level 1
    public PetGrowth growth; // Growth rates per level
}