using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

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
            if (playerScript.IsHoldingKey())
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        Destroy(this.gameObject);
    }

}
