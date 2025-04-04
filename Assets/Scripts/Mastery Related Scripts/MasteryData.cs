//MasteryData.cs


using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MasteryData", menuName = "Game/MasteryData", order = 1)]
public class MasteryData : ScriptableObject
{
    [SerializeField] public List<Mastery> raceMasteries = new List<Mastery>();
    [SerializeField] public List<Mastery> classMasteries = new List<Mastery>();
    [SerializeField] public List<Mastery> gearMasteries = new List<Mastery>();
    [SerializeField] public List<Mastery> weaponMasteries = new List<Mastery>();
    [SerializeField] public List<Mastery> petMasteries = new List<Mastery>();
    [SerializeField] public List<Mastery> masteryMasteries = new List<Mastery>();
}