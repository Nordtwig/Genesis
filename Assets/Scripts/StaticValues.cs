using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues {

    public enum DoorKeyType { Yellow, Green, White };
    public enum MessageType { DeathMessage, WinMessage, TotalScoreMessage };

    //Class to hold level info
    public class Level
    {
        public string levelName;
        public int levelScore;

        public Level (string levelName, int levelScore)
        {
            this.levelName = levelName;
            this.levelScore = levelScore;
        }

    }

    //The playable levels and their scores
    public static Level[] levelList = {
        new Level("Level 1", 0),
        new Level("Easy Level 1", 500),
        new Level("Easy Level 2", 700),
        new Level("Test Level", 1000),
    };


    //Delays for player death and level win (in seconds)
    public static float playerDeathDelay = 1;
    public static float levelWinDelay = 2;


    public static Dictionary<MessageType, string> messages = new Dictionary<MessageType, string>() {
        {MessageType.DeathMessage, "You died!"},
        {MessageType.WinMessage, "You win!"},
        {MessageType.TotalScoreMessage, "You beat all levels!\nTotal score: "},
    };

}
