//ClassData.cs

using UnityEngine;

[System.Serializable]
public class ClassProperty
{
    public string className;
    public PlayerProperties properties;
}

[CreateAssetMenu(fileName = "ClassData", menuName = "Game/ClassData", order = 1)]
public class ClassData : ScriptableObject
{
    public ClassProperty[] classes;
}