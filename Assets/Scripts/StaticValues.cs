using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues {

    public enum DoorKeyType { Yellow, Green, White };
    public enum MessageType { DeathMessage, WinMessage };

    //The playable levels
    public static string[] levelList = { "Easy Level 1", "Easy Level 2", "Test Level", "Credits" };

    //Delays for player death and level win (in seconds)
    public static float playerDeathDelay = 1;
    public static float levelWinDelay = 2;


    public static Dictionary<MessageType, string> messages = new Dictionary<MessageType, string>() {
        {MessageType.DeathMessage, "You died!"},
        {MessageType.WinMessage, "You win!"},
    };

}
