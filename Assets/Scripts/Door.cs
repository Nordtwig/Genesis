using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] StaticValues.DoorKeyType doorType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            Player playerScript = c.gameObject.GetComponent("Player") as Player;
            if (playerScript.IsHoldingKey() && playerScript.HeldKeyType() == doorType)
            {
                OpenDoor(playerScript);
            }
        }
    }

    void OpenDoor(Player playerScript)
    {
        playerScript.RemoveKey();
        Destroy(this.gameObject);
    }

}
