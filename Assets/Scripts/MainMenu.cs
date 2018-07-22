using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(StaticValues.levelList[0].levelName);
    }

    public void StartCredits() {
        //SceneManager.LoadScene(StaticValues.levelList[0]); // Hardcoded, consider getting at runtime.
        //SceneManager.LoadScene(4);
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame() {
        Application.Quit();
        print("Exiting game");
    }
}
