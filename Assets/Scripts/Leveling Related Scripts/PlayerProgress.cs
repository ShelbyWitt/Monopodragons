//PlayerProgress.cs


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;



public class PlayerProgress
{
    public int level = 1;   //current level
    public int xp = 0;  //current xp

    //Stats
    public int gamesPlayed = 0; //total

    //Task System
    public int[] dailyTaskProgress;
    public int[] weeklyTaskProgress;
    public int[] monthlyTaskProgress;
    public bool[] dailyTaskCompleted;
    public bool[] weeklyTaskCompleted;
    public bool[] monthlyTaskCompleted;
    public System.DateTime lastReset;

    //XP Function for each level
    public int XpToNextLevel => level * 100;

    // Initialize default values for a new player
    public void Initialize()
    {
        dailyTaskProgress = new int[3];   // e.g., 3 daily tasks
        dailyTaskCompleted = new bool[3];
        lastReset = DateTime.Now;
    }

}
