using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			// Add to booty
			PickUpItem ();
			Destroy (gameObject);
		}
	}
}
