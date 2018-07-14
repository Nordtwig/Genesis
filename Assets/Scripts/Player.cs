using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Set useRotation to preferred movement type
    [SerializeField] bool useRotation;
    //Set speed of rotation and movement
    [SerializeField] int movementSpeed; //A value around 3-7
    [SerializeField] int turnSpeed; //A value around 200-500

    //Is set to true when key is picked up
    private bool isHoldingKey;
    private Items.DoorKeyType heldKeyType;

    GameObject keyModelInstance;
    public GameObject keyModelPrefab;

    // Use this for initialization
    void Start () {

        isHoldingKey = false;

    }
	
	// Update is called once per frame
    void FixedUpdate()
    {

        //Two different kinds of player movement, set in useRotation global boolean
        if (useRotation)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
        else
        {

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
            transform.Translate(x, 0, 0);
            transform.Translate(0, 0, z);
        }
        
    }

    public void AddKey(Items.DoorKeyType type)
    {
        //Add a check here to see if already carrying a key
        //...

        isHoldingKey = true;
        heldKeyType = type;

        //Load in the correct prefab belonging to the key type
        string prefabString = "Prefabs/Items/" + heldKeyType.ToString();
        GameObject keyModelPrefab = (GameObject)Resources.Load(prefabString);

        //Instantiate the prefab of the key and place it on top of the player model
        keyModelInstance = Instantiate(keyModelPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        keyModelInstance.transform.parent = transform;
        float playerHeight = transform.lossyScale.y;
        Vector3 keyPosition = new Vector3(transform.position.x, transform.position.y + playerHeight, transform.position.z);
        keyModelInstance.transform.SetPositionAndRotation(keyPosition, transform.rotation);
        keyModelInstance.name = "KeyModel";

        
    }

    public void RemoveKey()
    {
        isHoldingKey = false;
        GameObject keyModel = transform.Find("KeyModel").gameObject;
        Destroy(keyModel);
    }

    public bool IsHoldingKey()
    {
        return isHoldingKey;
    }

    public Items.DoorKeyType HeldKeyType()
    {
        return heldKeyType;
    }
}
