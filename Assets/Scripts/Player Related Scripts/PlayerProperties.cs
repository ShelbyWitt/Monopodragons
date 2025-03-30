//PlayerProperties.cs
using UnityEngine;

[System.Serializable]
    public class PlayerProperties
    {

        //status effects
        public bool isPoisoned; public int PoisonedAmount;

        public bool isOnFire; public int FireAmount;

        public bool isFrozen; public int FrozenAmount;

        public bool isShocked; public int ShockedAmount;

        public bool isCursed; public int CursedAmount;

        public bool isBleeding; public int BleedAmount;

        public bool isTouchingWater;

        //resistances
        public int PoisonResistance; public int FireResistance; public int FreezeResistance; public int ShockResistance; public int CursedResistance; public int BleedResistance;

    //stat characteristices
        public int Health; public int MaxHealth; public int HealthBuff;

        public int Mana; public int MaxMana; public int ManaBuff;

        public int Shield; public int MaxShield; public int ShieldBuff;

        public int Strength; public int MaxStrength; public int StrengthBuff;

        public int Magic; public int MaxMagic; public int MagicBuff;

        public int Defense; public int MaxDefense; public int DefenseBuff;

        public int Dexterity; public int MaxDexterity; public int DexterityBuff;

        public int Agility; public int MaxAgility; public int AgilityBuff;   

        public int Luck; public int MaxLuck; public int LuckBuff;

        public int Intelligence; public int MaxIntelligence; public int IntelligenceBuff;

        public int AllStats; public int MaxAllStats; public int AllStatsBuff;

        public int Stamina; public int MaxStamina; public int StaminaBuff;

        public int Attack; public int MaxAttack; public int AttackBuff;

        public int Speed; public int MaxSpeed; public int SpeedBuff;

        public int CriticalChance; public int MaxCriticalChance; public int CriticalChanceBuff;

        public int CriticalDamage; public int MaxCriticalDamage; public int CriticalDamageBuff;

        public int DodgeChance; public int MaxDodgeChance; public int DodgeChanceBuff;

        public int Pierce; public int MaxPierce; public int PierceBuff;

        public int Accuracy; public int MaxAccuracy; public int AccuracyBuff;

        public int Gold;

        public int ExtraDice;
    }


    