using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Make the game controller a static singleton
    public static GameController gameController = null;

    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> doors;
    [SerializeField] List<GameObject> pickups;
    [SerializeField] List<GameObject> enemies;

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
            

        //Do not destroy gamecontroller upon reloading scene
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {
        //Any initialization goes here

        //Sets references to all objects that vill be reset upon LevelReset
        /*player = GameObject.Find("Player").gameObject;

        Transform doorsCategory = GameObject.Find("Doors").gameObject.transform;
        foreach (Transform child in doorsCategory)
        {
            //Debug.Log("Found a door with name: " + child.name);
            doors.Add(child.gameObject);
        }
        Transform pickupsCategory = GameObject.Find("Pickups").gameObject.transform;
        foreach (Transform child in pickupsCategory)
        {
            //Debug.Log("Found a pickup with name: " + child.name);
            pickups.Add(child.gameObject);
        }
        Transform enemiesCategory = GameObject.Find("Enemies").gameObject.transform;
        foreach (Transform child in enemiesCategory)
        {
            //Debug.Log("Found an enemy with name: " + child.name);
            enemies.Add(child.gameObject);
        }*/

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

}
