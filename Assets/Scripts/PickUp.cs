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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPickup(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    virtual public void OnPickup(GameObject player)
    {
        //Override in child class
    }

    public void ResetPickup()
    {
        this.gameObject.SetActive(true);
    }


}
