using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] StaticValues.DoorKeyType doorType;

    BoxCollider doorCollider;

    bool isSliding;
    Vector3 originalPosition;
    float endPositionY;


    void Start () {
        isSliding = false;

        doorCollider = transform.GetComponent<BoxCollider>();

        originalPosition = transform.position;
        endPositionY = originalPosition.y - doorCollider.size.y;
    }

    void Update()
    {
        if (isSliding)
        {
            
            var move = Time.deltaTime * 5;
            transform.Translate(0, -move, 0);

            if (transform.position.y < endPositionY)
            {
                isSliding = false;
            }

        }

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

        doorCollider.enabled = false;
        isSliding = true;
    }

    public void ResetDoor()
    {
        doorCollider.enabled = true;
        transform.position = originalPosition;
    }


}
