using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //Make the game controller a static singleton
    public static GameController gameController = null;

    int currentLevel;

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
            return;
        }

        InitGame();

        //Do not destroy gamecontroller upon reloading scene
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);

        //Add a listener function to detect scene change
        SceneManager.sceneLoaded += OnSceneLoaded;


    }

    //Noah's ugly code corner
    //Super rough, just to finish the game loop for now!
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Press Esc for Main Menu
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKey("r")) // Press R for Restart
        {
            ResetLevel();
        }
    }

    //Initializes the game when the first level is loaded
    //Sets references to UI components that the class will access
    //Sets the level
    void InitGame()
    {
        canvas = GameObject.Find("Canvas");
        scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
        statusText = GameObject.Find("Canvas/StatusText").GetComponent<Text>();
        scoreBackground = GameObject.Find("Canvas/ScoreBackground").GetComponent<Image>();
        statusBackground = GameObject.Find("Canvas/StatusBackground").GetComponent<Image>();

        currentLevel = 0;
    }

    //Initializes the newly loaded level
    //Sets references to all interactable objects in the level (enemies, doors, pickups)
    void InitLevel()
    {

        //Clears any old references
        doors = new List<GameObject>();
        pickups = new List<GameObject>();
        enemies = new List<GameObject>();

        //Sets references to all interactable objects in the level
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

    //Call this to "restart" the level
    //Resets all interactable objects in the level, as well as the player
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

    //Call this to show a message in the Status window (define messages in StaticValues messageType)
    public void ShowMessage(StaticValues.MessageType messageType)
    {
        string messageString = "";
        StaticValues.messages.TryGetValue(messageType, out messageString);

        StartCoroutine(ShowStatusText(messageString, 1));
    }

    //Shows a status text with a delay, call method ShowMessage to use this
    IEnumerator ShowStatusText(string message, float delay)
    {
        statusText.text = message;
        statusText.enabled = true;
        statusBackground.enabled = true;

        yield return new WaitForSeconds(delay);

        statusText.enabled = false;
        statusBackground.enabled = false;
    }

    //Call this to trigger the next level of the game
    //If called when on the last level, loads Credits
    public void NextLevel()
    {
        currentLevel += 1;
        SceneManager.LoadScene(StaticValues.levelList[currentLevel]);
        
    }

    //Initializes the level when a new level is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Only call InitLevel if outside Menu and Credits
        if (scene.name != "Main Menu" && scene.name != "Credits")
        {
            InitLevel();
        } 
    }

}