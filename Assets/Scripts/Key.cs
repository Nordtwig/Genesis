using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{

    
    [SerializeField] Items.DoorKeyType keyType;

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {
		
	}

    override public void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent("Player") as Player;
        playerScript.AddKey(keyType);
    }
}
