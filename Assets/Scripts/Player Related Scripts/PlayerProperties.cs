//PlayerProperties.cs
using UnityEngine;
using TMPro;

[System.Serializable]
    public class PlayerProperties
    {

    [Header("Statuses")]
        //status effects
        public bool isPoisoned; public int PoisonedAmount;

        public bool isOnFire; public int FireAmount;

        public bool isFrozen; public int FrozenAmount;

        public bool isShocked; public int ShockedAmount;

        public bool isCursed; public int CursedAmount;

        public bool isBleeding; public int BleedAmount;

        public bool isTouchingWater;

    [Header("Resistances")]

        //resistances
        public int PoisonResistance; public int FireResistance; public int FreezeResistance; public int ShockResistance; public int CursedResistance; public int BleedResistance;

    [Header("Stats")]
    //stat characteristices
        public int Health; public int MaxHealth;

        public int Mana; public int MaxMana;

        public int Shield; public int MaxShield;

        public int Strength; public int MaxStrength;

        public int Magic; public int MaxMagic;

        public int Defense; public int MaxDefense;

        public int Dexterity; public int MaxDexterity;

        public int Agility; public int MaxAgility; 

        public int Luck; public int MaxLuck;

        public int Intelligence; public int MaxIntelligence;

        public int AllStats; public int MaxAllStats;

        public int Stamina; public int MaxStamina;

        public int Attack; public int MaxAttack;

        public int Speed; public int MaxSpeed;

        public int CriticalChance; public int MaxCriticalChance;

        public int CriticalDamage; public int MaxCriticalDamage;

        public int DodgeChance; public int MaxDodgeChance;

        public int Pierce; public int MaxPierce;

        public int Accuracy; public int MaxAccuracy;


    [Header("Extra Stats")]

        public int Gold;

        public int ExtraDice;


    [Header("Buffs")]

        public int HealthBuff; public int ManaBuff; public int ShieldBuff; public int StrengthBuff; public int MagicBuff; public int DefenseBuff;

        public int DexterityBuff; public int AgilityBuff; public int LuckBuff; public int IntelligenceBuff; public int AllStatsBuff; public int StaminaBuff;

        public int AttackBuff; public int SpeedBuff; public int CriticalChanceBuff; public int CriticalDamageBuff; public int DodgeChanceBuff; public int PierceBuff; public int AccuracyBuff;


    
    }


    