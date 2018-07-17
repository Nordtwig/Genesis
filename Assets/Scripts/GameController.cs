using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //Make the game controller a static singleton
    public static GameController gameController = null;

    GameObject canvas;
    Text scoreText;
    Text statusText;
    Image scoreBackground;
    Image statusBackground;

    GameObject player;
    List<GameObject> doors;
    List<GameObject> pickups;
    List<GameObject> enemies;

    //Awake is called before Start functions
    void Awake()
    {
        //Enforce singleton pattern
        if (gameController == null)
        {
            gameController = this;
        }
        else if (gameController != this)
        {
            Destroy(gameObject);
        }

        //Add a listener function to detect scene change
        SceneManager.sceneLoaded += OnSceneLoaded;

        InitGame();

        //Do not destroy gamecontroller upon reloading scene
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);


    }

    void InitGame()
    {
        //Any initialization goes here

        //Sets necessary references to UI components
        canvas = GameObject.Find("Canvas");
        scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
        statusText = GameObject.Find("Canvas/StatusText").GetComponent<Text>();
        scoreBackground = GameObject.Find("Canvas/ScoreBackground").GetComponent<Image>();
        statusBackground = GameObject.Find("Canvas/StatusBackground").GetComponent<Image>();
        
        

    }

    public void InitLevel()
    {

        Debug.Log("Initiating level");
        //Clears any old references
        doors = new List<GameObject>();
        pickups = new List<GameObject>();
        enemies = new List<GameObject>();


        //Sets references to all objects that vill be reset upon LevelReset
        player = GameObject.Find("Player").gameObject;

        Transform doorsCategory = GameObject.Find("Doors").gameObject.transform;
        foreach (Transform child in doorsCategory)
        {
            doors.Add(child.gameObject);
        }
        Transform pickupsCategory = GameObject.Find("Pickups").gameObject.transform;
        foreach (Transform child in pickupsCategory)
        {
            pickups.Add(child.gameObject);
        }
        Transform enemiesCategory = GameObject.Find("Enemies").gameObject.transform;
        foreach (Transform child in enemiesCategory)
        {
            enemies.Add(child.gameObject);
        }
    }

    public void ResetLevel()
    {
        Player playerScript = player.gameObject.GetComponent("Player") as Player;
        playerScript.ResetPlayer();

        foreach (GameObject door in doors)
        {
            Door doorScript = door.gameObject.GetComponent("Door") as Door;
            doorScript.ResetDoor();
        }

        foreach (GameObject pickup in pickups){
            PickUp pickupScript = pickup.gameObject.GetComponent<PickUp>() as PickUp;
            pickupScript.ResetPickup();
        }
        
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.gameObject.GetComponent("Enemy") as Enemy;
            enemyScript.ResetEnemy();
        }
        
    }


    public void ShowMessage(StaticValues.MessageType messageType)
    {
        string messageString = "";
        StaticValues.messages.TryGetValue(messageType, out messageString);

        StartCoroutine(ShowStatusText(messageString, 1));
    }

    IEnumerator ShowStatusText(string message, float delay)
    {
        statusText.text = message;
        statusText.enabled = true;
        statusBackground.enabled = true;

        yield return new WaitForSeconds(delay);

        statusText.enabled = false;
        statusBackground.enabled = false;
    }

    public void ChangeScene()
    {
        //Later have a system for what level to change to
        SceneManager.LoadScene("Test Level");
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitLevel();
    }


}
