//AccountProgress.cs


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;



public class AccountProgress
{
    public int level = 1;   //current level
    public int xp = 0;  //current xp
    public int tokens = 0;  //current tokens
    public int playerID = 0;

    //Stats for account
    public int gamesPlayed = 0; //total
    public int gamesWon = 0;    //total
    public int timePlayed = 0;  //total
    public int enemiesKilled = 0;   //total
    public int instancesPlayed = 0; //total
    public int medalsEarned = 0;    //total
    public int masteriesEarned = 0; //total

    public bool isOnline = false;
    

    //Medal System
    


    //Task System
    public int[] dailyTaskProgress;
    public int[] weeklyTaskProgress;
    public int[] monthlyTaskProgress;
    public bool[] dailyTaskCompleted;
    public bool[] weeklyTaskCompleted;
    public bool[] monthlyTaskCompleted;
    public System.DateTime lastOnline;

    //XP to each level
    public int XpToNextLevel = 100;

    // Initialize default values for a new player
    public void Initialize()
    {

        dailyTaskProgress = new int[3];   // e.g., 3 daily tasks
        dailyTaskCompleted = new bool[3];
        lastOnline = DateTime.Now;


    }

}
