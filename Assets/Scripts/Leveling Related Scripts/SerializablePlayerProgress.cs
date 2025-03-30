//SerializablePlayerProgress.cs

[System.Serializable]
public class SerializablePlayerProgress
{
    public int level;
    public int xp;
    public int gamesPlayed;
    public int[] dailyTaskProgress;
    public bool[] dailyTaskCompleted;
    public string lastReset; // Store DateTime as a string
}