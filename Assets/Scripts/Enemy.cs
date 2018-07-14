using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int movementSpeed;
    enum MovementType { x, z, none };
    [SerializeField] MovementType movementType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var move = Time.deltaTime * movementSpeed;

        switch (movementType)
        {
            case MovementType.x:
                transform.Translate(move, 0, 0);
                break;
            case MovementType.z:
                transform.Translate(0, 0, move);
                break;
            case MovementType.none:
                break;
            default:
                break;
        }


    }


    void OnCollisionEnter(Collision c)
    {

        //Debug.Log("Enemy colliding with object with tag: " + c.gameObject.tag);

        if (c.gameObject.tag == "Player")
        {
            //Player damage stuff goes here probably
        }
        else {
            //Collision with environment, reverse direction
            movementSpeed *= -1;
        }
    }

}
