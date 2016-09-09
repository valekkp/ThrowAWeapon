using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public bool IsHeld;

    public bool IsShot;

    public GameObject Player;

	// Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (gameObject.GetComponent<Weapon>().IsHeld)
	    {
            gameObject.GetComponent<Weapon>().Player = Player;
	        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z) + Player.transform.forward * (Player.transform.localScale.x + 0.1f);
	        transform.rotation = Player.transform.rotation;
	    }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Weapon>().IsShot = false;
        }

        if (other.gameObject.CompareTag("Player") 
            && gameObject.GetComponent<Weapon>().Player != null 
            && gameObject.GetComponent<Weapon>().IsHeld == false
            && gameObject.GetComponent<Weapon>().IsShot == true)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
