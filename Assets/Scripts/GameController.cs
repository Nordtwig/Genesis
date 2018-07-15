using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Make the game controller a static singleton
    public static GameController gameController = null;

    [SerializeField] List<GameObject> pickups;
    [SerializeField] List<GameObject> doors;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] GameObject player;

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
        //Any initialization that might be needed later
    }

    public void ResetLevel()
    {
        foreach (GameObject pickup in pickups){
            PickUp pickupScript = pickup.gameObject.GetComponent<PickUp>() as PickUp;
            pickupScript.ResetPickup();
        }
        foreach (GameObject door in doors)
        {
            Door doorScript = door.gameObject.GetComponent("Door") as Door;
            doorScript.ResetDoor();
        }
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyScript = enemy.gameObject.GetComponent("Enemy") as Enemy;
            enemyScript.ResetEnemy();
        }
        Player playerScript = player.gameObject.GetComponent("Player") as Player;
        playerScript.ResetPlayer();
    }

}
