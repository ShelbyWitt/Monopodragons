//RaceData.cs

using UnityEngine;

[System.Serializable]
public class RaceProperty
{
    public string raceName;
    public PlayerProperties properties;
}

[CreateAssetMenu(fileName = "RaceData", menuName = "Game/RaceData", order = 1)]
public class RaceData : ScriptableObject
{
    public RaceProperty[] races;
}