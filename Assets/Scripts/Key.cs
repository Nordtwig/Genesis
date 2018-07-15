using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{

    
    [SerializeField] StaticValues.DoorKeyType keyType;

    // Use this for initialization
    void Start () {
        

    }


    override public void OnPickup(GameObject player)
    {
        Player playerScript = player.GetComponent("Player") as Player;
        playerScript.AddKey(keyType, this.gameObject.GetComponent("Key") as Key);
    }

}
