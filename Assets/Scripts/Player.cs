using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Set useRotation to preferred movement type
    [SerializeField] bool useRotation = false;
    //Set speed of rotation and movement
    [SerializeField] int movementSpeed = 5;
    [SerializeField] int turnSpeed = 200;

    // Use this for initialization
    void Start () {

        
		
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
}
