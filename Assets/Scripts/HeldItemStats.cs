//HeldItemStats.cs

using UnityEngine;

[System.Serializable]
public class HeldItemStats
{

    //status effects
    public bool isPoisoned; public int PoisonedAmount;

    public bool isOnFire; public int FireAmount;

    public bool isFrozen; public int FrozenAmount;

    public bool isShocked; public int ShockedAmount;

    public bool isCursed; public int CursedAmount;

    public bool isBleeding; public int BleedAmount;

    //resistances
    public int PoisonResistance; public int FireResistance; public int FreezeResistance; public int ShockResistance; public int CursedResistance; public int BleedResistance;

    //stat characteristices
    public int HealthBuff;

    public int ManaBuff;

    public int ShieldBuff;

    public int StrengthBuff;

    public int MagicBuff;

    public int DefenseBuff;

    public int DexterityBuff;

    public int AgilityBuff;

    public int LuckBuff;

    public int IntelligenceBuff;

    public int AllStatsBuff;

    public int StaminaBuff;

    public int AttackBuff;

    public int SpeedBuff;

    public int CriticalChanceBuff;

    public int CriticalDamageBuff;

    public int DodgeChanceBuff;

    public int PierceBuff;

    public int AccuracyBuff;

    public int Gold;

    public int ExtraDice;
}
