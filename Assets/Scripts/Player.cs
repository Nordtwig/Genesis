using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject spawnPoint;

    //Set preferred movement type
    enum MovementType { TranslateNoRotation, TranslateWithRotation, RigidbodyMovement };
    [SerializeField] MovementType movementType;



    //Set speed of rotation and movement
    [SerializeField] int movementSpeed; //A value around 3-10 is suitable
    [SerializeField] int turnSpeed; //A value around 200-500 is suitable

    bool allowMovement;

    //Is set to true when key is picked up
    private bool isHoldingKey;
    private StaticValues.DoorKeyType heldKeyType;

    Key keySpawnPoint;
    GameObject keyModel;

    Rigidbody rigidBody;

    void Start () {

        isHoldingKey = false;
        allowMovement = true;
        spawnPoint = GameObject.Find("PlayerSpawnPoint").gameObject;

        transform.position = spawnPoint.transform.position;

        rigidBody = gameObject.GetComponent<Rigidbody>();

    }
	
    void FixedUpdate()
    {
        if (allowMovement)
        {
            //Three different kinds of player movement, set in inspector

            if(movementType == MovementType.TranslateNoRotation)
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
                transform.Translate(x, 0, 0);
                transform.Translate(0, 0, z);
            }
            else if (movementType == MovementType.TranslateWithRotation)
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
                transform.Rotate(0, x, 0);
                transform.Translate(0, 0, z);
            }
            else if (movementType == MovementType.RigidbodyMovement)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(horizontal, 0, vertical);
                rigidBody.velocity = movement * movementSpeed;
                rigidBody.position = new Vector3(rigidBody.position.x, 0, rigidBody.position.z);
            }

            
            
            


        }


        

    }

    public void AddKey(StaticValues.DoorKeyType type, Key newKeySpawnPoint)
    {
        //Check to see if player is already carrying a key
        if(isHoldingKey == true)
        {
            //If already carrying a key, reset the carried key
            //Then pick up the new one
            keySpawnPoint.ResetPickup();
            Destroy(keyModel);

        }

        isHoldingKey = true;
        heldKeyType = type;
        keySpawnPoint = newKeySpawnPoint;

        //Load the correct prefab belonging to the key type
        string prefabString = "Prefabs/Items/" + heldKeyType.ToString();
        GameObject keyModelPrefab = (GameObject)Resources.Load(prefabString);

        //Instantiate the prefab of the key and place it on top of the player model
        keyModel = Instantiate(keyModelPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        keyModel.transform.parent = transform;
        float playerHeight = transform.lossyScale.y;
        Vector3 keyPosition = new Vector3(transform.position.x, transform.position.y + playerHeight, transform.position.z);
        keyModel.transform.SetPositionAndRotation(keyPosition, transform.rotation);
        keyModel.name = "KeyModel";

        
    }

    public void RemoveKey()
    {
        isHoldingKey = false;
        Destroy(keyModel);
    }

    public bool IsHoldingKey()
    {
        return isHoldingKey;
    }

    public StaticValues.DoorKeyType HeldKeyType()
    {
        return heldKeyType;
    }

    public void PlayerDeath()
    {
        //Disallow movement on death
        allowMovement = false;
        //Show death message, any other things to do upon death
        GameController.gameController.ShowMessage(StaticValues.MessageType.DeathMessage);
        //Then reset level
        GameController.gameController.ResetLevel(StaticValues.playerDeathDelay);
    }

    public void ResetPlayer()
    {
        RemoveKey();
        transform.position = spawnPoint.transform.position;
        allowMovement = true;
    }
}
