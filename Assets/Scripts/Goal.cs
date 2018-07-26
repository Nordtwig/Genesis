using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField] AudioSource goalSource;
    [SerializeField] AudioClip winSound;

    void Start()
    {
        goalSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameController.gameController.ShowMessage(StaticValues.MessageType.WinMessage);
            GameController.gameController.NextLevel(StaticValues.levelWinDelay);
            goalSource.PlayOneShot(winSound, 1.0f);
        }
    }
}
