using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			// Add to booty
			Destroy (gameObject);
		}
	}

}
