using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void StartCredits() {
        SceneManager.LoadScene(2); // Hardcoded, consider getting at runtime.
    }

    public void ExitGame() {
        Application.Quit();
        print("Exiting game");
    }
}
