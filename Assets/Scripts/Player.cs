using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public bool IsArmed;
    public GameObject HeldWeapon;

	// Use this for initialization
	void Start ()
	{
        Speed = 10;
	    RotationSpeed = 80;
	    IsArmed = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKey(KeyCode.Q))
            gameObject.transform.Rotate(-Vector3.up * RotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            gameObject.transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

	    if (Input.GetKey(KeyCode.Space))
	    {
	        if (gameObject.GetComponent<Player>().HeldWeapon != null)
	        {
	            gameObject.GetComponent<Player>().IsArmed = false;
	            HeldWeapon.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                HeldWeapon.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                HeldWeapon.gameObject.GetComponent<Weapon>().IsShot = true;
                //HeldWeapon.gameObject.GetComponent<Rigidbody>().velocity = HeldWeapon.transform.forward * 100;
                HeldWeapon.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
                HeldWeapon.gameObject.GetComponent<Weapon>().IsHeld = false;
                gameObject.GetComponent<Player>().HeldWeapon = null;
	        }
	    }

        transform.position += movement * Time.deltaTime * Speed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Weapon") && IsArmed == false)
        {
            IsArmed = true;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Weapon>().IsHeld = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            other.gameObject.GetComponent<Weapon>().Player = gameObject;
            gameObject.GetComponent<Player>().HeldWeapon = other.gameObject;
        }
    }
}
