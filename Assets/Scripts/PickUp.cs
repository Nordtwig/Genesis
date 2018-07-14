using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

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
            OnPickup(c.gameObject);
            Destroy(this.gameObject);
        }
    }

    virtual public void OnPickup(GameObject player)
    {
        //Override in child class
    }


}
