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

    public void AddKey()
    {
        isHoldingKey = true;
        GameObject keyModel = transform.Find("KeyModel").gameObject;
        if(keyModel != null)
        {
            keyModel.SetActive(true);
        }
        else
        {
            Debug.Log("Could not find object.");
        }
        
    }

    public void RemoveKey()
    {
        isHoldingKey = false;
        GameObject keyModel = transform.Find("KeyModel").gameObject;
        keyModel.SetActive(false);
    }
}
