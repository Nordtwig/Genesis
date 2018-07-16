using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameController.gameController.ShowMessage(StaticValues.MessageType.WinMessage);
        }
    }
}
