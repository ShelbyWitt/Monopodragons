// PetDatabase.cs
using UnityEngine;

[CreateAssetMenu(fileName = "PetDatabase", menuName = "Game/PetDatabase")]
public class PetDatabase : ScriptableObject
{
    public PetData[] pets;
}