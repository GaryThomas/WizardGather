using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
	public Vector2 jumpAdjust = new Vector2 (2.5f, 8.5f);

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			Rigidbody2D _rb = other.gameObject.GetComponent<Rigidbody2D> ();
			_rb.velocity += jumpAdjust;
			_rb.AddForce (jumpAdjust);
			Destroy (gameObject);
		}
	}

}
