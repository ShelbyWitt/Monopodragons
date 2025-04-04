//MedalData.cs


using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MedalData", menuName = "Game/MedalData", order = 1)]
public class MedalData : ScriptableObject
{
    [SerializeField] public List<Medal> raceMedals = new List<Medal>();
    [SerializeField] public List<Medal> classMedals = new List<Medal>();
    [SerializeField] public List<Medal> gearMedals = new List<Medal>();
    [SerializeField] public List<Medal> weaponMedals = new List<Medal>();
    [SerializeField] public List<Medal> petMedals = new List<Medal>();
    [SerializeField] public List<Medal> masteryMedals = new List<Medal>();
}