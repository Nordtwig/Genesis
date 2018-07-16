using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues {

    public enum DoorKeyType { Yellow, Green, White };
    public enum MessageType { DeathMessage, WinMessage };

    public static Dictionary<MessageType, string> messages = new Dictionary<MessageType, string>() {
        {MessageType.DeathMessage, "You died!"},
        {MessageType.WinMessage, "You win!"},
    };

}
