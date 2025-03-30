//GearData.cs

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
    public Gear[] gears;
}