using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDir : MonoBehaviour
{
	public void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
		if (other.gameObject.tag == "Player") {
			Wizard wizard = other.gameObject.GetComponent<Wizard> ();
			Rigidbody2D _rb = other.gameObject.GetComponent<Rigidbody2D> ();
			_rb.transform.localScale = new Vector2 (_rb.transform.localScale.x * -1, _rb.transform.localScale.y);
			wizard.moveDir *= -1;
			Destroy (gameObject);
		}
	}
}
