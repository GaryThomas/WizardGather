using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			Debug.Log ("*** OUCH!");
		}
	}
}
