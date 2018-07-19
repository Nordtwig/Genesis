using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void StartCredits() {
        //SceneManager.LoadScene(StaticValues.levelList[0]); // Hardcoded, consider getting at runtime.
        SceneManager.LoadScene(4);
    }

    public void ExitGame() {
        Application.Quit();
        print("Exiting game");
    }
}
