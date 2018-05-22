using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2D : MonoBehaviour
{
	Rigidbody2D _rb;

	void Awake ()
	{
		_rb = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		_rb.velocity = new Vector2 (1.5f, 2.0f);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (gameObject.name + " Collided with " + other.gameObject.name);
	}
}
