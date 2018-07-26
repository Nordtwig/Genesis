using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int movementSpeed;
    enum MovementType { x, z, none };
    [SerializeField] MovementType movementType;
    [SerializeField] AudioSource enemySource;
    [SerializeField] AudioClip deathSound;

    Vector3 spawnPoint;

    // Use this for initialization
    void Start() {
        spawnPoint = transform.position;
        enemySource = GetComponent<AudioSource>();
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


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player playerScript = other.gameObject.GetComponent("Player") as Player;
            playerScript.PlayerDeath();
            enemySource.PlayOneShot(deathSound, 1.0f);
        }
        else {
            //Collision with environment, reverse direction
            movementSpeed *= -1;
        }
    }

    public void ResetEnemy()
    {
        transform.position = spawnPoint;
    }

}
